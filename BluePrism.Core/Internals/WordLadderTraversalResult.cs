using BluePrism.Core.Classes;
using BluePrism.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BluePrism.Core.Tests")]
namespace BluePrism.Core.Internals
{
    /// <summary>
    /// Internal <see cref="IWordLadderTraversalResult"/> implementation.
    /// </summary>
    internal class WordLadderTraversalResult : IWordLadderTraversalResult
    {
        /// <inheritdoc/>
        public IWordLadder WordLadder { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<string> ResultedWords { get; private set; }

        /// <summary>
        /// Default and only constructor that initialize a new WordLadderTraversalResult given a set of parameters.
        /// </summary>
        /// <param name="wordLadder"><inheritdoc cref="WordLadder" path="/summary"/></param>
        /// <param name="resultedWords"><inheritdoc cref="ResultedWords" path="/summary"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="wordLadder"/> or <paramref name="resultedWords"/> is null.</exception>        
        public WordLadderTraversalResult(IWordLadder wordLadder, IEnumerable<string> resultedWords)
        {
            Argument.IsNotNull(nameof(wordLadder), wordLadder);
            Argument.IsNotNull(nameof(resultedWords), resultedWords);

            this.WordLadder = wordLadder;
            this.ResultedWords = resultedWords;
        }
    }
}
