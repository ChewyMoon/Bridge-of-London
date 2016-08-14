using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    internal class CallbackProvider : ILuaApiProvider
    {
        private readonly List<Callback> callbacks = new List<Callback>();

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            foreach (var callback in callbacks)
            {
                Console.WriteLine(callback);
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
            var callbackTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => p.IsSubclassOf(typeof(Callback)));

            foreach (var callbackType in callbackTypes)
            {
                callbacks.Add(Expression.Lambda<Func<Callback>>(Expression.New(callbackType)).Compile()());
            }
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