using System;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{

    internal partial class CallbackProvider : ILuaApiProvider
    {
        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            script.Globals["AddTickCallback"] = (Action<Closure>)this.AddTickCallback;
            script.Globals["AddLoadCallback"] = (Action<Closure>)this.AddLoadCallback;
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
            LeagueSharp.Common.CustomEvents.Game.OnGameLoad += this.GameOnGameLoad;
            LeagueSharp.Game.OnUpdate += this.GameOnUpdate;
        }
    }
}
