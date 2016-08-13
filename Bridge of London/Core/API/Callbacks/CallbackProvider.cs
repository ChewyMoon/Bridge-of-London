﻿using System.Collections.Generic;

namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;

    using LeagueSharp;
    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    internal partial class CallbackProvider : ILuaApiProvider
    {
        private List<Callback> callbacks = new List<Callback>();

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            foreach (var callback in callbacks)
            {
                script.Globals[callback.AddCallbackLuaName] = callback.AddCallbackFunction;
            }
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
            Obj_AI_Base.OnProcessSpellCast += this.ObjAiBaseOnProcessSpellCast;
        }

        public CallbackProvider()
        {
            callbacks.Add(new Callback("OnLoad", "AddLoadCallback", this.AddLoadCallback));
            callbacks.Add(new Callback("OnTick", "AddTickCallback", this.AddTickCallback));
            callbacks.Add(new Callback("OnDraw", "AddDrawCallback", this.AddDrawCallback));
            callbacks.Add(new Callback("OnCreateObj", "AddCreateObjCallback", this.AddCreateObjectCallback));
            callbacks.Add(new Callback("OnDeleteObj", "AddDeleteObjCallback", this.AddDeleteObjectCallback));
            callbacks.Add(new Callback("OnProcessSpell", "AddProcessSpellCallback", this.AddProcessSpellCallback));
        }

        public void RegisterStandardCalls(Script script)
        {
            if (script.Globals["Environments"] == null)
            {
                return;
            }

            foreach (var tablePair in ((Table)script.Globals["Environments"]).Pairs)
            {
                var envTable = (tablePair.Value.Table);
                Console.WriteLine("Registering std calls for "+ tablePair.Key);
                foreach (var callback in callbacks)
                {
                    var function = envTable[callback.DefaultFunction] as Closure;
                    if (function == null)
                    {
                        continue;
                    }
                    callback.AddCallbackFunction(function);
                }
            }
        }

        #endregion
    }
}