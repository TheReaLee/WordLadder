using BluePrism.Core.Classes;
using BluePrism.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BluePrism.Core.Tests")]
namespace BluePrism.Core.Internals
{
    /// <summary>
    /// Internal <see cref="INode"/> implementation.
    /// </summary>
    internal class Node: INode
    {        
        private readonly List<INode> _linkedNodes;

        /// <inheritdoc/>
        public string Word { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<INode> LinkedNodes { get { return this._linkedNodes; }}

        /// <summary>
        /// Default and only constructor that initializes a new <see cref="Node"/> given a word.
        /// </summary>
        /// <param name="word"><inheritdoc cref="Word" path="/summary"/></param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="word"/> is null or empty.</exception>
        public Node(string word)
        {
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(word), word);

            this._linkedNodes = new List<INode>();
            this.Word = word;            
        }

        /// <inheritdoc/>
        public void LinkNode(INode node)
        {
            Argument.IsNotNull(nameof(node), node);

            if (!this._linkedNodes.Contains(node) && node != this)
            {
                this._linkedNodes.Add(node);
            }
        }
    }
}
