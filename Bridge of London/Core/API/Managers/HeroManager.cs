namespace BridgeOfLondon.Core.API.Managers
{
    using System.Linq;

    using global::BridgeOfLondon.Core.Wrappers;

    using LeagueSharp;

    using MoonSharp.Interpreter;

    /// <summary>
    /// Adds HeroManager's API to a lua script.
    /// </summary>
    /// <seealso cref="BridgeOfLondon.Core.API.ILuaApiProvider" />
    internal class HeroManager : ILuaApiProvider
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Adds the API.
        /// </summary>
        /// <param name="script">The script.</param>
        public void AddApi(Script script)
        {
            script.Globals["heroManager"] = new HeroManagerImpl();
            script.Globals["myHero"] = ObjectManager.Player.ToLuaGameUnit();
        }

        /// <summary>
        ///     Hooks the events.
        /// </summary>
        public void HookEvents()
        {
        }

        #endregion
    }

    /// <summary>
    /// The lua implemenation of HeroManager.
    /// </summary>
    [MoonSharpUserData]
    internal class HeroManagerImpl
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HeroManagerImpl" /> class.
        /// </summary>
        public HeroManagerImpl()
        {
            this.Heroes = ObjectManager.Get<Obj_AI_Hero>().Select(x => new LuaGameObject(x)).ToArray();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the number of heroes.
        /// </summary>
        /// <value>
        ///     The number of heroes.
        /// </value>
        public int iCount => this.Heroes.Count();

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the heroes.
        /// </summary>
        /// <value>
        ///     The heroes.
        /// </value>
        [MoonSharpHidden]
        private LuaGameObject[] Heroes { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Gets the hero.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public LuaGameObject getHero(int index)
        {
            return this.Heroes[index - 1];
        }

        #endregion
    }
}