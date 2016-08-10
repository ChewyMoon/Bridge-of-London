namespace BridgeOfLondon.Core.API.Game
{
    using System;

    using LeagueSharp;

    using MoonSharp.Interpreter;

    using SharpDX;

    /// <summary>
    /// Provides extensions for the <see cref="SpellDataInst"/> class.
    /// </summary>
    internal static class SpellDataInstExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// To the bol spell.
        /// </summary>
        /// <param name="spellDataInst">The spell data inst.</param>
        /// <returns></returns>
        public static Spell ToLuaSpell(this SpellDataInst spellDataInst)
        {
            return new Spell(spellDataInst);
        }

        #endregion
    }

    /// <summary>
    /// A Lua representation of the <see cref="SpellDataInst" /> class.
    /// </summary>
    [MoonSharpUserData]
    public class Spell
    {
        #region Fields

        /// <summary>
        /// The end position
        /// </summary>
        public Vector3 endPos;

        /// <summary>
        /// The start position
        /// </summary>
        public Vector3 startPos;

        /// <summary>
        /// The _spell data inst
        /// </summary>
        private readonly SpellDataInst _spellDataInst;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Spell"/> class.
        /// </summary>
        /// <param name="spellDataInst">The spell data inst.</param>
        public Spell(SpellDataInst spellDataInst)
        {
            this._spellDataInst = spellDataInst;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the cooldown of the spell.
        /// </summary>
        /// <value>
        /// The cooldown.
        /// </value>
        public float cd => this._spellDataInst.Cooldown;

        /// <summary>
        /// Gets the current cooldown.
        /// </summary>
        /// <value>
        /// The current coodown.
        /// </value>
        public float currentCd => Math.Max(this._spellDataInst.CooldownExpires - Game.ClockTime, 0);

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public int level => this._spellDataInst.Level;

        /// <summary>
        /// Gets the mana.
        /// </summary>
        /// <value>
        /// The mana.
        /// </value>
        public float mana => this._spellDataInst.ManaCost;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name => this._spellDataInst.Name;

        /// <summary>
        /// Gets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public float range => this._spellDataInst.SData.CastRange;

        #endregion
    }
}