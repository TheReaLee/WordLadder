using BluePrism.Core.Classes;
using BluePrism.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace BluePrism.Core.Tests.Tests
{
    /// <summary>
    /// A set of unit tests aimed to test <see cref="WordLadderExporter"/>.
    /// </summary>
    /// <remarks> Naming convention used: Method_Condition1_Condition2_Condition3_etc_ExpectedResult() </remarks>
    public class WordLadderExporterTests : IDisposable
    {
        private readonly WordLadderExporter _wordLadderExporter;
        private string _tempFileName;

        public WordLadderExporterTests()
        {
            this._wordLadderExporter = new WordLadderExporter();
        }

        private string _getTempFileName()
        {
            this._tempFileName = Path.GetTempFileName();

            return this._tempFileName;
        }

        public void Dispose()
        {
            if (!string.IsNullOrEmpty(this._tempFileName) && File.Exists(this._tempFileName))
            {
                File.Delete(this._tempFileName);
            }
        }

        [Fact]
        public void Export_EmptyResultWords_EmptySeparator_EmptyOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, "", ""));
        }

        [Fact]
        public void Export_EmptyResultWords_EmptySeparator_NotEmptyOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, "", "abc"));
        }

        [Fact]
        public void Export_EmptyResultWords_NotEmptySeparator_EmptyOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, "abc", ""));
        }

        [Fact]
        public void Export_NotEmptyResultWords_EmptySeparator_EmptyOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, "", ""));
        }

        [Fact]
        public void Export_NullResultWords_NullSeparator_NullOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(null, null, null));
        }

        [Fact]
        public void Export_NullResultWords_NullSeparator_NotNullOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(null, null, "abc"));
        }

        [Fact]
        public void Export_NullResultWords_NotNullSeparator_NullOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(null, "abc", null));
        }

        [Fact]
        public void Export_NotNullResultWords_NullSeparator_NullOutputFilePath_ArgumentNullException()
        {
            Mock<IWordLadderTraversalResult> wordLadderTraversalResultMock = new Mock<IWordLadderTraversalResult>();
            wordLadderTraversalResultMock.Setup(x => x.ResultedWords).Returns(new List<string>() { "abc" });

            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(wordLadderTraversalResultMock.Object, null, null));
        }

        [Fact]
        public void Export_EmptyResultWords_WhiteSpaceSeparator_WhiteSpaceOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, " ", " "));
        }

        [Fact]
        public void Export_EmptyResultWords_WhiteSpaceSeparator_NotWhiteSpaceOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, " ", "abc"));
        }

        [Fact]
        public void Export_EmptyResultWords_NotWhiteSpaceSeparator_WhiteSpaceOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, "abc", " "));
        }

        [Fact]
        public void Export_NotWhiteSpaceResultWords_WhiteSpaceSeparator_WhiteSpaceOutputFilePath_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderExporter.Export(new Mock<IWordLadderTraversalResult>().Object, " ", " "));
        }

        [Fact]
        public void Export_1ResultWord_CommaSpaceSeparator_ValidOutputFilePathAndAlreadyExists_OutputFileCreatedAndContainsExpectedWord()
        {
            string tempFileName = this._getTempFileName();
            Mock<IWordLadderTraversalResult> wordLadderTraversalResultMock = new Mock<IWordLadderTraversalResult>();
            wordLadderTraversalResultMock.Setup(x => x.ResultedWords).Returns(new List<string>() { "Hello" });

            this._wordLadderExporter.Export(wordLadderTraversalResultMock.Object, ",", tempFileName);

            List<string> actualWords = File.ReadAllText(tempFileName).Split(',').ToList();

            Assert.Equal(wordLadderTraversalResultMock.Object.ResultedWords, actualWords);
        }

        [Fact]
        public void Export_2ResultWords_CommaSpaceSeparator_ValidOutputFilePathAndAlreadyExists_OutputFileCreatedAndContainsExpectedWords()
        {
            string tempFileName = this._getTempFileName();
            Mock<IWordLadderTraversalResult> wordLadderTraversalResultMock = new Mock<IWordLadderTraversalResult>();
            wordLadderTraversalResultMock.Setup(x => x.ResultedWords).Returns(new List<string>() { "Hello", "World" });

            this._wordLadderExporter.Export(wordLadderTraversalResultMock.Object, ",", tempFileName);

            List<string> actualWords = File.ReadAllText(tempFileName).Split(',').ToList();

            Assert.Equal(wordLadderTraversalResultMock.Object.ResultedWords, actualWords);
        }

        [Fact]
        public void Export_2ResultWords_CommaSpaceSeparator_ValidOutputFilePathAndDoesNotExist_OutputFileCreatedAndContainsExpectedWords()
        {
            string tempFileName = this._getTempFileName();
            File.Delete(tempFileName);
            Mock<IWordLadderTraversalResult> wordLadderTraversalResultMock = new Mock<IWordLadderTraversalResult>();
            wordLadderTraversalResultMock.Setup(x => x.ResultedWords).Returns(new List<string>() { "Hello", "World" });

            this._wordLadderExporter.Export(wordLadderTraversalResultMock.Object, ",", tempFileName);

            List<string> actualWords = File.ReadAllText(tempFileName).Split(',').ToList();

            Assert.Equal(wordLadderTraversalResultMock.Object.ResultedWords, actualWords);
        }
    }
}
