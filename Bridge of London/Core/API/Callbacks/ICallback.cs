using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    interface ICallback : ILuaApiProvider
    {
        string AddCallbackLuaFunctionName { get; }

        string DefaultCallbackFunctionName { get; }

        void AddCallback(Closure function);

        void RegisterDefaultCallback(Script script);
    }
}
