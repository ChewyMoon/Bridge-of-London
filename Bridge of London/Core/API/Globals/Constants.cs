using System;
using LeagueSharp;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Globals
{
    internal class Constants : ILuaApiProvider
    {
        public void AddApi(Script script)
        {
            RegisterSpellSlots(script);
            RegisterSpellStates(script);
            RegisterTeam(script);
            RegisterWindow(script);
            RegisterWndProc(script);
        }


        public void HookEvents()
        {
            throw new NotImplementedException();
        }

        private void RegisterSpellStates(Script script)
        {
            script.Globals["READY"] = SpellState.Ready;
            script.Globals["NOTLEARNED"] = SpellState.NotLearned;
            script.Globals["SUPRESSED"] = SpellState.Surpressed;
            script.Globals["COOLDOWN"] = SpellState.Cooldown;
            script.Globals["NOMANA"] = SpellState.NoMana;
            script.Globals["UNKNOWN"] = SpellState.Unknown;
        }

        private void RegisterSpellSlots(Script script)
        {
            script.Globals["_Q"] = SpellSlot.Q;
            script.Globals["_W"] = SpellSlot.W;
            script.Globals["_E"] = SpellSlot.E;
            script.Globals["_R"] = SpellSlot.R;
            script.Globals["SPELL_1"] = SpellSlot.Q;
            script.Globals["SPELL_2"] = SpellSlot.W;
            script.Globals["SPELL_3"] = SpellSlot.E;
            script.Globals["SPELL_4"] = SpellSlot.R;
            script.Globals["ITEM_1"] = SpellSlot.Item1;
            script.Globals["ITEM_2"] = SpellSlot.Item2;
            script.Globals["ITEM_3"] = SpellSlot.Item3;
            script.Globals["ITEM_4"] = SpellSlot.Item4;
            script.Globals["ITEM_5"] = SpellSlot.Item5;
            script.Globals["ITEM_6"] = SpellSlot.Item6;
            script.Globals["RECALL"] = SpellSlot.Recall;
            script.Globals["SUMMONER_1"] = SpellSlot.Summoner1;
            script.Globals["SUMMONER_2"] = SpellSlot.Summoner2;
        }

        /// <summary>
        ///     TODO:
        ///     Check values of GameOnOnWndProc
        /// </summary>
        /// <param name="script"></param>
        private void RegisterWndProc(Script script)
        {
        }

        private void RegisterTeam(Script script)
        {
            script.Globals["TEAM_NONE"] = GameObjectTeam.Unknown;
            script.Globals["TEAM_BLUE"] = GameObjectTeam.Order;
            script.Globals["TEAM_RED"] = GameObjectTeam.Chaos;
            script.Globals["TEAM_NEUTRAL"] = GameObjectTeam.Neutral;
            script.Globals["TEAM_ENEMY"] = ObjectManager.Player.Team == GameObjectTeam.Chaos
                ? GameObjectTeam.Order
                : GameObjectTeam.Chaos;
        }

        private void RegisterWindow(Script script)
        {
            script.Globals["WINDOW_X"] = 0;
            script.Globals["WINDOW_Y"] = 0;
            script.Globals["WINDOW_W"] = Drawing.Width;
            script.Globals["WINDOW_H"] = Drawing.Height;
        }
    }
}