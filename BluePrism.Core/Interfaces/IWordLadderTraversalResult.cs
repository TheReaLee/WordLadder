using System.Collections.Generic;

namespace BluePrism.Core.Interfaces
{
    /// <summary>
    /// Contract for implementing word ladder traversal results.
    /// </summary>
    public interface IWordLadderTraversalResult
    {
        /// <summary>
        /// The word ladder used during the traversal.
        /// </summary>
        IWordLadder WordLadder { get; }

        /// <summary>
        /// A collection of words representing the shortest result/path.
        /// </summary>
        IEnumerable<string> ResultedWords { get; }
    }
}
