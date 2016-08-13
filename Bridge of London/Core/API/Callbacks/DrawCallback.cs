namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;

    using MoonSharp.Interpreter;

    internal partial class CallbackProvider
    {
        #region Events

        /// <summary>
        ///     The event that raises OnDraw Callbacks
        /// </summary>
        private event ScriptFunctionDelegate DrawCallbacks;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the Draw callback.
        /// </summary>
        /// <param name="func">The function.</param>
        public void AddDrawCallback(Closure func)
        {
            this.DrawCallbacks += func.GetDelegate();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void DrawingOnDraw(EventArgs args)
        {
            if (this.DrawCallbacks == null)
            {
                return;
            }

            foreach (var d in this.DrawCallbacks.GetInvocationList().ToArray())
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