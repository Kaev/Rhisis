namespace Rhisis.Core.Structures.Game.Quests
{
    public interface IQuestScript
    {
        /// <summary>
        /// Gets the quest unique id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the quest name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the quest title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the quest start character.
        /// </summary>
        string StartCharacter { get; }

        /// <summary>
        /// Gets the quest rewards.
        /// </summary>
        IQuestRewards Rewards { get; }
    }
}
