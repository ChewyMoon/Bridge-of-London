using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    class Callback
    {
        public string DefaultFunction { get; private set; }

        public string AddCallbackLuaName { get; private set; }

        public Action<Closure> AddCallbackFunction { get; private set; }

        public Callback(string defaultFunction, string addCallbackLuaName, Action<Closure> addCallbackFunction)
        {
            DefaultFunction = defaultFunction;
            AddCallbackLuaName = addCallbackLuaName;
            AddCallbackFunction = addCallbackFunction;
        }
    }
}
