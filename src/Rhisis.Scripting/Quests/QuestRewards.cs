using NLua;
using Rhisis.Core.Helpers;
using Rhisis.Core.Structures.Game.Quests;

namespace Rhisis.Scripting.Quests
{
    internal class QuestRewards : IQuestRewards
    {
        private readonly int? _gold;
        private readonly int _minGold;
        private readonly int _maxGold;

        /// <inheritdoc />
        public int Gold => this._gold ?? RandomHelper.Random(this._minGold, this._maxGold);

        /// <summary>
        /// Creates a new <see cref="QuestRewards"/> instance.
        /// </summary>
        /// <param name="questRewardsLuaTable">Quest script rewards section.</param>
        internal QuestRewards(LuaTable questRewardsLuaTable)
        {
            if (questRewardsLuaTable == null)
            {
                return;
            }

            object gold = questRewardsLuaTable[QuestScriptConstants.Gold];

            if (gold != null)
            {
            }
        }
    }
}
