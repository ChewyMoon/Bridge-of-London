namespace BridgeOfLondon.Core.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using MoonSharp.Interpreter;

    /// <summary>
    ///     Manages the Lua API for a script.
    /// </summary>
    internal class LuaApiManager
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="LuaApiManager"/> class. 
        /// </summary>
        static LuaApiManager()
        {
            ApiProviders =
                Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(p => typeof(ILuaApiProvider).IsAssignableFrom(p))
                    .Select(x => Expression.Lambda<Func<ILuaApiProvider>>(Expression.New(x)).Compile()());
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the API providers.
        /// </summary>
        /// <value>
        ///     The API providers.
        /// </value>
        public static IEnumerable<ILuaApiProvider> ApiProviders { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public static void AddApi(Script script)
        {
            foreach (var luaApiProvider in ApiProviders)
            {
                luaApiProvider.HookEvents();
                luaApiProvider.AddApi(script);
            }
        }

        #endregion
    }
}