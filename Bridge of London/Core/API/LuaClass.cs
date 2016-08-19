using System;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API
{
    //TODO: Test performance vs LUA implementation
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

            @class.MetaTable = new Table(context.OwnerScript)
            {
                ["__call"] = (Func<ScriptExecutionContext, Table, object[], Table>)createInstance
            };
            context.CurrentGlobalEnv[className] = @class;
        }

        private Table createInstance(ScriptExecutionContext context, Table @class, params object[] args)
        {
            var instance = new Table(context.OwnerScript);
            instance.MetaTable = new Table(context.OwnerScript)
            {
                ["self"] = new Table(context.OwnerScript),
                ["__index"] = @class,
                ["__call"] = null
            };
            DynValue[] dynValues = new DynValue[args.Length + 1];
            dynValues[0] = DynValue.NewTable(instance); //First argument is self
            for (int i = 0; i < args.Length; i++)
            {
                dynValues[i + 1] = DynValue.FromObject(context.OwnerScript, args[i]); //Bottleneck?
            }
            ((Closure)@class["__init"]).GetDelegate()(dynValues);
            return instance;
        }
    }
}