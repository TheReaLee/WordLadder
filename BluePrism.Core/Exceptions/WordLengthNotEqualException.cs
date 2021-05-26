using BluePrism.Core.Classes;
using System;

namespace BluePrism.Core.Exceptions
{
    /// <summary>
    /// Represents a word length exception that occurs within the <see cref="WordLadderEngine"/>
    /// </summary>
    public class WordLengthNotEqualException : Exception
    {
        /// <summary>
        /// Initializes a new word length exception.
        /// </summary>
        /// <param name="startWord">The start word.</param>
        /// <param name="endWord">The end word</param>
        public WordLengthNotEqualException(string startWord, string endWord)
            : base($"The start [{startWord?.Length}] and end words [{endWord?.Length}] are not equal in length.") { }
    }
}
