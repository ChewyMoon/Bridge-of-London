using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
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
        public bool isAi => false; //maybe .isZombie?

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

        public bool bPhysImune => bInvulnerable;

        public bool bMagicImune => bInvulnerable;

        public bool bTargetable => _unit.IsTargetable;

        /// <summary>
        /// Not Implemented
        /// </summary>
        public bool bTargetableToTeam => true;

        public bool controlled => _unit.PlayerControlled;

        public float cdr => _unit.PercentCooldownMod;

        public float critChange => _unit.Crit;

        public float critDmg => _unit.CritDamageMultiplier;

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

        public Vector3 pos => _unit.ServerPosition;

        public Vector3 minBBox => _unit.BBox.Minimum;

        public Vector3 maxBBox => _unit.BBox.Maximum;

        public string armorMaterial => _unit.ArmorMaterial;

        /// <summary>
        /// TODO:
        /// Does not exist in L#?
        /// </summary>
        public string weaponMaterial => "";

        public float deathTimer => _unit.DeathDuration;

        public bool canAttack => _unit.CanAttack;

        public bool canMove => _unit.CanMove;

        /// <summary>
        /// TODO
        /// </summary>
        public bool isStealthed => !_unit.IsVisible;

        /// <summary>
        /// TODO
        /// </summary>
        public bool isRevealSpecificUnit => false;

        /// <summary>
        /// TODO
        /// </summary>
        public bool isTaunted => false;

        public bool isCharmed => _unit.IsCharmed;

        /// <summary>
        /// TODO
        /// </summary>
        public bool isFeared => false;

        /// <summary>
        /// TODO
        /// </summary>
        public bool isAsleep => false;

        /// <summary>
        /// TODO
        /// </summary>
        public bool isNearSight => false;

        /// <summary>
        /// TODO
        /// </summary>
        public bool isGhosted => false;

        /// <summary>
        /// TODO Probably wrong
        /// </summary>
        public bool isNoRender => !_unit.IsHPBarRendered;

        /// <summary>
        /// TODO proper implementation
        /// </summary>
        public bool isFleeing => !_unit.IsFacing(ObjectManager.Player);

        /// <summary>
        /// TODO proper implementation
        /// </summary>
        public bool isForceRenderParticles => _unit.IsHPBarRendered;

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

        public double CalcDamage(Obj_AI_Base obj, double maxDamage)
        {
            return Math.Min(_unit.CalcDamage(obj, Damage.DamageType.Physical, _unit.TotalAttackDamage), maxDamage);
        }

        //TODO
        public double CalcMagicDamage(Obj_AI_Base obj, double maxMagicDamage)
        {
            return 0d;
        }

        //TODO BolObject
        public object getBuff(int index)
        {
            return _unit.Buffs[index];
        }

        /// <summary>
        /// TODO match bol API
        /// Gets the item id on slot index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>item id</returns>
        public ItemId getInventorySlot(int index)
        {
            return getItem(index).IData.Id;


        }

        /// <summary>
        /// TODO match Bol API
        /// Gets the inventory Slot on slot index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Inventory slot</returns>
        public InventorySlot getItem(int index)
        {
            return _unit.InventoryItems[index];
        }

        public SpellData GetSpellData(SpellSlot spellSlot)
        {
            return _unit.Spellbook.GetSpell(spellSlot).SData;
        }

        public bool CanUseSpell(SpellSlot spellSlot)
        {
            return _unit.Spellbook.CanUseSpell(spellSlot) == SpellState.Ready;
        }

        #endregion

        public GameUnit(Obj_AI_Base objBase)
        {
            _unit = objBase;
        }

    }
}
