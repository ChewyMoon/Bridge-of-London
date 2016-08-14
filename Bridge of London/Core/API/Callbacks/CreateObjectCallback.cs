namespace BridgeOfLondon.Core.API.Callbacks
{
    using System;
    using System.Linq;
    using LeagueSharp;
    using MoonSharp.Interpreter;
    using Core.Wrappers;
    internal class CreateObjectCallback : Callback
    {
        #region Properties
        public override string AddCallbackLuaFunctionName => "AddCreateObjCallback";
        public override string DefaultCallbackFunctionName => "OnCreateObj"; 
        public  event ScriptFunctionDelegate Callbacks;
        #endregion

        #region Public Methods
        /// <summary>
        /// Hooks the events
        /// </summary>
        public override void HookEvents()
        {
            GameObject.OnCreate += GameObjectOnOnCreate;
        }

        public override void AddCallback(Closure function)
        {
            Callbacks += function.GetDelegate();
        }
        #endregion

        #region Methods
        /// <summary>
        ///     Fired when a game object is created.
        /// </summary>
        /// <param name="sender"> The <see cref="GameObject"/> instance that was created</param>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void GameObjectOnOnCreate(GameObject sender, EventArgs args)
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
