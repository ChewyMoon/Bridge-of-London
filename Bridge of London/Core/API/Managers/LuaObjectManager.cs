namespace BridgeOfLondon.Core.API.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using global::BridgeOfLondon.Core.Wrappers;

    using LeagueSharp;

    using MoonSharp.Interpreter;

    /// <summary>
    ///     Adds the ObjectManager API to Lua scripts.
    /// </summary>
    /// <seealso cref="BridgeOfLondon.Core.API.ILuaApiProvider" />
    internal class LuaObjectManager : ILuaApiProvider
    {
        #region Public Methods and Operators

        public void AddApi(Script script)
        {
            script.Globals["objManager"] = new ObjectManagerImpl();
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
        }

        #endregion
    }

    /// <summary>
    ///     The Lua implemenation of the <see cref="ObjectManager" /> class.
    /// </summary>
    [MoonSharpUserData]
    internal class ObjectManagerImpl
    {
        #region Public Properties

        /// <summary>
        ///     Gets the maximum objects.
        /// </summary>
        /// <value>
        ///     The maximum objects.
        /// </value>
        public int maxObjects => GameObjects.Count();

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the game objects.
        /// </summary>
        /// <value>
        ///     The game objects.
        /// </value>
        private static IEnumerable<GameObject> GameObjects => ObjectManager.Get<GameObject>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the <see cref="LuaGameObject" /> at the i-th index
        ///     The index starts at 1 as lua arrays start at 1
        /// </summary>
        /// <param name="i"></param>
        /// <returns>
        ///     <see cref="LuaGameObject" />
        /// </returns>
        public LuaGameObject GetObject(int i)
        {
            return GameObjects.ElementAt(i - 1).ToLuaGameObject();
        }

        #endregion
    }
}