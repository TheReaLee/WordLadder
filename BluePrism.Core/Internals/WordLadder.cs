using BluePrism.Core.Classes;
using BluePrism.Core.Interfaces;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BluePrism.Core.Tests")]
namespace BluePrism.Core.Internals
{
    /// <summary>
    /// Internal <see cref="IWordLadder"/> implementation.
    /// </summary>
    internal class WordLadder : IWordLadder
    {
        /// <inheritdoc/>
        public IDictionary<string, INode> Nodes { get; private set; }

        /// <inheritdoc/>
        public string StartWord { get; private set; }

        /// <inheritdoc/>
        public string EndWord { get; private set; }

        /// <inheritdoc/>
        public bool CaseSensitive { get; private set; }

        /// <summary>
        /// Default and only constructor which initializes a new word ladder given a set of parameters.
        /// </summary>
        /// <param name="nodes"><inheritdoc cref="Nodes" path="/summary"/></param>
        /// <param name="startWord"><inheritdoc cref="StartWord" path="/summary"/></param>
        /// <param name="endWord"><inheritdoc cref="EndWord" path="/summary"/></param>
        /// <param name="caseSensitive"><inheritdoc cref="CaseSensitive" path="/summary"/></param>
        public WordLadder(IDictionary<string, INode> nodes, string startWord, string endWord, bool caseSensitive)
        {
            Argument.IsNotNullOrEmpty(nameof(nodes), nodes);
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(startWord), startWord);
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(endWord), endWord);

            this.Nodes = nodes;
            this.StartWord = startWord;
            this.EndWord = endWord;
            this.CaseSensitive = caseSensitive;
        }
    }
}
