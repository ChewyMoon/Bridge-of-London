using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeOfLondon.Core.Wrappers;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    internal partial class CallbackProvider
    {
        #region Properties

        /// <summary>
        /// The event that raises OnTick Callbacks
        /// </summary>
        private event ScriptFunctionDelegate CreateObjectCallbacks;
        #endregion

        #region Public Methods and Operators


        /// <summary>
        ///     Adds the tick callback.
        /// </summary>
        /// <param name="func">The function.</param>
        public void AddCreateObjectCallback(Closure func)
        {
            CreateObjectCallbacks += func.GetDelegate();
        }

        /// <summary>
        /// Fired when a game object is created.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnCreateObject(GameObject sender, EventArgs args)
        {
            if (CreateObjectCallbacks == null)
            {
                return;
            }
            var luaSender = sender.ToLuaGameObject();
            foreach (Delegate d in CreateObjectCallbacks.GetInvocationList().ToArray())
            {
                try
                {
                    ((ScriptFunctionDelegate)d)(luaSender);
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
