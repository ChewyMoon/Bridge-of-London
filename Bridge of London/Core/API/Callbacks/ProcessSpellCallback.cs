using BridgeOfLondon.Core.Wrappers;
using LeagueSharp;

namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;

    using MoonSharp.Interpreter;

    internal partial class CallbackProvider
    {
        #region Events

        /// <summary>
        ///     The event that raises OnLoad Callbacks
        /// </summary>
        private event ScriptFunctionDelegate ProcessSpellCallback;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the load callback.
        /// </summary>
        /// <param name="func">The function.</param>
        public void AddProcessSpellCallback(Closure func)
        {
            this.ProcessSpellCallback += func.GetDelegate();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ObjAiBaseOnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (this.ProcessSpellCallback == null)
            {
                return;
            }
            var luaUnit = sender.ToLuaGameObject();
            var luaSpell = args.ToLua();
            foreach (var d in this.ProcessSpellCallback.GetInvocationList().ToArray())
            {
                try
                {
                    ((ScriptFunctionDelegate)d)(luaUnit, luaSpell);
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