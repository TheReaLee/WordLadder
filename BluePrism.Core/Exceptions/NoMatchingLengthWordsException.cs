using BluePrism.Core.Interfaces;
using System;

namespace BluePrism.Core.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when a collection of words does not contain a matching length word.
    /// </summary>
    /// <remarks><see cref="IWordLadderImporter"/></remarks>
    public class NoMatchingLengthWordsException : Exception
    {
        /// <summary>
        /// Initializes a new no matching length words exception.
        /// </summary>
        /// <param name="requiredWordLength">The required length.</param>
        public NoMatchingLengthWordsException(int requiredWordLength)
            : base($"The specified collection/dictionary has no matching words in length [{requiredWordLength}].") { }
    }
}