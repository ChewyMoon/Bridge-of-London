﻿namespace BridgeOfLondon.Core
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

            Script.WarmUp();
            UserData.RegisterAssembly(Assembly.GetExecutingAssembly());

            foreach (var luaScript in Directory.GetFiles(this.Config.ScriptDirectory))
            {
                try
                {
                    var script = new Script(this.Config.SandboxLevel);

                    LuaApiManager.AddApi(script);

                    ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new[] { "Common/?", "Common/?.lua" };
                    ((ScriptLoaderBase)script.Options.ScriptLoader).IgnoreLuaPathGlobal = true;

                    script.DoFile(luaScript);

                    this.Scripts.Add(script);
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