using BridgeOfLondon.Core.Wrappers;

namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;
    using LeagueSharp;
    using MoonSharp.Interpreter;
    internal sealed class ProcessSpellCallback : Callback
    {
        #region Properties
        public override string AddCallbackLuaFunctionName => "AddProcessSpellCallback";
        public override string DefaultCallbackFunctionName => "OnProcessSpell";
        public override event ScriptFunctionDelegate Callbacks;
        #endregion

        #region Public Methods
        /// <summary>
        /// Hooks the events
        /// </summary>
        public override void HookEvents()
        {
            Obj_AI_Base.OnProcessSpellCast += ObjAiBaseOnOnProcessSpellCast;
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Fired when a spell is casted.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void ObjAiBaseOnOnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (Callbacks == null)
            {
                return;
            }
            var luaUnit = sender.ToLuaGameObject();
            var luaSpell = args.ToLua();
            foreach (var d in Callbacks.GetInvocationList().ToArray())
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
