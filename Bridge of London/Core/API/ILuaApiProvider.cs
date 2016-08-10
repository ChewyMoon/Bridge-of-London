﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API
{
    interface ILuaApiProvider
    {
        void AddApi(Script script);
        void HookEvents();
    }
}
