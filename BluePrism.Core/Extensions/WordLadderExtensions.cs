using BluePrism.Core.Interfaces;
using System;

namespace BluePrism.Core.Extensions
{
    /// <summary>
    /// A set of extensions to ease and simplify word ladder execution from start to finish.
    /// </summary>
    public static class WordLadderExtensions
    {
        /// <inheritdoc cref="IWordLadderTraverser.Traverse(IWordLadder)"/>
        public static IWordLadderTraversalResult Traverse<TWordLadderTraverser>(this IWordLadder wordLadder)
            where TWordLadderTraverser: IWordLadderTraverser, new()
        {
            IWordLadderTraverser wordLadderTraverser = Activator.CreateInstance<TWordLadderTraverser>();
            return wordLadderTraverser.Traverse(wordLadder);
        }

        /// <inheritdoc cref="IWordLadderExporter.Export(IWordLadderTraversalResult, string, string)"/>
        public static IWordLadderExportResult Export<TWordLadderExporter>(this IWordLadderTraversalResult wordLadderTraversalResult, string separator, string outputFilePath)
            where TWordLadderExporter : IWordLadderExporter, new()
        {
            IWordLadderExporter wordLadderExporter = Activator.CreateInstance<TWordLadderExporter>();
            return wordLadderExporter.Export(wordLadderTraversalResult, separator, outputFilePath);
        }        
    }
}
