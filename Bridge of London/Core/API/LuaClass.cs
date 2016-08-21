using System;
using MoonSharp.Interpreter;

namespace BridgeOfLondon.Core.API
{
    //TODO: Test performance vs LUA implementation
    internal class LuaClass : ILuaApiProvider
    {
        public static readonly string[] MetatableEvents =
        {
            "__index", "__newindex", "__add",
            "__sub", "__mul", "__div", "__mod",
            "__unm", "__concat", "__eq", "__lt ",
            "__le"
        };

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
                ["__call"] = (Func<ScriptExecutionContext, Table, object[], Table>) createInstance
            };
            context.CurrentGlobalEnv[className] = @class;
        }

        private Table createInstance(ScriptExecutionContext context, Table @class, params object[] args)
        {
            var instance = new Table(context.OwnerScript);
            instance.MetaTable = new Table(context.OwnerScript)
            {
                ["__index"] = @class,
            };
            foreach (var @event in MetatableEvents)
            {
                var eventFunction = @class[@event];
                if (eventFunction == null)
                    continue;

                instance.MetaTable[@event] = eventFunction;
            }
            var obs = new object[args.Length + 1];
            obs[0] = instance; //First argument is the "this" pointer/self table
            args.CopyTo(obs, 1);
            ((Closure) @class["__init"]).GetDelegate()(obs);
            return instance;
        }
    }
}