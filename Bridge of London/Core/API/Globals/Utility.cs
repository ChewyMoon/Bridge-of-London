using System;
using BridgeOfLondon.Core.Wrappers;
using LeagueSharp;
using LeagueSharp.Common;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Globals
{
    class Utility : ILuaApiProvider
    {
        public void AddApi(Script script)
        {
            AddChatApi(script);
            GeneralApi(script);
        }

        public void HookEvents()
        {
            //TODO:
            //Do it properly without OnUpdate?
            Game.OnUpdate += args =>
            {
                var cursor = Game.CursorPos;
                mousePos.x = cursor.X;
                mousePos.y = cursor.Z;
                mousePos.z = cursor.Y;
            };
        }

        
        private void AddChatApi(Script script)
        {
            script.Globals["PrintChat"] = (Action<string, object[]>) Game.PrintChat;
            script.Globals["SendChat"]  = (Action<string, object[]>) Game.PrintChat;//Eh
            //BlockChat() missing
        }

        public LuaVector3 mousePos => Game.CursorPos.ToLuaVector3();

        private void GeneralApi(Script script)
        {
            script.Globals["mousePos"] = mousePos;
            script.Globals["GetMyHero"] = new Func<Obj_AI_Hero>(() => ObjectManager.Player);
            script.Globals["GetTickCount"] = new Func<int>(() => Utils.GameTimeTickCount);
            script.Globals["GetLatency"] = new Func<float>(() => Game.Ping);
            script.Globals["GetTarget"] = new Func<LuaGameObject>(() => TargetSelector.GetSelectedTarget().ToLuaGameObject());
        }

        private Obj_AI_Hero GetMyHero()
        {
            return ObjectManager.Player;
        }
    }
}
