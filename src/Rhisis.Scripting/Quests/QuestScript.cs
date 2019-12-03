using NLua;
using Rhisis.Core.Structures.Game.Quests;

namespace Rhisis.Scripting.Quests
{
    internal class QuestScript : ScriptBase, IQuestScript
    {
        /// <inheritdoc />
        public int Id { get; private set; }

        /// <inheritdoc />
        public string Name { get; private set; }

        /// <inheritdoc />
        public string Title { get; private set; }

        /// <inheritdoc />
        public string StartCharacter { get; private set; }

        /// <inheritdoc />
        public IQuestRewards Rewards { get; private set; }

        /// <summary>
        /// Creates a new <see cref="QuestScript"/> instance.
        /// </summary>
        /// <param name="questId">Quest id.</param>
        /// <param name="questName">Quest name.</param>
        /// <param name="luaScriptTable">Lua script table.</param>
        public QuestScript(int questId, string questName, LuaTable luaScriptTable)
            : base(luaScriptTable)
        {
            this.Id = questId;
            this.Name = questName;
            this.Title = this.GetValue<string>(QuestScriptConstants.Title);
            this.StartCharacter = this.GetValue<string>(QuestScriptConstants.StartCharacter);
            this.Rewards = new QuestRewards(this.ScriptTable[QuestScriptConstants.Rewards] as LuaTable);
        }
    }
}
