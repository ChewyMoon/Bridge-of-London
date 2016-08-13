// ReSharper disable InconsistentNaming
namespace BridgeOfLondon.Core.Wrappers
{
    using LeagueSharp;
    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    using SharpDX;

    /// <summary>
    ///     Provides extensions to the <see cref="GameObject" /> class.
    /// </summary>
    public static class GameObjectExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Converts the <see cref="GameObject" /> to a Lua <see cref="LuaGameObject" />;
        /// </summary>
        /// <param name="objBase">The object base.</param>
        /// <returns></returns>
        public static LuaGameObject ToLuaGameUnit(this GameObject objBase)
        {
            return new LuaGameObject(objBase);
        }

        #endregion
    }

    /// <summary>
    ///     A Lua wrapper over a <see cref="GameObject" />.
    /// </summary>
    [MoonSharpUserData]
    public class LuaGameObject
    {
        #region Fields

        /// <summary>
        ///     The gameObject
        /// </summary>
        private readonly GameObject gameObject;

        private readonly Obj_AI_Base asAiBase;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LuaGameObject" /> class.
        /// </summary>
        /// <param name="objBase">The object base.</param>
        public LuaGameObject(GameObject objBase)
        {
            this.gameObject = objBase;
            this.asAiBase = objBase as Obj_AI_Base;
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
        public float? ap => this.asAiBase?.TotalMagicalDamage;

        /// <summary>
        ///     Gets the armor.
        /// </summary>
        /// <value>
        ///     The armor.
        /// </value>
        public float? armor => this.asAiBase?.Armor;

        /// <summary>
        ///     Gets the armor material.
        /// </summary>
        /// <value>
        ///     The armor material.
        /// </value>
        public string armorMaterial => this.asAiBase?.ArmorMaterial;

        /// <summary>
        ///     Gets the armor pen.
        /// </summary>
        /// <value>
        ///     The armor pen.
        /// </value>
        public float? armorPen => this.asAiBase?.FlatArmorPenetrationMod;

        /// <summary>
        ///     Gets the armor pen percent.
        /// </summary>
        /// <value>
        ///     The armor pen percent.
        /// </value>
        public float? armorPenPercent => this.asAiBase?.PercentArmorPenetrationMod;

        /// <summary>
        ///     Gets the attack speed.
        /// </summary>
        /// <value>
        ///     The attack speed.
        /// </value>
        public float? attackSpeed => this.asAiBase?.AttackSpeedMod;

        /// <summary>
        ///     Gets a value indicating whether the gameObject is invulnerable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the gameObject is invulnerable; otherwise, <c>false</c>.
        /// </value>
        public bool? bInvulnerable => this.asAiBase?.IsInvulnerable;

        /// <summary>
        ///     Gets a value indicating whether the gameObject is magic imune.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the gameObject is magic imune; otherwise, <c>false</c>.
        /// </value>
        public bool? bMagicImune => this.asAiBase?.MagicImmune;

        /// <summary>
        ///     Gets a value indicating whether the gameObject is physical imune.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the gameObject is physical imune; otherwise, <c>false</c>.
        /// </value>
        public bool? bPhysImune => this.asAiBase?.PhysicalImmune;

        /// <summary>
        ///     Gets a value indicating whether the gameObject is targetable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the gameObject istargetable; otherwise, <c>false</c>.
        /// </value>
        public bool? bTargetable => this.asAiBase?.IsTargetable;

        /// <summary>
        ///     Gets a value indicating whether the gameObject is targetable to team. This implemenation is more than likely not correct.
        /// </summary>
        /// <value>
        ///     <c>true</c> if the gameObject is targetable to team; otherwise, <c>false</c>.
        /// </value>
        public bool? bTargetableToTeam => this.asAiBase?.IsTargetable;

        /// <summary>
        ///     Gets the number of buffs applied to the gameObject
        /// </summary>
        /// <value>
        ///     The buff count.
        /// </value>
        public int? buffCount => this.asAiBase?.Buffs.Length;

        /// <summary>
        ///     Gets a value indicating whether this gameObject can attack.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this gameObject can attack; otherwise, <c>false</c>.
        /// </value>
        public bool? canAttack => this.asAiBase?.CanAttack;

        /// <summary>
        ///     Gets a value indicating whether this gameObject can move.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this gameObject can move; otherwise, <c>false</c>.
        /// </value>
        public bool? canMove => this.asAiBase?.CanMove;

        /// <summary>
        ///     Gets the cool down reduction of the champion.
        /// </summary>
        /// <value>
        ///     The cool down reduction.
        /// </value>
        public float? cdr => this.asAiBase?.FlatCooldownMod;

        /// <summary>
        ///     Gets the charName of the gameObject. Honestly dunno what this is....
        /// </summary>
        public string charName => this.asAiBase?.CharData.BaseSkinName;

        /// <summary>
        ///     Gets a value indicating whether this <see cref="LuaGameObject" /> is controlled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if controlled; otherwise, <c>false</c>.
        /// </value>
        public bool? controlled => this.asAiBase?.PlayerControlled;

        /// <summary>
        ///     Gets the crit chance.
        /// </summary>
        /// <value>
        ///     The crit chance.
        /// </value>
        public float? critChance => this.asAiBase?.FlatCritChanceMod;

        /// <summary>
        ///     Gets the crit damage.
        /// </summary>
        /// <value>
        ///     The crit damage.
        /// </value>
        public float? critDmg => this.asAiBase?.FlatCritDamageMod;

        /// <summary>
        ///     Gets the damage.
        /// </summary>
        /// <value>
        ///     The damage.
        /// </value>
        public float? damage => this.asAiBase?.TotalAttackDamage;

        /// <summary>
        ///     Gets a value indicating whether this <see cref="LuaGameObject" /> is dead.
        /// </summary>
        /// <value>
        ///     <c>true</c> if dead; otherwise, <c>false</c>.
        /// </value>
        public bool? dead => this.gameObject.IsDead;

        /// <summary>
        ///     Gets the death timer.
        /// </summary>
        /// <value>
        ///     The death timer.
        /// </value>
        public float? deathTimer => this.asAiBase?.DeathDuration;

        /// <summary>
        ///     Gets the experience bonus.
        /// </summary>
        /// <value>
        ///     The experience bonus.
        /// </value>
        public float? expBonus => this.asAiBase?.PercentEXPBonus;

        /// <summary>
        ///     Gets the gold.
        /// </summary>
        /// <value>
        ///     The gold.
        /// </value>
        public float? gold => this.asAiBase?.Gold;

        /// <summary>
        ///     TODO
        /// </summary>
        public float? hardness => 0f;

        /// <summary>
        ///     Gets the health.
        /// </summary>
        /// <value>
        ///     The health.
        /// </value>
        public float? health => this.asAiBase?.Health;

        /// <summary>
        ///     Gets the health point? pool.
        /// </summary>
        /// <value>
        ///     The health point? pool.
        /// </value>
        public float? hpPool => this.asAiBase?.FlatHPPoolMod;

        /// <summary>
        ///     Gets the health point? regen.
        /// </summary>
        /// <value>
        ///     The health point? regen.
        /// </value>
        public float? hpRegen => this.asAiBase?.HPRegenRate;

        /// <summary>
        ///     Gets a value indicating whether this instance is an AI. This implemenation may not be correct.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is an AI; otherwise, <c>false</c>.
        /// </value>
        public bool? isAi => !this.asAiBase?.PlayerControlled;

        /// <summary>
        ///     Gets a value indicating whether this instance is asleep.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is asleep; otherwise, <c>false</c>.
        /// </value>
        public bool? isAsleep => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.Asleep);

        /// <summary>
        ///     Gets a value indicating whether this instance is charmed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is charmed; otherwise, <c>false</c>.
        /// </value>
        public bool? isCharmed => this.asAiBase?.IsCharmed;

        /// <summary>
        ///     Gets a value indicating whether this instance is feared.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is feared; otherwise, <c>false</c>.
        /// </value>
        public bool? isFeared => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.Feared);

        /// <summary>
        ///     Gets a value indicating whether this instance is fleeing.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is fleeing; otherwise, <c>false</c>.
        /// </value>
        public bool? isFleeing => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.Fleeing);

        /// <summary>
        ///     Gets a value indicating whether this instance is force render particles.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is force render particles; otherwise, <c>false</c>.
        /// </value>
        public bool? isForceRenderParticles
            => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.ForceRenderParticles);

        /// <summary>
        ///     Gets a value indicating whether this instance is ghosted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is ghosted; otherwise, <c>false</c>.
        /// </value>
        public bool? isGhosted => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.Ghosted);

        /// <summary>
        ///     Gets a value indicating whether this instance is me.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is me; otherwise, <c>false</c>.
        /// </value>
        public bool? isMe => this.gameObject.IsMe;

        /// <summary>
        ///     Gets a value indicating whether this instance is near sight.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is near sight; otherwise, <c>false</c>.
        /// </value>
        public bool? isNearSight => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.NearSight);

        /// <summary>
        ///     Gets a value indicating whether this instance is no render.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is no render; otherwise, <c>false</c>.
        /// </value>
        public bool? isNoRender => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.NoRender);

        /// <summary>
        ///     Gets a value indicating whether this instance is reveal specific Obj_Ai_Base.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is reveal specific Obj_Ai_Base; otherwise, <c>false</c>.
        /// </value>
        public bool? isRevealSpecificUnit
            => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.RevealSpecificUnit);

        /// <summary>
        ///     Gets a value indicating whether this instance is stealthed.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is stealthed; otherwise, <c>false</c>.
        /// </value>
        public bool? isStealthed => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.IsStealth);

        /// <summary>
        ///     Gets a value indicating whether this instance is taunted.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is taunted; otherwise, <c>false</c>.
        /// </value>
        public bool? isTaunted => this.asAiBase?.CharacterState.HasFlag(GameObjectCharacterState.Taunted);

        /// <summary>
        ///     Gets the level.
        /// </summary>
        /// <value>
        ///     The level.
        /// </value>
        public int? level => this.gameObject.Type == GameObjectType.obj_AI_Hero ? ((Obj_AI_Hero)this.gameObject).Level : 0;

        /// <summary>
        ///     Gets the life steal.
        /// </summary>
        /// <value>
        ///     The life steal.
        /// </value>
        public float? lifeSteal => this.asAiBase?.PercentLifeStealMod;

        /// <summary>
        ///     Gets the magic armor.
        /// </summary>
        /// <value>
        ///     The magic armor.
        /// </value>
        public float? magicArmor => this.asAiBase?.SpellBlock;

        /// <summary>
        ///     Gets the magic penetration.
        /// </summary>
        /// <value>
        ///     The magic penetration.
        /// </value>
        public float? magicPen => this.asAiBase?.FlatMagicPenetrationMod;

        /// <summary>
        ///     Gets the magic pen perecent.
        /// </summary>
        /// <value>
        ///     The magic pen perecent.
        /// </value>
        public float? magicPenPerecent => this.asAiBase?.PercentMagicPenetrationMod;

        /// <summary>
        ///     Gets the magic reduction.
        /// </summary>
        /// <value>
        ///     The magic reduction.
        /// </value>
        public float? magicReduction => this.asAiBase?.FlatMagicReduction;

        /// <summary>
        ///     Gets the mana.
        /// </summary>
        /// <value>
        ///     The mana.
        /// </value>
        public float? mana => this.asAiBase?.Mana;

        /// <summary>
        ///     Gets the maximum bounding box.
        /// </summary>
        /// <value>
        ///     The maximum bounding box.
        /// </value>
        public LuaVector3 maxBBox => this.gameObject.BBox.Maximum.ToLuaVector3();

        /// <summary>
        ///     Gets the maximum health.
        /// </summary>
        /// <value>
        ///     The maximum health.
        /// </value>
        public float? maxHealth => this.asAiBase?.MaxHealth;

        /// <summary>
        ///     Gets the maximum mana.
        /// </summary>
        /// <value>
        ///     The maximum mana.
        /// </value>
        public float? maxMana => this.asAiBase?.MaxMana;

        /// <summary>
        ///     Gets the minimum bounding box.
        /// </summary>
        /// <value>
        ///     The minimum bounding box.
        /// </value>
        public LuaVector3 minBBox => this.gameObject.BBox.Minimum.ToLuaVector3();

        /// <summary>
        ///     Gets the mana regen.
        /// </summary>
        /// <value>
        ///     The mana regen.
        /// </value>
        public float? mpRegen => this.asAiBase?.PARRegenRate;

        /// <summary>
        ///     Gets the movement speed of the Obj_AI_Base.
        /// </summary>
        /// <value>
        ///     The movement speed of the Obj_AI_Base.
        /// </value>
        public float? ms => this.asAiBase?.MoveSpeed;

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string name => this.gameObject.Name;

        /// <summary>
        ///     Gets the network identifier.
        /// </summary>
        /// <value>
        ///     The network identifier.
        /// </value>
        public int? networkID => this.gameObject.NetworkId;

        /// <summary>
        ///     Gets the physical reduction.
        /// </summary>
        /// <value>
        ///     The physical reduction.
        /// </value>
        public float? physReduction => this.asAiBase?.FlatPhysicalReduction;

        /// <summary>
        ///     Gets the position.
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public LuaVector3 pos => this.gameObject.Position.ToLuaVector3();

        /// <summary>
        ///     Gets the range.
        /// </summary>
        /// <value>
        ///     The range.
        /// </value>
        public float? range => this.asAiBase?.AttackRange;

        /// <summary>
        ///     TODO
        /// </summary>
        public LuaGameObject spellOwner => this;

        /// <summary>
        ///     Gets the spell vamp.
        /// </summary>
        /// <value>
        ///     The spell vamp.
        /// </value>
        public float? spellVamp => this.asAiBase?.PercentSpellVampMod;

        /// <summary>
        ///     Gets the team.
        /// </summary>
        /// <value>
        ///     The team.
        /// </value>
        public GameObjectTeam team => this.gameObject.Team;

        /// <summary>
        ///     Gets the total damage.
        /// </summary>
        /// <value>
        ///     The total damage.
        /// </value>
        public float? totalDamage => this.asAiBase?.TotalAttackDamage;

        /// <summary>
        ///     Gets the type of the object as string(Bol :roto2:)
        /// </summary>
        public string type => this.gameObject.Type.ToString();

        /// <summary>
        ///     Gets if the hero is visible or not
        /// </summary>
        public bool? visible => this.gameObject.IsVisible;

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
        public float? x => this.gameObject.Position.X;

        /// <summary>
        ///     Gets the Y position.
        /// </summary>
        /// <value>
        ///     The Y position.
        /// </value>
        public float? y => this.gameObject.Position.Z;

        /// <summary>
        ///     Gets the Z position.
        /// </summary>
        /// <value>
        ///     The Z Position
        /// </value>
        public float? z => this.gameObject.Position.Y;

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
            return this.gameObject.Type == GameObjectType.obj_AI_Hero
                   && this.asAiBase.IssueOrder(GameObjectOrder.AttackTo, new Vector3(x,z,0));
        }

        /// <summary>
        ///     Calculates the damage.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="attackDamage">The attack damage.</param>
        /// <returns></returns>
        public double CalcDamage(Obj_AI_Base obj, double attackDamage)
        {
            return this.asAiBase.CalcDamage(obj, Damage.DamageType.Physical, attackDamage);
        }

        /// <summary>
        ///     Calculates the magic damage.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="magicalDamage">The magical damage.</param>
        /// <returns></returns>
        public double CalcMagicDamage(Obj_AI_Base obj, double magicalDamage)
        {
            return this.asAiBase.CalcDamage(obj, Damage.DamageType.Magical, magicalDamage);
        }

        /// <summary>
        ///     Determines whether this gameObject can the specified spell.
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
            return this.asAiBase.Buffs[index - 1]?.ToLuaBuff();
        }

        /// <summary>
        ///     Gets the distance.
        /// </summary>
        /// <param name="gameObject">The game object.</param>
        /// <returns></returns>
        public double GetDistance(GameObject gameObject0)
        {
            return this.gameObject.Position.Distance(gameObject0.Position);
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
            return this.asAiBase.InventoryItems[index].ToLuaItem();
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
        public bool? HoldPosition()
        {
            return this.gameObject.Type == GameObjectType.obj_AI_Hero
                   && this.asAiBase.IssueOrder(GameObjectOrder.HoldPosition, this.gameObject);
        }

        /// <summary>
        /// Moves the gameObject to the given position
        /// </summary>
        /// <param name="x">x coordinate of position</param>
        /// <param name="z">z coordinate of position</param>
        /// <returns></returns>
        public bool? MoveTo(float x, float z)
        {
            return this.gameObject.Type == GameObjectType.obj_AI_Hero
                   && this.asAiBase.IssueOrder(GameObjectOrder.MoveTo, new Vector2(x,z).To3D2());
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
            return this.asAiBase.Spellbook.GetSpell(spellSlot);
        }

        #endregion
    }
}