using System;
using System.IO;

namespace BluePrism.Core.Interfaces
{
    /// <summary>
    /// Contract for implementing word ladder exporters.
    /// </summary>
    /// <remarks>Utilize <see cref="IWordLadderTraverser"/> to traverse word ladder.</remarks>
    public interface IWordLadderExporter
    {
        /// <summary>
        /// Exports the specified <paramref name="resultWords"/> to the <paramref name="outputFilePath"/> separated by <paramref name="separator"/>.
        /// </summary>
        /// <param name="wordLadderTraversalResult">The word ladder traversal result to export.</param>
        /// <param name="separator">The separator to use.</param>
        /// <param name="outputFilePath">The output file path.</param>
        /// <returns>The export result.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null, empty, or whitespace.</exception>
        /// <remarks>May throw <see cref="File"/> related exceptions.</remarks>
        IWordLadderExportResult Export(IWordLadderTraversalResult wordLadderTraversalResult, string separator, string outputFilePath); 
    }
}
