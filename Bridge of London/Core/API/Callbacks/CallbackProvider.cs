<<<<<<< HEAD
﻿using System;
using BridgeOfLondon.Core.Wrappers;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
=======
﻿namespace BridgeOfLondon.Core.API.Callbacks
>>>>>>> origin/master
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
            script.Globals["AddCreateObjCallback"] = (Action<Closure>) this.CreateObjectCallback;
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
<<<<<<< HEAD
            LeagueSharp.Common.CustomEvents.Game.OnGameLoad += this.GameOnGameLoad;
            LeagueSharp.Game.OnUpdate += this.GameOnUpdate;
            LeagueSharp.GameObject.OnCreate += this.OnCreateObject;
=======
            CustomEvents.Game.OnGameLoad += this.GameOnGameLoad;
            Game.OnUpdate += this.GameOnUpdate;
>>>>>>> origin/master
        }

        #endregion
    }
}