using BluePrism.Core.Interfaces;
using BluePrism.Core.Internals;
using System.IO;

namespace BluePrism.Core.Classes
{
    /// <summary>
    /// Default <see cref="IWordLadderExporter"/> implementation.
    /// </summary>
    public class WordLadderExporter : IWordLadderExporter
    {
        /// <inheritdoc/>
        public IWordLadderExportResult Export(IWordLadderTraversalResult wordLadderTraversalResult, string separator, string outputFilePath)
        {
            Argument.IsNotNull(nameof(wordLadderTraversalResult), wordLadderTraversalResult);
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(separator), separator);
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(outputFilePath), outputFilePath);

            string result = string.Join(separator, wordLadderTraversalResult.ResultedWords);
            using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(result);
                    streamWriter.Flush();
                }
            }
            return new WordLadderExportResult(outputFilePath, separator, result);
        }
    }
}
