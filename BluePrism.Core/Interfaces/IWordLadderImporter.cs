using BluePrism.Core.Exceptions;
using System;
using System.IO;

namespace BluePrism.Core.Interfaces
{
    /// <summary>
    /// Contract for implementing word ladder importers.
    /// </summary>
    public interface IWordLadderImporter
    {
        /// <summary>
        /// Imports the specified <paramref name="dictionaryFilePath"/>, and constructs a dictionary <see cref="Node"/>s grouped by a word.
        /// </summary>
        /// <param name="dictionaryFilePath">The file path of the dictionary.</param>
        /// <param name="startWord">The start word.</param>
        /// <param name="endWord">The end word.</param>
        /// <returns>A word ladder.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null, empty, or whitespace.</exception>
        /// <exception cref="WordLengthNotEqualException">Thrown if <paramref name="startWord"/> is not equal to <paramref name="endWord"/> in length.</exception>
        /// <exception cref="FileNotFoundException">Thrown if the specified <paramref name="dictionaryFilePath"/> was not found.</exception>
        /// <exception cref="NoMatchingLengthWordsException">Thrown if the specified <paramref name="dictionaryFilePath"/> does not containing any words matching the length of <paramref name="startWord"/> or <paramref name="endWord"/> respectively.</exception>        
        IWordLadder Import(string dictionaryFilePath, string startWord, string endWord, bool caseSensitive); 
    }    
}