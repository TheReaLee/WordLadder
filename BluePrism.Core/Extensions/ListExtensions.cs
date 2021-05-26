using BluePrism.Core.Classes;
using System;
using System.Collections.Generic;

namespace BluePrism.Core.Extensions
{
    /// <summary>
    /// A set of <see cref="IList{T}"/> extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Checks whether the specified <paramref name="word"/> is contained within the list.
        /// </summary>
        /// <param name="list">The list to search.</param>
        /// <param name="word">The word to check.</param>
        /// <param name="stringComparison">The string comparison to use.</param>
        /// <returns>True if is contained, False otherwise.</returns>
        public static bool Contains(this IList<string> list, string word, StringComparison stringComparison)
        {
            Argument.IsNotNull(nameof(stringComparison), stringComparison);

            foreach(string s in list)
            {
                if(s.Equals(word, stringComparison))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
