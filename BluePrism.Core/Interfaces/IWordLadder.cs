using System.Collections.Generic;

namespace BluePrism.Core.Interfaces
{
    /// <summary>
    /// Contract for implementing word ladders.
    /// </summary>
    public interface IWordLadder
    {
        /// <summary>
        /// A dictionary of nodes representing the word ladder.
        /// </summary>
        IDictionary<string, INode> Nodes { get; }

        /// <summary>
        /// The start word.
        /// </summary>
        string StartWord { get; }

        /// <summary>
        /// The end word.
        /// </summary>
        string EndWord { get; }

        /// <summary>
        /// Whether case sensitivity was enabled or not during import.
        /// </summary>
        bool CaseSensitive { get; }
    }
}
