using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BridgeOfLondon.Core.API.Callbacks
{
    using MoonSharp.Interpreter;
    using LeagueSharp;

    internal partial class CallbackProvider
    {
        #region Properties

        /// <summary>
        /// The event that raises OnTick Callbacks
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
            TickCallbacks += func.GetDelegate();
        }

        /// <summary>
        /// Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void GameOnUpdate(EventArgs args)
        {
            if (TickCallbacks == null)
            {
                return;
            }

            foreach (Delegate d in TickCallbacks.GetInvocationList().ToArray())
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