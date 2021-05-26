using BluePrism.Core.Interfaces;
using BluePrism.Core.Internals;
using System;
using System.Collections.Generic;
using Xunit;

namespace BluePrism.Core.Tests.Tests
{
    /// <summary>
    /// A set of unit tests aimed to test <see cref="WordLadder"/>.
    /// </summary>
    /// <remarks> Naming convention used: Method_Condition1_Condition2_Condition3_etc_ExpectedResult() </remarks>
    public class WordLadderTests
    {
        [Fact]
        public void ctor_NullNodes_NullStartWord_NullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(null, null, null, false));
        }

        [Fact]
        public void ctor_NullNodes_NullStartWord_NotNullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(null, null, "abc", false));
        }

        [Fact]
        public void ctor_NullNodes_NotNullStartWord_NullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(null, "abc", null, false));
        }

        [Fact]
        public void ctor_NotNullNodes_NullStartWord_NullEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(new Dictionary<string, INode>(), null, null, false));
        }

        [Fact]
        public void ctor_NullNodes_EmptyStartWord_EmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(null, "", "", false));
        }

        [Fact]
        public void ctor_NullNodes_EmptyStartWord_NotEmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(null, "", "abc", false));
        }

        [Fact]
        public void ctor_NullNodes_NotEmptyStartWord_EmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(null, "abc", "", false));
        }

        [Fact]
        public void ctor_NotNullNodes_EmptyStartWord_EmptyEndWord_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WordLadder(new Dictionary<string, INode>(), "", "", false));
        }

        [Fact]
        public void ctor_NotNullAndNotEmptyNodes_NotEmptyStartWord_NotEmptyEndWord_NoException()
        {
            new WordLadder(new Dictionary<string, INode>() { { "abc", new Node("abc") } }, "abc", "abc", false);
        }
    }
}
