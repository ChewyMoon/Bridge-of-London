using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using MoonSharp.Interpreter;
using SharpDX;

namespace BridgeOfLondon.Core.API.Game
{
     static class SpellDataInstExtensions
    {
         public static Spell ToBolSpell(this SpellDataInst spellDataInst)
        {
            return new Spell(spellDataInst);
        }
    }

    [MoonSharpUserData]
    public class Spell
    {

        #region BolApi members

        private readonly SpellDataInst _spellDataInst;

        public string name => _spellDataInst.Name;

        public int level => _spellDataInst.Level;

        public float mana => _spellDataInst.ManaCost;

        public float cd => _spellDataInst.Cooldown;

        public float currentCd => Math.Max(_spellDataInst.CooldownExpires - LeagueSharp.Game.ClockTime, 0);

        public float range => _spellDataInst.SData.CastRange;

        public Vector3 startPos;
        public Vector3 endPosPos;

        #endregion


        public Spell(SpellDataInst spellDataInst)
        {
            _spellDataInst = spellDataInst;
        }
    }
}
