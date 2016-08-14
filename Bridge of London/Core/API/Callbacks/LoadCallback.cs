using LeagueSharp.Common;

namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;
    using LeagueSharp;
    using MoonSharp.Interpreter;
    internal class LoadCallback : Callback
    {
        #region Properties
        public override string AddCallbackLuaFunctionName => "AddLoadCallback";
        public override string DefaultCallbackFunctionName => "OnLoad";
        public override event ScriptFunctionDelegate Callbacks;
        #endregion

        #region Public Methods
        /// <summary>
        /// Hooks the events
        /// </summary>
        public override void HookEvents()
        {
            CustomEvents.Game.OnGameLoad += GameOnOnGameLoad;
        }

        #endregion

        #region Methods
        /// <summary>
        ///     Fired when the game is Loaded.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GameOnOnGameLoad(EventArgs args)
        {
            if (Callbacks == null)
            {
                return;
            }

            foreach (var d in Callbacks.GetInvocationList().ToArray())
            {
                try
                {
                    ((ScriptFunctionDelegate)d)();
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
