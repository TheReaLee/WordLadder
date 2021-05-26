using BluePrism.Core.Internals;
using System;
using Xunit;

namespace BluePrism.Core.Tests.Tests
{
    /// <summary>
    /// A set of unit tests aimed to test <see cref="WordLadderExportResult"/>.
    /// </summary>
    /// <remarks> Naming convention used: Method_Condition1_Condition2_Condition3_etc_ExpectedResult() </remarks>
    public class WordLadderExportResultTests
    {
        [Fact]
        public void ctor_NullExportFileName_NullSeparator_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderExportResult(null, null));
        }

        [Fact]
        public void ctor_NullExportFileName_NotNullSeparator_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderExportResult(null, "abc"));
        }

        [Fact]
        public void ctor_NotNullExportFileName_NullSeparator_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderExportResult("abc", null));
        }

        [Fact]
        public void ctor_EmptyExportFileName_EmptySeparator_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderExportResult("", ""));
        }

        [Fact]
        public void ctor_EmptyExportFileName_NotEmptySeparator_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderExportResult("", "abc"));
        }

        [Fact]
        public void ctor_NotEmptyExportFileName_EmptySeparator_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderExportResult("abc", ""));
        }

        [Fact]
        public void ctor_NotEmptyExportFileName_NotEmptySeparator_EmptyResult_NoException()
        {
            new WordLadderExportResult("abc", "abc", "");
        }

        [Fact]
        public void ctor_NotEmptyExportFileName_NotEmptySeparator_NullResult_NoException()
        {
            new WordLadderExportResult("abc", "abc", null);
        }

        [Fact]
        public void ctor_NotEmptyExportFileName_NotEmptySeparator_NotEmptyResult_NoException()
        {
            new WordLadderExportResult("abc", "abc", "Abc->Tes");
        }
    }
}
