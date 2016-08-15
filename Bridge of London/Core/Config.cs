namespace BridgeOfLondon.Core
{
    using System;
    using System.IO;

    using LeagueSharp.Common;

    using MoonSharp.Interpreter;

    internal class Config
    {
        #region Public Properties

        /// <summary>
        ///     Gets the library directory.
        /// </summary>
        /// <value>
        ///     The library directory.
        /// </value>
        public string LibraryDirectory => Path.Combine(this.ScriptDirectory, "Common");

        /// <summary>
        ///     Gets or sets the menu.
        /// </summary>
        /// <value>
        ///     The menu.
        /// </value>
        public Menu Menu { get; set; }

        /// <summary>
        ///     Gets the sandbox level.
        /// </summary>
        /// <value>
        ///     The sandbox level.
        /// </value>
        public CoreModules SandboxLevel
        {
            get
            {
                switch (this["SandboxLevel"].GetValue<StringList>().SelectedIndex)
                {
                    case 0:
                        return CoreModules.Preset_HardSandbox;
                    case 1:
                        return CoreModules.Preset_SoftSandbox;
                    case 2:
                        return CoreModules.Preset_Default;
                    case 3:
                        return CoreModules.Preset_Complete;
                    default:
                        return CoreModules.Preset_Default;
                }
            }
        }

        /// <summary>
        ///     Gets the script directory.
        /// </summary>
        /// <value>
        ///     The script directory.
        /// </value>
        public string ScriptDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lua Scripts");

        #endregion

        #region Public Indexers

        /// <summary>
        ///     Gets the <see cref="MenuItem" /> with the specified item name.
        /// </summary>
        /// <value>
        ///     The <see cref="MenuItem" />.
        /// </value>
        /// <param name="itemName">Name of the item.</param>
        /// <returns></returns>
        public MenuItem this[string itemName] => this.Menu.Item(itemName);

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Loads this instance.
        /// </summary>
        public void Load()
        {
            this.Menu = new Menu("Bridge of London", "BridgeOfLondon_RB", true);

            this.Menu.AddItem(
                new MenuItem("SandboxLevel", "Sandbox Level").SetValue(
                    new StringList(new[] { "Hard", "Soft", "Default", "Unrestricted" }, 2)));

            this.Menu.AddItem(
                new MenuItem("ScriptPath", "Lua script path")).SetTooltip(ScriptDirectory);

            this.Menu.AddItem(
                new MenuItem("LibPath", "Library Script path")).SetTooltip(LibraryDirectory);

            this.Menu.AddToMainMenu();
        }

        #endregion
    }
}