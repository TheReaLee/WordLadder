using BluePrism.Core.Classes;
using BluePrism.Core.Exceptions;
using BluePrism.Core.Interfaces;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace BluePrism.Core.Tests.Tests
{
    /// <summary>
    /// A set of unit tests aimed to test <see cref="WordLadderImporter"/>.
    /// </summary>
    /// <remarks> Naming convention used: Method_Condition1_Condition2_Condition3_etc_ExpectedResult() </remarks>
    public class WordLadderImporterTests: IDisposable
    {
        private readonly WordLadderImporter _wordLadderImporter;
        private string _tempFileName;

        public WordLadderImporterTests()
        {
            this._wordLadderImporter = new WordLadderImporter();
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
        public void Import_EmptyDictionaryFilePath_EmptyStartWordAndEmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import("", "", "", false));
        }

        [Fact]
        public void Import_EmptyDictionaryFilePath_EmptyStartWord_NotEmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import("", "", "endWord", false));
        }

        [Fact]
        public void Import_EmptyDictionaryFilePath_NotEmptyStartWord_EmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import("", "startWord", "", false));
        }

        [Fact]
        public void Import_NotEmptyDictionaryFilePath_EmptyStartWord_EmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import("C:\\test.txt", "", "", false));
        }

        [Fact]
        public void Import_NullDictionaryFilePath_NullStartWord_NullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import(null, null, null, false));
        }

        [Fact]
        public void Import_NullDictionaryFilePath_NullStartWord_NotNullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import(null, null, "endWord", false));
        }

        [Fact]
        public void Import_NullDictionaryFilePath_NotNullStartWord_NullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import(null, "startWord", null, false));
        }

        [Fact]
        public void Import_NotNullDictionaryFilePath_NullStartWord_NullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderImporter.Import("C:\\test.txt", null, null, false));
        }

        [Fact]
        public void Import_NotNullDictionaryFilePath_StartAndEndWordsNotEqualInLength_WordLengthNotEqualException()
        {
            Assert.Throws<WordLengthNotEqualException>(() => this._wordLadderImporter.Import("C:\\test.txt", "test", "tes", false));
        }

        [Fact]
        public void Import_NotNullDictionaryFilePath_StartAndEndWordsNotEqualInLengthSwitched_WordLengthNotEqualException()
        {
            Assert.Throws<WordLengthNotEqualException>(() => this._wordLadderImporter.Import("C:\\test.txt", "tes", "test", false));
        }

        [Fact]
        public void Import_DictionaryFilePathDoesNotExist_StartAndEndWordsEqualInLength_FileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => this._wordLadderImporter.Import("C:\\test.txt", "test", "test", false));
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsEmpty_StartAndEndWordsEqualInLength_CaseInsensitive_NoMatchingLengthWordsException()
        {
            string tempFile = this._getTempFileName();
            Assert.Throws<NoMatchingLengthWordsException>(() => this._wordLadderImporter.Import(tempFile, "test", "test", false));
            File.Delete(tempFile);
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWithNoMatchingLengthWords_StartAndEndWordsEqualInLengthAndSameWordAndCase_CaseInsensitive_NoMatchingLengthWordsException()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllText(tempFile, "abcde");
            Assert.Throws<NoMatchingLengthWordsException>(() => this._wordLadderImporter.Import(tempFile, "test", "test", false));            
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith1MatchingLengthWord_StartAndEndWordsEqualInLengthAndSameWordAndCase_CaseInsensitive_DictionaryWith2ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllText(tempFile, "abcd");
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "test", false);

            Assert.Equal(2, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2DifferentMatchingLengthWords_StartAndEndWordsEqualInLengthAndSameWordAndCase_CaseInsensitive_DictionaryWith2ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "abcde" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "test", false);

            Assert.Equal(2, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithSameCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndSameWordAndCase_CaseInsensitive_DictionaryWith2ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "abcde" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "test", false);

            Assert.Equal(2, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithSameCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndSameWordAndCase_CaseSensitive_DictionaryWith2ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "test", true);

            Assert.Equal(2, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithDifferentCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndSameWordAndCase_CaseSensitive_DictionaryWith3ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "Abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "test", true);

            Assert.Equal(3, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithDifferentCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndSameWordAndCase_CaseInSensitive_DictionaryWith3ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "Abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "test", false);

            Assert.Equal(3, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithDifferentCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndDifferentCase_CaseSensitive_DictionaryWith4ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "Abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "Test", true);

            Assert.Equal(4, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithDifferentCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndDifferentWordSameCase_CaseSensitive_DictionaryWith4ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "Abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "hell", true);

            Assert.Equal(4, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithDifferentCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndDifferentWordSameCase_CaseInsensitive_DictionaryWith4ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "Abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "hell", false);

            Assert.Equal(4, wordLadder.Nodes.Count());
        }

        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithDifferentCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndDifferentWordDifferentCase_CaseSensitive_DictionaryWith4ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "Abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "Test", true);

            Assert.Equal(4, wordLadder.Nodes.Count());
        }


        [Fact]
        public void Import_DictionaryFilePathExistsAndIsNotEmptyWith2EqualWithDifferentCaseMatchingLengthWords_StartAndEndWordsEqualInLengthAndDifferentWordDifferentCase_CaseInsensitive_DictionaryWith4ItemsIsReturned()
        {
            string tempFile = this._getTempFileName();
            File.WriteAllLines(tempFile, new string[2] { "abcd", "Abcd" });
            IWordLadder wordLadder = this._wordLadderImporter.Import(tempFile, "test", "Test", true);

            Assert.Equal(4, wordLadder.Nodes.Count());
        }
    }
}
