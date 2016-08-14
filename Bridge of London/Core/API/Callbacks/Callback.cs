using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API.Callbacks
{
    class Callback : ICallback
    {
        public virtual string AddCallbackLuaFunctionName { get;}
        public virtual string DefaultCallbackFunctionName { get; }

        public void AddApi(Script script)
        {
            script.Globals[AddCallbackLuaFunctionName] = (Action<Closure>)this.AddCallback;
        }

        public virtual void HookEvents()
        {
        }

        /// <summary>
        ///     Adds the Object callback.
        /// </summary>
        /// <param name="function">The function.</param>
        public virtual void AddCallback(Closure function)
        {
        }

        public void RegisterDefaultCallback(Script script)
        {
            var envs = (Table) script.Globals["Environments"];
            if (envs == null)
            {
                return;
            }

            foreach (var tablePair in envs.Pairs)
            {
                var envTable = (tablePair.Value.Table);
                Console.WriteLine("Registering std calls for " + tablePair.Key);
                var function = envTable[DefaultCallbackFunctionName] as Closure;
                if (function == null)
                {
                    continue;
                }
                AddCallback(function);
            }
        }
    }
}
