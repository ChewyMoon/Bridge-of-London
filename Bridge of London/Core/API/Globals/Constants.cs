namespace BridgeOfLondon.Core.API.Globals
{
    using System;

    using LeagueSharp;
    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    /// <summary>
    /// Adds constant values to the Lua script.
    /// </summary>
    /// <seealso cref="BridgeOfLondon.Core.API.ILuaApiProvider" />
    internal class Constants : ILuaApiProvider
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            this.RegisterSpellSlots(script);
            this.RegisterSpellStates(script);
            this.RegisterTeam(script);
            this.RegisterWindow(script);
            this.RegisterWndProc(script);
            this.RegisterPingCategory(script);
            script.Globals["LeagueSharp"] = true;
        }

        /// <summary>
        /// Hooks the events.
        /// </summary>
        public void HookEvents()
        {
            
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers the ping category.
        /// </summary>
        /// <param name="script">The script.</param>
        private void RegisterPingCategory(Script script)
        {
            script.Globals["PING_ASSISTME"] = PingCategory.AssistMe;
            script.Globals["PING_DANGER"] = PingCategory.Danger;
            script.Globals["PING_ENEMYMISSING"] = PingCategory.EnemyMissing;
            script.Globals["PING_FALLBACK"] = PingCategory.Fallback;
            script.Globals["PING_NORMAL"] = PingCategory.Normal;
            script.Globals["PING_ONMYWAY"] = PingCategory.OnMyWay;
        }

        /// <summary>
        /// Registers the spell slots.
        /// </summary>
        /// <param name="script">The script.</param>
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
        /// Registers the spell states.
        /// </summary>
        /// <param name="script">The script.</param>
        private void RegisterSpellStates(Script script)
        {
            script.Globals["READY"] = SpellState.Ready;
            script.Globals["NOTLEARNED"] = SpellState.NotLearned;
            script.Globals["SUPRESSED"] = SpellState.Surpressed;
            script.Globals["COOLDOWN"] = SpellState.Cooldown;
            script.Globals["NOMANA"] = SpellState.NoMana;
            script.Globals["UNKNOWN"] = SpellState.Unknown;
        }

        /// <summary>
        /// Registers the team.
        /// </summary>
        /// <param name="script">The script.</param>
        private void RegisterTeam(Script script)
        {
            script.Globals["TEAM_NONE"] = GameObjectTeam.Unknown;
            script.Globals["TEAM_BLUE"] = GameObjectTeam.Order;
            script.Globals["TEAM_RED"] = GameObjectTeam.Chaos;
            script.Globals["TEAM_NEUTRAL"] = GameObjectTeam.Neutral;
            script.Globals["TEAM_ENEMY"] = ObjectManager.Player?.Team == GameObjectTeam.Chaos
                                               ? GameObjectTeam.Order
                                               : GameObjectTeam.Chaos;
        }

        /// <summary>
        /// Registers the window.
        /// </summary>
        /// <param name="script">The script.</param>
        private void RegisterWindow(Script script)
        {
            script.Globals["WINDOW_X"] = 0;
            script.Globals["WINDOW_Y"] = 0;
            script.Globals["WINDOW_W"] = Drawing.Width;
            script.Globals["WINDOW_H"] = Drawing.Height;
        }

        /// <summary>
        /// Registers the codes that the window will process.
        /// </summary>
        /// <param name="script">The script.</param>
        private void RegisterWndProc(Script script)
        {
            script.Globals["KEY_DOWN"] = 0x100;
            script.Globals["KEY_UP"] = 0x101;
            script.Globals["WM_MOUSEMOVE"] = 0x200;
            script.Globals["WM_LBUTTONDOWN"] = 0x201;
            script.Globals["WM_LBUTTONUP"] = 0x202;
            script.Globals["WM_RBUTTONDOWN"] = 0x204;
            script.Globals["WM_RBUTTONUP"] = 0x205;
        }

        #endregion
    }
}