using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BridgeOfLondon.Core.Wrappers;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Managers
{
    class LuaObjectManager : ILuaApiProvider
    {
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
    }

    [MoonSharpUserData]
    class ObjectManagerImpl
    {
        private IEnumerable<GameObject> gameObjects => ObjectManager.Get<GameObject>();

        public int maxObjects => gameObjects.Count();

        /// <summary>
        /// Gets the <see cref="LuaGameObject"/> at the i-th index
        /// The index starts at 1 as lua arrays start at 1
        /// </summary>
        /// <param name="i"></param>
        /// <returns><see cref="LuaGameObject"/></returns>
        public LuaGameObject GetObject(int i)
        {
            return gameObjects.ElementAt(i - 1).ToLuaGameObject();
        }
    }
}
