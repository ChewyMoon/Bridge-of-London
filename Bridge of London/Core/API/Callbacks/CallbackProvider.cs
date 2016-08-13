﻿namespace BridgeOfLondon.Core.API.Callbacks
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
            script.Globals["AddLoadCallback"] = (Action<Closure>)this.AddLoadCallback;
            script.Globals["AddTickCallback"] = (Action<Closure>)this.AddTickCallback;
            script.Globals["AddDrawCallback"] = (Action<Closure>)this.AddDrawCallback;
            script.Globals["AddCreateObjCallback"] = (Action<Closure>) this.AddCreateObjectCallback;
            script.Globals["AddDeleteObjCallback"] = (Action<Closure>) this.AddDeleteObjectCallback;
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
            CustomEvents.Game.OnGameLoad += this.GameOnGameLoad;
            Game.OnUpdate += this.GameOnUpdate;
            Drawing.OnDraw += this.DrawingOnDraw;
            GameObject.OnCreate += this.OnCreateObject;
            GameObject.OnDelete += this.OnDeleteObject;
        }

        public void RegisterStandardCalls(Script script)
        {
            if (script.Globals["Environments"] == null)
            {
                return;
            }
            foreach (var tablePair in ((Table)script.Globals["Environments"]).Pairs)
            {
                var globals = (tablePair.Value.Table.Pairs);
                //Console.WriteLine("Registering std calls for "+ tablePair.Key);
                foreach (var pair2   in globals)
                {
                    //Console.WriteLine(pair2.Key + " " + pair2.Value.Type);
                    switch (pair2.Key.String)
                    {
                        case "OnLoad":
                            AddLoadCallback(pair2.Value.Function);
                            break;
                        case "OnTick":
                            AddTickCallback(pair2.Value.Function);
                            break;
                        case "OnDraw":
                            AddDrawCallback(pair2.Value.Function);
                            break;
                    }
                }
            }
        }

        #endregion
    }
}