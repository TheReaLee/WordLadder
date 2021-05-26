using BluePrism.Core.Classes;
using BluePrism.Core.Interfaces;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BluePrism.Core.Tests")]
namespace BluePrism.Core.Internals
{
    /// <summary>
    /// Internal <see cref="IWordLadderExportResult"/> implementation.
    /// </summary>
    internal class WordLadderExportResult : IWordLadderExportResult
    {
        /// <inheritdoc/>
        public string ExportFileName { get; private set; }

        /// <inheritdoc/>
        public string Separator { get; private set; }

        /// <inheritdoc/>
        public string Result { get; private set; }

        /// <summary>
        /// Default and only constructor that initialize a new WordLadderTraversalResult given a set of parameters.
        /// </summary>
        /// <param name="exportFileName"><inheritdoc cref="ExportFileName" path="/summary"/></param>
        /// <param name="separator"><inheritdoc cref="Separator" path="/summary"/></param>
        /// <param name="result"><inheritdoc cref="Result" path="/summary"/></param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="exportFileName"/> or <paramref name="separator"/> are null or empty..</exception>
        public WordLadderExportResult(string exportFileName, string separator, string result = "")
        {
            Argument.IsNotNullOrEmpty(nameof(exportFileName), exportFileName);
            Argument.IsNotNullOrEmpty(nameof(separator), separator);

            this.ExportFileName = exportFileName;
            this.Separator = separator;
            this.Result = result;
        }
    }
}
