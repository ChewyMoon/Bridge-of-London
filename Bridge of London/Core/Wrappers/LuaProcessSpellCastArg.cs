using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.Wrappers
{
    static class GameObjectProcessSpellCastEventArgsExtension
    {
        public static LuaProcessSpellCastArg ToLua(this GameObjectProcessSpellCastEventArgs spell)
        {
            return  new LuaProcessSpellCastArg(spell);
        }
    }

    [MoonSharpUserData]
    class LuaProcessSpellCastArg
    {
        GameObjectProcessSpellCastEventArgs spell;

        public LuaProcessSpellCastArg(GameObjectProcessSpellCastEventArgs spell0)
        {
            spell = spell0;
        }

        public string name => spell.SData.Name;


        private LuaVector3 cachedStartPos; 
        public LuaVector3 startPos => cachedStartPos ?? (cachedStartPos = spell.Start.ToLuaVector3());

        private LuaVector3 cachedEndPos;
        public LuaVector3 endPos => cachedEndPos ?? (cachedEndPos = spell.End.ToLuaVector3());

        public float windUpTime => spell.SData.SpellCastTime;

        private LuaGameObject cachedGameObject;
        public LuaGameObject target => cachedGameObject ?? (cachedGameObject = spell.Target.ToLuaGameObject());


    }
}
