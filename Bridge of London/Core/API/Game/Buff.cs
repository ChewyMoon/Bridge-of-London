namespace BridgeOfLondon.Core.API.Game
{
    using LeagueSharp;

    using MoonSharp.Interpreter;

    /// <summary>
    /// Provides extensions to the <see cref="BuffInstance"/> class.
    /// </summary>
    public static class BuffInstanceExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts the <see cref="BuffInstance"/> to a Lua buff.
        /// </summary>
        /// <param name="buffInstance">The buff instance.</param>
        /// <returns></returns>
        public static Buff ToLuaBuff(this BuffInstance buffInstance)
        {
            return new Buff(buffInstance);
        }

        #endregion
    }

    /// <summary>
    /// A Lua wrapper for a <see cref="BuffInstance"/>.
    /// </summary>
    [MoonSharpUserData]
    public class Buff
    {
        #region Fields

        /// <summary>
        /// The buff instance
        /// </summary>
        private readonly BuffInstance buffInstance;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Buff"/> class.
        /// </summary>
        /// <param name="buffInstance">The buff instance.</param>
        public Buff(BuffInstance buffInstance)
        {
            this.buffInstance = buffInstance;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public float endT => this.buffInstance.EndTime;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name => this.buffInstance.Name;

        /// <summary>
        /// Gets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public float startT => this.buffInstance.StartTime;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Buff"/> is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if valid; otherwise, <c>false</c>.
        /// </value>
        public bool valid => this.buffInstance.IsValid;

        #endregion
    }
}