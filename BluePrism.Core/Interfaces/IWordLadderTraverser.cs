using BluePrism.Core.Exceptions;
using System;

namespace BluePrism.Core.Interfaces
{
    /// <summary>
    /// Contract for implementing word ladder traversers.
    /// </summary>
    /// <remarks>Utilize <see cref="IWordLadderImporter"/> to import and construct nodes.</remarks>
    public interface IWordLadderTraverser
    {
        /// <summary>
        /// Traverses the specified word ladder.
        /// </summary>
        /// <param name="wordLadder">The word ladder to traverse.</param>        
        /// <returns>The traversal result.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="wordLadder"/> is null, or nodes are null, or start word or end word are null or empty.</exception>                        
        /// <exception cref="WordLengthNotEqualException">Thrown if the start word contained in <paramref name="wordLadder"/> is not equal to the end word in length.</exception>
        IWordLadderTraversalResult Traverse(IWordLadder wordLadder); 
    }    
}