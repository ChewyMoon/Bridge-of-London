// ReSharper disable InconsistentNaming
namespace BridgeOfLondon.Core.API.Game
{
    using global::BridgeOfLondon.Core.API.Helpers;

    using LeagueSharp;
    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    using SharpDX;

    /// <summary>
    ///     Provides extensions to the <see cref="Obj_AI_Base" /> class.
    /// </summary>
    public static class Obj_Ai_BaseExtension
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Converts the <see cref="Obj_AI_Base" /> to a Lua <see cref="GameUnit" />;
        /// </summary>
        /// <param name="objBase">The object base.</param>
        /// <returns></returns>
        public static GameUnit ToLuaGameUnit(this Obj_AI_Base objBase)
        {
            return new GameUnit(objBase);
        }

        #endregion
    }

    /// <summary>
    ///     A Lua wrapper over an <see cref="Obj_AI_Base" />.
    /// </summary>
    [MoonSharpUserData]
    public class GameUnit
    {
        #region Fields

        /// <summary>
        ///     The unit
        /// </summary>
        private readonly Obj_AI_Base unit;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameUnit" /> class.
        /// </summary>
        /// <param name="objBase">The object base.</param>
        public GameUnit(Obj_AI_Base objBase)
        {
            this.unit = objBase;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     TODO
        /// </summary>
        public float addDamage => 0f;

        /// <summary>
        ///     Gets the ap.
        /// </summary>
        /// <value>
        ///     The ap.
        /// </value>
        public float ap => this.unit.TotalMagicalDamage;

        /// <summary>
        ///     Gets the armor.
        /// </summary>
        /// <value>
        ///     The armor.
        /// </value>
        public float armor => this.unit.Armor;

        /// <summary>
        ///     Gets the armor material.
        /// </summary>
        /// <value>
        ///     The armor material.
        /// </value>
        public string armorMaterial => this.unit.ArmorMaterial;

        /// <summary>
        ///     Gets the armor pen.
        /// </summary>
        /// <value>
        ///     The armor pen.
        /// </value>
        public float armorPen => this.unit.FlatArmorPenetrationMod;

        /// <summary>
        ///     Gets the armor pen percent.
        /// </summary>
        /// <value>
        ///     The armor pen percent.
        /// </value>
        public float armorPenPercent => this.unit.PercentArmorPenetrationMod;

        /// <summary>
        ///     Gets the attack speed.
        /// </summary>
        /// <value>
        ///     The attack speed.
        /// </value>
        public float attackSpeed => this.unit.AttackSpeedMod;

        /// <summary>
        ///     Gets a value indicating whether the unit is invulnerable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the unit is invulnerable; otherwise, <c>false</c>.
        /// </value>
        public bool bInvulnerable => this.unit.IsInvulnerable;

        /// <summary>
        ///     Gets a value indicating whether the unit is magic imune.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the unit is magic imune; otherwise, <c>false</c>.
        /// </value>
        public bool bMagicImune => this.unit.MagicImmune;

        /// <summary>
        ///     Gets a value indicating whether the unit is physical imune.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the unit is physical imune; otherwise, <c>false</c>.
        /// </value>
        public bool bPhysImune => this.unit.PhysicalImmune;

        /// <summary>
        ///     Gets a value indicating whether the unit is targetable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the unit istargetable; otherwise, <c>false</c>.
        /// </value>
        public bool bTargetable => this.unit.IsTargetable;

        /// <summary>
        ///     Gets a value indicating whether the unit is targetable to team. This implemenation is more than likely not correct.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the unit is targetable to team; otherwise, <c>false</c>.
        /// </value>
        public bool bTargetableToTeam => this.unit.IsTargetable;

        /// <summary>
        ///     Gets the number of buffs applied to the unit
        /// </summary>
        /// <value>
        ///     The buff count.
        /// </value>
        public int buffCount => this.unit.Buffs.Length;

        /// <summary>
        ///     Gets a value indicating whether this unit can attack.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this unit can attack; otherwise, <c>false</c>.
        /// </value>
        public bool canAttack => this.unit.CanAttack;

        /// <summary>
        ///     Gets a value indicating whether this unit can move.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this unit can move; otherwise, <c>false</c>.
        /// </value>
        public bool canMove => this.unit.CanMove;

        /// <summary>
        ///     Gets the cool down reduction of the champion.
        /// </summary>
        /// <value>
        ///     The cool down reduction.
        /// </value>
        public float cdr => this.unit.FlatCooldownMod;

        /// <summary>
        ///     Gets the charName of the unit. Honestly dunno what this is....
        /// </summary>
        public string charName => this.unit.CharData.BaseSkinName;

        /// <summary>
        ///     Gets a value indicating whether this <see cref="GameUnit" /> is controlled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if controlled; otherwise, <c>false</c>.
        /// </value>
        public bool controlled => this.unit.PlayerControlled;

        /// <summary>
        ///     Gets the crit chance.
        /// </summary>
        /// <value>
        ///     The crit chance.
        /// </value>
        public float critChance => this.unit.FlatCritChanceMod;

        /// <summary>
        ///     Gets the crit damage.
        /// </summary>
        /// <value>
        ///     The crit damage.
        /// </value>
        public float critDmg => this.unit.FlatCritDamageMod;

        /// <summary>
        ///     Gets the damage.
        /// </summary>
        /// <value>
        ///     The damage.
        /// </value>
        public float damage => this.unit.TotalAttackDamage;

        /// <summary>
        ///     Gets a value indicating whether this <see cref="GameUnit" /> is dead.
        /// </summary>
        /// <value>
        ///     <c>true</c> if dead; otherwise, <c>false</c>.
        /// </value>
        public bool dead => this.unit.IsDead;

        /// <summary>
        ///     Gets the death timer.
        /// </summary>
        /// <value>
        ///     The death timer.
        /// </value>
        public float deathTimer => this.unit.DeathDuration;

        /// <summary>
        ///     Gets the experience bonus.
        /// </summary>
        /// <value>
        ///     The experience bonus.
        /// </value>
        public float expBonus => this.unit.PercentEXPBonus;

        /// <summary>
        ///     Gets the gold.
        /// </summary>
        /// <value>
        ///     The gold.
        /// </value>
        public float gold => this.unit.Gold;

        /// <summary>
        ///     TODO
        /// </summary>
        public float hardness => 0f;

        /// <summary>
        ///     Gets the health.
        /// </summary>
        /// <value>
        ///     The health.
        /// </value>
        public float health => this.unit.Health;

        /// <summary>
        ///     Gets the health point pool.
        /// </summary>
        /// <value>
        ///     The health point pool.
        /// </value>
        public float hpPool => this.unit.FlatHPPoolMod;

        /// <summary>
        ///     Gets the health point regen.
        /// </summary>
        /// <value>
        ///     The health point regen.
        /// </value>
        public float hpRegen => this.unit.HPRegenRate;

        /// <summary>
        ///     Gets a value indicating whether this instance is an AI. This implemenation may not be correct.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is an AI; otherwise, <c>false</c>.
        /// </value>
        public bool isAi => !this.unit.PlayerControlled;

        /// <summary>
        ///     Gets a value indicating whether this instance is asleep.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is asleep; otherwise, <c>false</c>.
        /// </value>
        public bool isAsleep => this.unit.CharacterState.HasFlag(GameObjectCharacterState.Asleep);

        /// <summary>
        ///     Gets a value indicating whether this instance is charmed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is charmed; otherwise, <c>false</c>.
        /// </value>
        public bool isCharmed => this.unit.IsCharmed;

        /// <summary>
        ///     Gets a value indicating whether this instance is feared.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is feared; otherwise, <c>false</c>.
        /// </value>
        public bool isFeared => this.unit.CharacterState.HasFlag(GameObjectCharacterState.Feared);

        /// <summary>
        ///     Gets a value indicating whether this instance is fleeing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is fleeing; otherwise, <c>false</c>.
        /// </value>
        public bool isFleeing => this.unit.CharacterState.HasFlag(GameObjectCharacterState.Fleeing);

        /// <summary>
        ///     Gets a value indicating whether this instance is force render particles.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is force render particles; otherwise, <c>false</c>.
        /// </value>
        public bool isForceRenderParticles
            => this.unit.CharacterState.HasFlag(GameObjectCharacterState.ForceRenderParticles);

        /// <summary>
        ///     Gets a value indicating whether this instance is ghosted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is ghosted; otherwise, <c>false</c>.
        /// </value>
        public bool isGhosted => this.unit.CharacterState.HasFlag(GameObjectCharacterState.Ghosted);

        /// <summary>
        ///     Gets a value indicating whether this instance is me.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is me; otherwise, <c>false</c>.
        /// </value>
        public bool isMe => this.unit.IsMe;

        /// <summary>
        ///     Gets a value indicating whether this instance is near sight.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is near sight; otherwise, <c>false</c>.
        /// </value>
        public bool isNearSight => this.unit.CharacterState.HasFlag(GameObjectCharacterState.NearSight);

        /// <summary>
        ///     Gets a value indicating whether this instance is no render.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is no render; otherwise, <c>false</c>.
        /// </value>
        public bool isNoRender => this.unit.CharacterState.HasFlag(GameObjectCharacterState.NoRender);

        /// <summary>
        ///     Gets a value indicating whether this instance is reveal specific unit.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is reveal specific unit; otherwise, <c>false</c>.
        /// </value>
        public bool isRevealSpecificUnit
            => this.unit.CharacterState.HasFlag(GameObjectCharacterState.RevealSpecificUnit);

        /// <summary>
        ///     Gets a value indicating whether this instance is stealthed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is stealthed; otherwise, <c>false</c>.
        /// </value>
        public bool isStealthed => this.unit.CharacterState.HasFlag(GameObjectCharacterState.IsStealth);

        /// <summary>
        ///     Gets a value indicating whether this instance is taunted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is taunted; otherwise, <c>false</c>.
        /// </value>
        public bool isTaunted => this.unit.CharacterState.HasFlag(GameObjectCharacterState.Taunted);

        /// <summary>
        ///     Gets the level.
        /// </summary>
        /// <value>
        ///     The level.
        /// </value>
        public int level => this.unit.Type == GameObjectType.obj_AI_Hero ? ((Obj_AI_Hero)this.unit).Level : 0;

        /// <summary>
        ///     Gets the life steal.
        /// </summary>
        /// <value>
        ///     The life steal.
        /// </value>
        public float lifeSteal => this.unit.PercentLifeStealMod;

        /// <summary>
        ///     Gets the magic armor.
        /// </summary>
        /// <value>
        ///     The magic armor.
        /// </value>
        public float magicArmor => this.unit.SpellBlock;

        /// <summary>
        ///     Gets the magic penetration.
        /// </summary>
        /// <value>
        ///     The magic penetration.
        /// </value>
        public float magicPen => this.unit.FlatMagicPenetrationMod;

        /// <summary>
        ///     Gets the magic pen perecent.
        /// </summary>
        /// <value>
        ///     The magic pen perecent.
        /// </value>
        public float magicPenPerecent => this.unit.PercentMagicPenetrationMod;

        /// <summary>
        ///     Gets the magic reduction.
        /// </summary>
        /// <value>
        ///     The magic reduction.
        /// </value>
        public float magicReduction => this.unit.FlatMagicReduction;

        /// <summary>
        ///     Gets the mana.
        /// </summary>
        /// <value>
        ///     The mana.
        /// </value>
        public float mana => this.unit.Mana;

        /// <summary>
        ///     Gets the maximum bounding box.
        /// </summary>
        /// <value>
        ///     The maximum bounding box.
        /// </value>
        public LuaVector maxBBox => this.unit.BBox.Maximum.ToLuaVector();

        /// <summary>
        ///     Gets the maximum health.
        /// </summary>
        /// <value>
        ///     The maximum health.
        /// </value>
        public float maxHealth => this.unit.MaxHealth;

        /// <summary>
        ///     Gets the maximum mana.
        /// </summary>
        /// <value>
        ///     The maximum mana.
        /// </value>
        public float maxMana => this.unit.MaxMana;

        /// <summary>
        ///     Gets the minimum bounding box.
        /// </summary>
        /// <value>
        ///     The minimum bounding box.
        /// </value>
        public LuaVector minBBox => this.unit.BBox.Minimum.ToLuaVector();

        /// <summary>
        ///     Gets the mana regen.
        /// </summary>
        /// <value>
        ///     The mana regen.
        /// </value>
        public float mpRegen => this.unit.PARRegenRate;

        /// <summary>
        ///     Gets the movement speed of the unit.
        /// </summary>
        /// <value>
        ///     The movement speed of the unit.
        /// </value>
        public float ms => this.unit.MoveSpeed;

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string name => this.unit.Name;

        /// <summary>
        ///     Gets the network identifier.
        /// </summary>
        /// <value>
        ///     The network identifier.
        /// </value>
        public int networkID => this.unit.NetworkId;

        /// <summary>
        ///     Gets the physical reduction.
        /// </summary>
        /// <value>
        ///     The physical reduction.
        /// </value>
        public float physReduction => this.unit.FlatPhysicalReduction;

        /// <summary>
        ///     Gets the position.
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public LuaVector pos => this.unit.Position.ToLuaVector();

        /// <summary>
        ///     Gets the range.
        /// </summary>
        /// <value>
        ///     The range.
        /// </value>
        public float range => this.unit.AttackRange;

        /// <summary>
        ///     TODO
        /// </summary>
        public GameUnit spellOwner => this;

        /// <summary>
        ///     Gets the spell vamp.
        /// </summary>
        /// <value>
        ///     The spell vamp.
        /// </value>
        public float spellVamp => this.unit.PercentSpellVampMod;

        /// <summary>
        ///     Gets the team.
        /// </summary>
        /// <value>
        ///     The team.
        /// </value>
        public GameObjectTeam team => this.unit.Team;

        /// <summary>
        ///     Gets the total damage.
        /// </summary>
        /// <value>
        ///     The total damage.
        /// </value>
        public float totalDamage => this.unit.TotalAttackDamage;

        /// <summary>
        ///     Gets the type of the object as string(Bol :roto2:)
        /// </summary>
        public string type => this.unit.Type.ToString();

        /// <summary>
        ///     Gets if the hero is visible or not
        /// </summary>
        public bool visible => this.unit.IsVisible;

        /// <summary>
        ///     TODO:
        ///     Does not exist in L#?
        /// </summary>
        public string weaponMaterial => string.Empty;

        /// <summary>
        ///     Gets the X Position.
        /// </summary>
        /// <value>
        ///     The X Position.
        /// </value>
        public float x => this.unit.Position.X;

        /// <summary>
        ///     Gets the Y position.
        /// </summary>
        /// <value>
        ///     The Y position.
        /// </value>
        public float y => this.unit.Position.Z;

        /// <summary>
        ///     Gets the Z position.
        /// </summary>
        /// <value>
        ///     The Z Position
        /// </value>
        public float z => this.unit.Position.Y;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Attacks the specified location.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="z">The z.</param>
        /// <returns><c>true</c> if the command was issued sucessfully.</returns>
        public bool Attack(float x, float z)
        {
            return this.unit.Type == GameObjectType.obj_AI_Hero
                   && this.unit.IssueOrder(GameObjectOrder.AttackTo, new Vector3(x, z, 0));
        }

        /// <summary>
        ///     Calculates the damage.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="attackDamage">The attack damage.</param>
        /// <returns></returns>
        public double CalcDamage(Obj_AI_Base obj, double attackDamage)
        {
            return this.unit.CalcDamage(obj, Damage.DamageType.Physical, attackDamage);
        }

        /// <summary>
        ///     Calculates the magic damage.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="magicalDamage">The magical damage.</param>
        /// <returns></returns>
        public double CalcMagicDamage(Obj_AI_Base obj, double magicalDamage)
        {
            return this.unit.CalcDamage(obj, Damage.DamageType.Magical, magicalDamage);
        }

        /// <summary>
        ///     Determines whether this unit can the specified spell.
        /// </summary>
        /// <param name="spellSlot">The spell slot.</param>
        /// <returns></returns>
        public SpellState CanUseSpell(SpellSlot spellSlot)
        {
            return this.GetSpellInst(spellSlot).State;
        }

        /// <summary>
        ///     Gets the buff.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Buff getBuff(int index)
        {
            // Lua arrays start at 1
            return this.unit.Buffs[index - 1]?.ToLuaBuff();
        }

        /// <summary>
        ///     Gets the distance.
        /// </summary>
        /// <param name="gameObject">The game object.</param>
        /// <returns></returns>
        public double GetDistance(GameObject gameObject)
        {
            return this.unit.Distance(gameObject.Position);
        }

        /// <summary>
        ///     Gets the inventory slot.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        // TODO is this correct?
        public int getInventorySlot(int index)
        {
            return this.getItem(index).id;
        }

        /// <summary>
        ///     Gets the item.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public LuaItem getItem(int index)
        {
            return this.unit.InventoryItems[index].ToLuaItem();
        }

        /// <summary>
        ///     Gets the spell data.
        /// </summary>
        /// <param name="spellSlot">The spell slot.</param>
        /// <returns></returns>
        public Spell GetSpellData(SpellSlot spellSlot)
        {
            return this.GetSpellInst(spellSlot).ToLuaSpell();
        }

        /// <summary>
        ///     Holds the position.
        /// </summary>
        /// <returns></returns>
        public bool HoldPosition()
        {
            return this.unit.Type == GameObjectType.obj_AI_Hero
                   && this.unit.IssueOrder(GameObjectOrder.HoldPosition, this.unit);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the spell inst.
        /// </summary>
        /// <param name="spellSlot">The spell slot.</param>
        /// <returns></returns>
        private SpellDataInst GetSpellInst(SpellSlot spellSlot)
        {
            return this.unit.Spellbook.GetSpell(spellSlot);
        }

        #endregion
    }
}