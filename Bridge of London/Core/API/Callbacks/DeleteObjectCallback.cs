using System;
using System.Linq;
using BridgeOfLondon.Core.Wrappers;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    internal partial class CallbackProvider
    {
        #region Properties

        /// <summary>
        ///     The event that raises OnTick Callbacks
        /// </summary>
        private event ScriptFunctionDelegate DeleteObjectCallbacks;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the tick callback.
        /// </summary>
        /// <param name="func">The function.</param>
        public void AddDeleteObjectCallback(Closure func)
        {
            DeleteObjectCallbacks += func.GetDelegate();
        }

        /// <summary>
        ///     Fired when a game object is Deleted.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void OnDeleteObject(GameObject sender, EventArgs args)
        {
            if (DeleteObjectCallbacks == null)
            {
                return;
            }
            var luaSender = sender.ToLuaGameObject();
            foreach (var d in DeleteObjectCallbacks.GetInvocationList().ToArray())
            {
                try
                {
                    ((ScriptFunctionDelegate) d)(luaSender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        #endregion
    }
}