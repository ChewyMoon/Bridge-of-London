namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;

    using LeagueSharp;
    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    internal partial class CallbackProvider : ILuaApiProvider
    {
        #region Public Methods and Operators

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
            CustomEvents.Game.OnGameLoad += this.GameOnGameLoad;
            Game.OnUpdate += this.GameOnUpdate;
        }

        #endregion
    }
}