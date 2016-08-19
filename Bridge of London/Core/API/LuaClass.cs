using System;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API
{
    internal class LuaClass : ILuaApiProvider
    {
        public void AddApi(Script script)
        {
            script.Globals["class"] = (Action<ScriptExecutionContext, string>) CreateClass;
        }

        public void HookEvents()
        {
        }

        //https://groups.google.com/forum/#!topic/moonsharp/gh8c-lwG8o8
        public void CreateClass(ScriptExecutionContext context, string className)
        {
            var @class = new Table(context.OwnerScript);

            var f = new Func<Table, DynValue[], Table>(
                (self, args) =>
                {
                    var instance = new Table(context.OwnerScript);
                    instance.MetaTable = new Table(context.OwnerScript)
                    {
                        ["self"] = new Table(context.OwnerScript),
                        ["__index"] = context.CurrentGlobalEnv[className],
                        ["__call"] = null
                    };
                    context.Call((DynValue) instance["__init"], args);
                    return instance;
                });

            @class.MetaTable = new Table(context.OwnerScript)
            {
                ["__call"] = f
            };
        }
    }
}