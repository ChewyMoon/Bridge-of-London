namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;
    using LeagueSharp;
    using MoonSharp.Interpreter;
    internal class TickCallback : Callback
    {
        #region Properties
        public override string AddCallbackLuaFunctionName => "AddTickCallback";
        public override string DefaultCallbackFunctionName => "OnTick";
        public event ScriptFunctionDelegate Callbacks;
        #endregion

        #region Public Methods
        /// <summary>
        /// Hooks the events
        /// </summary>
        public override void HookEvents()
        {
            Game.OnUpdate += GameOnOnUpdate;
        }

        /// <summary>
        ///     Adds the OnTick callback.
        /// </summary>
        /// <param name="function">The function.</param>
        public override void AddCallback(Closure function)
        {
            Callbacks += function.GetDelegate();
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GameOnOnUpdate(EventArgs args)
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
