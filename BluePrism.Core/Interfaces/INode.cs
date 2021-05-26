using System;
using System.Collections.Generic;

namespace BluePrism.Core.Interfaces
{
    /// <summary>
    /// Contract for implementing Nodes.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// The word representing this node.
        /// </summary>
        string Word { get; }

        /// <summary>
        /// A collection of nodes.
        /// </summary>
        IEnumerable<INode> LinkedNodes { get; }

        /// <summary>
        /// Adds a link to the specified node.
        /// </summary>
        /// <param name="node">The node to link with this node.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="node"/> is null.</exception>
        void LinkNode(INode node);
    }
}
