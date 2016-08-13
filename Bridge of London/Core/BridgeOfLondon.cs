namespace BridgeOfLondon.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    using global::BridgeOfLondon.Core.API;

    using LeagueSharp;

    using MoonSharp.Interpreter;
    using MoonSharp.Interpreter.Loaders;

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
        ///     Gets or sets the configuration.
        /// </summary>
        /// <value>
        ///     The configuration.
        /// </value>
        public Config Config { get; set; }

        /// <summary>
        ///     Gets the scripts.
        /// </summary>
        /// <value>
        ///     The scripts.
        /// </value>
        public List<Script> Scripts { get; } = new List<Script>();

        /// <summary>
        ///     Gets or sets the lua virtual machine
        /// </summary>
        /// <value>
        ///     The Lua Virtual Machine
        /// </value>
        public Script LuaVM;

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



            try
            {
                Script.WarmUp();
                UserData.RegisterAssembly(Assembly.GetExecutingAssembly());

                LuaVM = new Script(this.Config.SandboxLevel);

                ((ScriptLoaderBase)LuaVM.Options.ScriptLoader).ModulePaths = new[] { "Common/?", "Common/?.lua" };
                ((ScriptLoaderBase)LuaVM.Options.ScriptLoader).IgnoreLuaPathGlobal = true;
            }
            catch (Exception e)
            {
                PrintMessage("Failed to create Lua Virtual Machine. See Console for details");
                Console.WriteLine(e);
                return;
            }

            try
            {
                LuaApiManager.AddApi(LuaVM);
            }
            catch (Exception e)
            {
                PrintMessage("Failed to register API. See Console for details");
                Console.WriteLine(e);
                return;
            }

            this.LoadScripts();
        }

        /// <summary>
        ///     Prints the message.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        public void PrintMessage(string format, params object[] args)
        {
            Game.PrintChat(
                "<font color=\"#3399FF\"><b>Bridge of London:</b></font> <font color=\"#FFFFFF\">"
                + string.Format(format, args) + "</font>");
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

            foreach (var luaScript in Directory.GetFiles(this.Config.ScriptDirectory))
            {
                try
                {
                    Console.WriteLine($"Loading {luaScript}");
                    LuaVM.DoFile(luaScript, LuaVM.CreateEnvironment(luaScript));

                    //this.Scripts.Add(script);
                }
                catch (Exception e)
                {
                    this.PrintMessage(
                        "Error attempting to load \"{0}\". Check console for details.", 
                        Path.GetFileName(luaScript));
                    Console.WriteLine(e);
                }
            }
        }

        #endregion
    }
}