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
        private event ScriptFunctionDelegate LoadCallbacks;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the load callback.
        /// </summary>
        /// <param name="func">The function.</param>
        public void AddLoadCallback(Closure func)
        {
            this.LoadCallbacks += func.GetDelegate();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GameOnGameLoad(EventArgs args)
        {
            if (this.LoadCallbacks == null)
            {
                return;
            }

            foreach (var d in this.LoadCallbacks.GetInvocationList().ToArray())
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