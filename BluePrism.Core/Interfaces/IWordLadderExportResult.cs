namespace BluePrism.Core.Interfaces
{
    /// <summary>
    /// Contract for implementing word ladder export results.
    /// </summary>
    public interface IWordLadderExportResult
    {
        /// <summary>
        /// The absolute path of where the result was exported to.
        /// </summary>
        string ExportFileName { get; }

        /// <summary>
        /// The separator used.
        /// </summary>
        string Separator { get; }        

        /// <summary>
        /// The result string.
        /// </summary>
        string Result { get; }
    }
}
