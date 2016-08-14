namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;
    using LeagueSharp;
    using MoonSharp.Interpreter;
    using Core.Wrappers;
    internal class DeleteObjectCallback : Callback
    {
        #region Properties
        public override string AddCallbackLuaFunctionName => "AddDeleteObjCallback";
        public override string DefaultCallbackFunctionName => "OnDeleteObj";
        public override event ScriptFunctionDelegate Callbacks;
        #endregion

        #region Public Methods
        /// <summary>
        /// Hooks the events
        /// </summary>
        public override void HookEvents()
        {
            GameObject.OnDelete += GameObjectOnOnDelete;
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Fired when a game object is deleted.
        /// </summary>
        /// <param name="sender"> The <see cref="GameObject"/> instance that was deleted</param>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GameObjectOnOnDelete(GameObject sender, EventArgs args)
        {
            if (Callbacks == null)
            {
                return;
            }
            var luaObject = sender.ToLuaGameObject();

            foreach (var d in Callbacks.GetInvocationList().ToArray())
            {
                try
                {
                    ((ScriptFunctionDelegate)d)(luaObject);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        #endregion
    }
}
