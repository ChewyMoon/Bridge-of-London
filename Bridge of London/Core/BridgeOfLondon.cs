namespace BridgeOfLondon.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using MoonSharp.Interpreter;

    /// <summary>
    ///     Bridge of London
    /// </summary>
    internal class BridgeOfLondon
    {
        #region Public Properties

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static BridgeOfLondon Instance { get; } = new BridgeOfLondon();

        /// <summary>
        ///     Gets all scripts.
        /// </summary>
        /// <value>
        ///     All scripts.
        /// </value>
        // TODO Optimize this
        public IEnumerable<Script> AllScripts => this.Scripts.Concat(this.Libraries);

        /// <summary>
        ///     Gets or sets the configuration.
        /// </summary>
        /// <value>
        ///     The configuration.
        /// </value>
        public Config Config { get; set; }

        /// <summary>
        ///     Gets the libraries.
        /// </summary>
        /// <value>
        ///     The libraries.
        /// </value>
        public List<Script> Libraries { get; } = new List<Script>();

        /// <summary>
        ///     Gets the scripts.
        /// </summary>
        /// <value>
        ///     The scripts.
        /// </value>
        public List<Script> Scripts { get; } = new List<Script>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Raises the <see cref="E:Load" /> event.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public void OnLoad(EventArgs args)
        {
            this.Config = new Config();
            this.Config.Load();

            this.LoadScripts();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Loads the scripts.
        /// </summary>
        private void LoadScripts()
        {
            if (!Directory.Exists(this.Config.ScriptDirectory))
            {
                Directory.CreateDirectory(this.Config.ScriptDirectory);
            }

            if (!Directory.Exists(this.Config.LibraryDirectory))
            {
                Directory.CreateDirectory(this.Config.LibraryDirectory);
            }

            UserData.RegisterAssembly(Assembly.GetExecutingAssembly());
        }

        #endregion
    }
}