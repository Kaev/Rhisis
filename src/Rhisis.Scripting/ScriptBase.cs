using NLua;
using System;

namespace Rhisis.Scripting
{
    internal abstract class ScriptBase
    {
        /// <summary>
        /// Gets the script table.
        /// </summary>
        protected LuaTable ScriptTable { get; }

        /// <summary>
        /// Creates a new <see cref="ScriptBase"/> instance.
        /// </summary>
        /// <param name="luaScriptTable">Lua script.</param>
        protected ScriptBase(LuaTable luaScriptTable)
        {
            this.ScriptTable = luaScriptTable;
        }

        /// <summary>
        /// Gets the value of a given script field.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="field">Lua script field.</param>
        /// <returns>Lua script value converted into the target type.</returns>
        protected T GetValue<T>(string field)
        {
            object scriptObject = this.ScriptTable[field];

            return scriptObject != null ? (T)Convert.ChangeType(scriptObject, typeof(T)) : default;
        }
    }
}
