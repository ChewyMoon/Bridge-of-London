using System;
using BridgeOfLondon.Core.Wrappers;
using LeagueSharp;
using MoonSharp.Interpreter;
using SharpDX;

namespace BridgeOfLondon.Core.API.Globals
{
    internal class SpellApi : ILuaApiProvider
    {
        public void AddApi(Script script)
        {
            script.Globals["CastSpell"]  = (Func<object[], bool>) CastSpell;
            script.Globals["CastSpell2"] = (Func<SpellSlot, LuaVector3, bool>) CastSpell2;
            script.Globals["CastSpell3"] = (Func<SpellSlot, LuaVector3, LuaVector3, bool>) CastSpell3;
            script.Globals["LevelSpell"] = (Action<SpellSlot>) LevelSpell;
            script.Globals["EvolveSpell"] = (Action<SpellSlot>) EvolveSpell;
        }

        public void HookEvents()
        {
        }

        public bool CastSpell(params object[] args)
        {
            if (args.Length == 0)
            {
                return false;
            }
            var spellSlot = args[0] as SpellSlot? ?? SpellSlot.Unknown;
            if (spellSlot == SpellSlot.Unknown)
            {
                return false;
            }
            switch (args.Length)
            {
                case 1:
                    return ObjectManager.Player.Spellbook.CastSpell(spellSlot);
                case 2:
                    var unit = args[1] as LuaGameObject;
                    return unit != null && ObjectManager.Player.Spellbook.CastSpell(spellSlot, unit.GetGameObject());
                case 3:
                    return ObjectManager.Player.Spellbook.CastSpell(spellSlot,
                        new Vector3((float) args[1], (float) args[2], 0));
            }
            return false;
        }

        public bool CastSpell2(SpellSlot spellShot, LuaVector3 vector)
        {
            return ObjectManager.Player.Spellbook.CastSpell(spellShot, vector.ToVector3());
        }

        public bool CastSpell3(SpellSlot spellShot, LuaVector3 startPos, LuaVector3 endPos)
        {
            return ObjectManager.Player.Spellbook.CastSpell(spellShot, startPos.ToVector3(), endPos.ToVector3());
        }

        public void LevelSpell(SpellSlot spellSlot)
        {
            ObjectManager.Player.Spellbook.LevelSpell(spellSlot);
        }
        public void EvolveSpell(SpellSlot spellSlot)
        {
            ObjectManager.Player.Spellbook.EvolveSpell(spellSlot);
        }
    }
}