namespace BridgeOfLondon.Core.API.Globals
{
    using System;

    using global::BridgeOfLondon.Core.Wrappers;

    using LeagueSharp;

    using MoonSharp.Interpreter;

    using SharpDX;

    /// <summary>
    ///     Adds the Spell API to the lua script.
    /// </summary>
    /// <seealso cref="BridgeOfLondon.Core.API.ILuaApiProvider" />
    internal class SpellApi : ILuaApiProvider
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            script.Globals["CastSpell"] = (Func<object[], bool>)this.CastSpell;
            script.Globals["CastSpell2"] = (Func<SpellSlot, LuaVector3, bool>)this.CastSpell2;
            script.Globals["CastSpell3"] = (Func<SpellSlot, LuaVector3, LuaVector3, bool>)this.CastSpell3;
            script.Globals["LevelSpell"] = (Action<SpellSlot>)this.LevelSpell;
            script.Globals["EvolveSpell"] = (Action<SpellSlot>)this.EvolveSpell;
        }

        /// <summary>
        ///     Casts the spell.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
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
                    return ObjectManager.Player.Spellbook.CastSpell(
                        spellSlot,
                        new Vector3((float)args[1], (float)args[2], 0));
                default:
                    return false;
            }
        }

        /// <summary>
        ///     Casts the spell2.
        /// </summary>
        /// <param name="spellShot">The spell shot.</param>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        public bool CastSpell2(SpellSlot spellShot, LuaVector3 vector)
        {
            return ObjectManager.Player.Spellbook.CastSpell(spellShot, vector.ToVector3());
        }

        /// <summary>
        ///     Casts the spell3.
        /// </summary>
        /// <param name="spellShot">The spell shot.</param>
        /// <param name="startPos">The start position.</param>
        /// <param name="endPos">The end position.</param>
        /// <returns></returns>
        public bool CastSpell3(SpellSlot spellShot, LuaVector3 startPos, LuaVector3 endPos)
        {
            return ObjectManager.Player.Spellbook.CastSpell(spellShot, startPos.ToVector3(), endPos.ToVector3());
        }

        /// <summary>
        ///     Evolves the spell.
        /// </summary>
        /// <param name="spellSlot">The spell slot.</param>
        public void EvolveSpell(SpellSlot spellSlot)
        {
            ObjectManager.Player.Spellbook.EvolveSpell(spellSlot);
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
        }

        /// <summary>
        ///     Levels the spell.
        /// </summary>
        /// <param name="spellSlot">The spell slot.</param>
        public void LevelSpell(SpellSlot spellSlot)
        {
            ObjectManager.Player.Spellbook.LevelSpell(spellSlot);
        }

        #endregion
    }
}