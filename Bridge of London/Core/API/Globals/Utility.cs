namespace BridgeOfLondon.Core.API.Globals
{
    using System;

    using global::BridgeOfLondon.Core.Wrappers;

    using LeagueSharp;
    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    /// <summary>
    ///     Adds the utility API to the lua script.
    /// </summary>
    /// <seealso cref="BridgeOfLondon.Core.API.ILuaApiProvider" />
    internal class Utility : ILuaApiProvider
    {
        #region Public Properties

        /// <summary>
        ///     Gets the mouse position.
        /// </summary>
        /// <value>
        ///     The mouse position.
        /// </value>
        public LuaVector3 mousePos => Game.CursorPos.ToLuaVector3();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            this.AddChatApi(script);
            this.AddGeneralApi(script);
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
            //TODO:
            //Do it properly without OnUpdate?
            Game.OnUpdate += this.UpdateMousePos;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds the chat API.
        /// </summary>
        /// <param name="script">The script.</param>
        private void AddChatApi(Script script)
        {
            script.Globals["PrintChat"] = (Action<string, object[]>)Game.PrintChat;
            script.Globals["SendChat"] = (Action<string, object[]>)Game.Say;
            //BlockChat() missing
        }

        /// <summary>
        ///     Adds the general API.
        /// </summary>
        /// <param name="script">The script.</param>
        private void AddGeneralApi(Script script)
        {
            script.Globals["mousePos"] = this.mousePos;
            script.Globals["GetMyHero"] = new Func<Obj_AI_Hero>(() => ObjectManager.Player);
            script.Globals["GetTickCount"] = new Func<int>(() => Utils.GameTimeTickCount);
            script.Globals["GetLatency"] = new Func<float>(() => Game.Ping);
            script.Globals["GetTarget"] =
                new Func<LuaGameObject>(() => TargetSelector.GetSelectedTarget().ToLuaGameObject());
        }

        /// <summary>
        ///     Updates the mouse position.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void UpdateMousePos(EventArgs args)
        {
            var cursor = Game.CursorPos;
            this.mousePos.x = cursor.X;
            this.mousePos.y = cursor.Z;
            this.mousePos.z = cursor.Y;
        }

        #endregion
    }
}