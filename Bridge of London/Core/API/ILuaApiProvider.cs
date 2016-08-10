namespace BridgeOfLondon.Core.API
{
    using MoonSharp.Interpreter;

    /// <summary>
    /// An interface that is implemented to provide the Lua API to scripts.
    /// </summary>
    internal interface ILuaApiProvider
    {
        #region Public Methods and Operators

        /// <summary>
        /// Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        void AddApi(Script script);

        /// <summary>
        /// Hooks the events.
        /// </summary>
        void HookEvents();

        #endregion
    }
}