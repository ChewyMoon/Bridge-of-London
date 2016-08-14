using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using LeagueSharp;
using LeagueSharp.Common;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    internal partial class CallbackProvider : ILuaApiProvider
    {
        private readonly IEnumerable<Callback> callbacks;

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            foreach (var callback in callbacks)
            {
                callback.AddApi(script);
            }
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
            foreach (var callback in callbacks)
            {
                callback.HookEvents();
            }
        }

        public CallbackProvider()
        {
            callbacks = Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => p.IsSubclassOf(typeof(Callback)))
                .Select(x => Expression.Lambda<Func<Callback>>(Expression.New(x)).Compile()());
        }

        public void RegisterStandardCalls(Script script)
        {
            foreach (var callback in callbacks)
            {
                callback.RegisterDefaultCallback(script);
            }
        }

        #endregion
    }
}