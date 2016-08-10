using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BridgeOfLondon.Core.API.Helpers;
using LeagueSharp;
using LeagueSharp.Common;
using MoonSharp.Interpreter;
using SharpDX;

// ReSharper disable InconsistentNaming

namespace BridgeOfLondon.Core.API.Game
{
    public static class Obj_Ai_BaseExtension
    {
        public static GameUnit ToBolGameUnit(this Obj_AI_Base objBase)
        {
            return new GameUnit(objBase);
        }
    }

    [MoonSharpUserData]
    public class GameUnit
    {
        private readonly Obj_AI_Base _unit;

        #region public properties


        /// <summary>
        /// Gets the name of the unit
        /// </summary>
        public string name => _unit.Name;

        /// <summary>
        /// Gets the charName of the unit. Honestly dunno what this is....
        /// </summary>
        public string charName => _unit.CharData.BaseSkinName;

        /// <summary>
        /// Gets the level of the hero.
        /// </summary>
        public int level
        {
            get
            {
                if (_unit.Type == GameObjectType.obj_AI_Hero)
                {
                    return ((Obj_AI_Hero) _unit).Level;
                }
                return 0;
            }
        }

        /// <summary>
        /// Gets if the hero is visible or not
        /// </summary>
        public bool visible => _unit.IsVisible;

        /// <summary>
        /// Gets the type of the object as string(Bol :roto2:)
        /// </summary>
        public string type => _unit.Type.ToString();

        /// <summary>
        /// Gets the X position
        /// </summary>
        public float x => _unit.Position.X;

        /// <summary>
        /// Gets the Y position(in bol Y and Z are switched ayyy)
        /// </summary>
        public float y => _unit.Position.Z;

        /// <summary>
        /// Gets the Z position(in bol Y and Z are switched ayyy)
        /// </summary>
        public float z => _unit.Position.Y;

        /// <summary>
        /// Returns False not sure how this is implemented in L#
        /// </summary>
        public bool isAi => !_unit.PlayerControlled; //maybe .isZombie?

        /// <summary>
        /// Returns true if the unit is the local player
        /// </summary>
        public bool isMe => _unit.IsMe;

        /// <summary>
        /// Return the number of buffs applied to the unit
        /// </summary>
        public int buffCount => _unit.Buffs.Length;

        /// <summary>
        /// Gets the unit total Attack damage
        /// </summary>
        public float totalDamage => _unit.TotalAttackDamage;

        /// <summary>
        /// returns true if the unit is dead
        /// </summary>
        public bool dead => _unit.IsDead;

        /// <summary>
        /// Gets the team
        /// TODO: Implement TEAM_BLUE TEAM_RED TEAM_NEUTRAL
        /// </summary>
        public GameObjectTeam team => _unit.Team;

        /// <summary>
        /// Gets the Unit networkID(in bol this is a float but I think it's fine treating the same way as L#)
        /// </summary>
        public int networkID => _unit.NetworkId;

        public float health => _unit.Health;

        public float maxHealth => _unit.MaxHealth;

        public float mana => _unit.Mana;

        public float maxMana => _unit.MaxMana;

        public bool bInvulnerable => _unit.IsInvulnerable;

        public bool bPhysImune => _unit.PhysicalImmune;

        public bool bMagicImune => _unit.MagicImmune;

        public bool bTargetable => _unit.IsTargetable;

        /// <summary>
        /// Not Implemented
        /// </summary>
        public bool bTargetableToTeam => _unit.IsValidTarget(float.MaxValue, false) && _unit.IsAlly;

        public bool controlled => _unit.PlayerControlled;

        public float cdr => _unit.FlatCooldownMod;

        public float critChange => _unit.FlatCritChanceMod;

        public float critDmg => _unit.FlatCritDamageMod;

        public float hpPool => _unit.FlatHPPoolMod;

        public float hpRegen => _unit.HPRegenRate;

        public float mpRegen => _unit.PARRegenRate;

        public float attackSpeed => _unit.AttackSpeedMod;

        public float expBonus => _unit.PercentEXPBonus;

        /// <summary>
        /// TODO
        /// </summary>
        public float hardness => 0f;

        public float lifeSteal => _unit.PercentLifeStealMod;

        public float spellVamp => _unit.PercentSpellVampMod;

        public float physReduction => _unit.FlatPhysicalReduction;

        public float magicReduction => _unit.FlatMagicReduction;

        public float armorPen => _unit.FlatArmorPenetrationMod;

        public float magicPen => _unit.FlatMagicPenetrationMod;

        public float armorPenPercent => _unit.PercentArmorPenetrationMod;

        public float magicPenPerecent => _unit.PercentMagicPenetrationMod;

        /// <summary>
        /// TODO
        /// </summary>
        public float addDamage => 0f;

        public float ap => _unit.TotalMagicalDamage;

        public float damage => _unit.TotalAttackDamage;

        public float armor => _unit.Armor;

        /// <summary>
        /// No idea what's the equivalent
        /// </summary>
        public float magicArmor => _unit.FlatMagicReduction;

        public float ms => _unit.MoveSpeed;

        public float range => _unit.AttackRange;

        public float gold => _unit.Gold;

        public BolVector pos => _unit.Position.ToBolVector();

        public BolVector minBBox => _unit.BBox.Minimum.ToBolVector();

        public BolVector maxBBox => _unit.BBox.Maximum.ToBolVector();

        public string armorMaterial => _unit.ArmorMaterial;

        /// <summary>
        /// TODO:
        /// Does not exist in L#?
        /// </summary>
        public string weaponMaterial => "";

        public float deathTimer => _unit.DeathDuration;

        public bool canAttack => _unit.CanAttack;

        public bool canMove => _unit.CanMove;

        public bool isStealthed => _unit.CharacterState.HasFlag(GameObjectCharacterState.IsStealth);

        public bool isRevealSpecificUnit => _unit.CharacterState.HasFlag(GameObjectCharacterState.RevealSpecificUnit);

        public bool isTaunted => _unit.CharacterState.HasFlag(GameObjectCharacterState.Taunted);

        public bool isCharmed => _unit.IsCharmed;

        public bool isFeared => _unit.CharacterState.HasFlag(GameObjectCharacterState.Feared);

        public bool isAsleep => _unit.CharacterState.HasFlag(GameObjectCharacterState.Asleep);

        public bool isNearSight => _unit.CharacterState.HasFlag(GameObjectCharacterState.NearSight);

        public bool isGhosted => _unit.CharacterState.HasFlag(GameObjectCharacterState.Ghosted);

        public bool isNoRender => _unit.CharacterState.HasFlag(GameObjectCharacterState.NoRender);

        public bool isFleeing => _unit.CharacterState.HasFlag(GameObjectCharacterState.Fleeing);

        public bool isForceRenderParticles => _unit.CharacterState.HasFlag(GameObjectCharacterState.ForceRenderParticles);

        /// <summary>
        /// TODO 
        /// </summary>
        public GameUnit spellOwner => this;

        #endregion

        #region BOLAPI Methods


        public bool HoldPosition()
        {
            if (_unit.Type != GameObjectType.obj_AI_Hero)
            {
                return false;
            }
            return _unit.IssueOrder(GameObjectOrder.HoldPosition, _unit);
        }

        public bool Attack(float x, float z)
        {
            if (_unit.Type != GameObjectType.obj_AI_Hero)
            {
                return false;
            }
            return _unit.IssueOrder(GameObjectOrder.AttackTo, new Vector3(x, z, 0));
        }

        public double GetDistance(GameObject gameObject)
        {
            return _unit.Distance(gameObject.Position);
        }

        public double CalcDamage(Obj_AI_Base obj, double attackDamage)
        {
            return _unit.CalcDamage(obj, Damage.DamageType.Physical, attackDamage);
        }

        //TODO
        public double CalcMagicDamage(Obj_AI_Base obj, double magicalDamage)
        {
            return _unit.CalcDamage(obj, Damage.DamageType.Magical, magicalDamage);
        }

        //TODO BolObject
        public object getBuff(int index)
        {
            return _unit.Buffs[index];
        }

        /// <summary>
        /// Gets the item id on slot index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>item id</returns>
        public int getInventorySlot(int index)
        {
            return getItem(index).id;
        }

        /// <summary>
        /// Gets the inventory Slot on slot index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Inventory slot</returns>
        public LoLItem getItem(int index)
        {
            return _unit.InventoryItems[index].ToBolLoLItem();
        }

        private SpellDataInst GetSpellInst(SpellSlot spellSlot)
        {
            return _unit.Spellbook.GetSpell(spellSlot);
        }
        public Spell GetSpellData(SpellSlot spellSlot)
        {
            return GetSpellInst(spellSlot).ToBolSpell();
        }

        public bool CanUseSpell(SpellSlot spellSlot)
        {
            return GetSpellInst(spellSlot).IsReady();
        }

        #endregion

        public GameUnit(Obj_AI_Base objBase)
        {
            _unit = objBase;
        }

    }
}
