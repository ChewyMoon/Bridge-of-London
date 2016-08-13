namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;

    using MoonSharp.Interpreter;

    internal partial class CallbackProvider
    {
        #region Events

        /// <summary>
        ///     The event that raises OnTick Callbacks
        /// </summary>
        private event ScriptFunctionDelegate TickCallbacks;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the tick callback.
        /// </summary>
        /// <param name="func">The function.</param>
        public void AddTickCallback(Closure func)
        {
            this.TickCallbacks += func.GetDelegate();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GameOnUpdate(EventArgs args)
        {
            if (this.TickCallbacks == null)
            {
                return;
            }
            foreach (var d in this.TickCallbacks.GetInvocationList().ToArray())
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