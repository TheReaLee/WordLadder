using BluePrism.Core.Interfaces;
using BluePrism.Core.Internals;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BluePrism.Core.Tests.Tests
{
    /// <summary>
    /// A set of unit tests aimed to test <see cref="WordLadderTraversalResult"/>.
    /// </summary>
    /// <remarks> Naming convention used: Method_Condition1_Condition2_Condition3_etc_ExpectedResult() </remarks>
    public class WordLadderTraversalResultTests
    {
        [Fact]
        public void ctor_NullWordLadder_NullResultedWords_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderTraversalResult(null, null));
        }

        [Fact]
        public void ctor_NullWordLadder_NotNullResultedWords_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderTraversalResult(null, new List<string>()));
        }

        [Fact]
        public void ctor_NotNullWordLadder_NullResultedWords_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadderTraversalResult(new Mock<IWordLadder>().Object, null));
        }

        [Fact]
        public void ctor_NotNullWordLadder_EmptyResultedWords_NoException()
        {
            new WordLadderTraversalResult(new Mock<IWordLadder>().Object, new List<string>());
        }

        [Fact]
        public void ctor_NotNullWordLadder_NotNullAndNotEmptyResultedWords_NoException()
        {
            new WordLadderTraversalResult(new Mock<IWordLadder>().Object, new List<string>() { "abc" });
        }
    }
}
