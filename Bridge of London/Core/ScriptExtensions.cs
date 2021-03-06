﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeOfLondon.Core
{
    using MoonSharp.Interpreter;

    internal static class ScriptExtensions
    {
        internal static Table CreateEnvironment(this Script script, string envName)
        {
            var envTable = (Table)script.Globals["Environments"];
            if (envTable == null)
            {
                envTable = new Table(script);
                script.Globals["Environments"] = envTable;
            }

            var luaScriptEnv = (Table)envTable[envName];
            
            if (luaScriptEnv == null)
            {
                luaScriptEnv = new Table(script);
                luaScriptEnv.MetaTable = new Table(script);
                luaScriptEnv.MetaTable["__index"] = script.Globals;
                envTable[envName] = luaScriptEnv;
            }

            return luaScriptEnv;
        }
    }
}
