namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;
    using LeagueSharp;
    using MoonSharp.Interpreter;
    internal sealed class DrawCallback : Callback
    {
        #region Properties
        public override string AddCallbackLuaFunctionName => "AddDrawCallback";
        public override string DefaultCallbackFunctionName => "OnDraw";
        public override event ScriptFunctionDelegate Callbacks; 
        #endregion

        #region Public Methods
        /// <summary>
        /// Hooks the events
        /// </summary>
        public override void HookEvents()
        {
            Drawing.OnDraw += DrawingOnOnDraw;
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Fired when objects are drawn.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DrawingOnOnDraw(EventArgs args)
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
