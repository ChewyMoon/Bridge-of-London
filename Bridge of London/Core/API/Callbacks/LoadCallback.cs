using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    internal partial class CallbackProvider
    {
        #region Properties

        /// <summary>
        /// The event that raises OnLoad Callbacks
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
            LoadCallbacks += func.GetDelegate();
        }
        #endregion


        #region Methods

        /// <summary>
        /// Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GameOnGameLoad(EventArgs args)
        {
            if (LoadCallbacks == null)
            {
                return;
            }

            foreach (Delegate d in LoadCallbacks.GetInvocationList().ToArray())
            {
                try
                {
                    ((ScriptFunctionDelegate) d)();
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                }
            }
        }

        #endregion


    }
}
