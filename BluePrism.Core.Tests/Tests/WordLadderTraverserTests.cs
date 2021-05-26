using BluePrism.Core.Classes;
using BluePrism.Core.Exceptions;
using BluePrism.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace BluePrism.Core.Tests.Tests
{
    /// <summary>
    /// A set of unit tests aimed to test <see cref="WordLadderTraverser"/>.
    /// </summary>
    /// <remarks> Naming convention used: Method_Condition1_Condition2_Condition3_etc_ExpectedResult() </remarks>
    public class WordLadderTraverserTests
    {
        private readonly WordLadderTraverser _wordLadderTraverser;

        public WordLadderTraverserTests()
        {
            this._wordLadderTraverser = new WordLadderTraverser();
        }

        [Fact]
        public void Traverse_NullWordLadder_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(null));
        }

        [Fact]
        public void Traverse_NullStartWord_NullEndWord_NullNodes_ArgumentNullException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();

            wordLadderMock.Setup(x => x.StartWord).Returns((string)null);
            wordLadderMock.Setup(x => x.EndWord).Returns((string)null);
            wordLadderMock.Setup(x => x.Nodes).Returns<IDictionary<string, INode>>(null);

            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_NullStartWord_NullEndWord_EmptyNodes_ArgumentNullException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();
            
            wordLadderMock.Setup(x => x.StartWord).Returns((string)null);
            wordLadderMock.Setup(x => x.EndWord).Returns((string)null);
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);

            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_NullStartWord_NotNullEndWord_NullNodes_ArgumentNullException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();            

            wordLadderMock.Setup(x => x.StartWord).Returns((string)null);
            wordLadderMock.Setup(x => x.EndWord).Returns("Test");
            wordLadderMock.Setup(x => x.Nodes).Returns((IDictionary<string, INode>)null);

            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_NotNullStartWord_NullEndWord_NullNodes_ArgumentNullException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();            

            wordLadderMock.Setup(x => x.StartWord).Returns("Test");
            wordLadderMock.Setup(x => x.EndWord).Returns((string)null);
            wordLadderMock.Setup(x => x.Nodes).Returns((IDictionary<string, INode>)null);

            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_NotNullStartWord_NotNullEndWord_NullNodes_ArgumentNullException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();

            wordLadderMock.Setup(x => x.StartWord).Returns("Test");
            wordLadderMock.Setup(x => x.EndWord).Returns("Test");
            wordLadderMock.Setup(x => x.Nodes).Returns((IDictionary<string, INode>)null);

            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_NotNullStartWord_NullEndWord_EmptyNodes_ArgumentNullException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();

            wordLadderMock.Setup(x => x.StartWord).Returns("Test");
            wordLadderMock.Setup(x => x.EndWord).Returns((string)null);
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);

            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_NullStartWord_NotNullEndWord_EmptyNodes_ArgumentNullException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();

            wordLadderMock.Setup(x => x.StartWord).Returns((string)null);
            wordLadderMock.Setup(x => x.EndWord).Returns("Test");
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);

            Assert.Throws<ArgumentNullException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_NotNullStartWord_NotNullEndWord_EmptyNodes_CaseInsensitive_NoException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();

            wordLadderMock.Setup(x => x.StartWord).Returns("abcd");
            wordLadderMock.Setup(x => x.EndWord).Returns("Test");
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(false);

            this._wordLadderTraverser.Traverse(wordLadderMock.Object);
        }

        [Fact]
        public void Traverse_NotNullStartWord_NotNullEndWord_EmptyNodes_CaseSensitive_NoException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();

            wordLadderMock.Setup(x => x.StartWord).Returns("abcd");
            wordLadderMock.Setup(x => x.EndWord).Returns("Test");
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(true);

            this._wordLadderTraverser.Traverse(wordLadderMock.Object);
        }

        [Fact]
        public void Traverse_StartWordOfLength3_EndWordOfLength4_EmptyNodes_CaseSensitive_WordLengthNotEqualException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();

            wordLadderMock.Setup(x => x.StartWord).Returns("abc");
            wordLadderMock.Setup(x => x.EndWord).Returns("Test");
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(true);

            Assert.Throws<WordLengthNotEqualException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_StartWordOfLength4_EndWordOfLength3_EmptyNodes_CaseSensitive_WordLengthNotEqualException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();

            wordLadderMock.Setup(x => x.StartWord).Returns("abcd");
            wordLadderMock.Setup(x => x.EndWord).Returns("Tes");
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(true);

            Assert.Throws<WordLengthNotEqualException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_StartWordOfLength1_EndWordOfLength2_EmptyNodes_CaseSensitive_WordLengthNotEqualException()
        {
            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<IDictionary<string, INode>> nodesMock = new Mock<IDictionary<string, INode>>();

            wordLadderMock.Setup(x => x.StartWord).Returns("a");
            wordLadderMock.Setup(x => x.EndWord).Returns("ab");
            wordLadderMock.Setup(x => x.Nodes).Returns(nodesMock.Object);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(true);

            Assert.Throws<WordLengthNotEqualException>(() => this._wordLadderTraverser.Traverse(wordLadderMock.Object));
        }

        [Fact]
        public void Traverse_StartWordOfLength4_EndWordOfLength4_NodesContainPossiblePath_NonEmptyAndValidResult()
        {
            string startWord = "abcd";
            string endWord = "dcba";

            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<INode> abcdMock = new Mock<INode>();
            Mock<INode> abcaMock = new Mock<INode>();
            Mock<INode> abbaMock = new Mock<INode>();
            Mock<INode> acbaMock = new Mock<INode>();
            Mock<INode> dcbaMock = new Mock<INode>();

            dcbaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { acbaMock.Object });
            dcbaMock.Setup(x => x.Word).Returns(endWord);
            acbaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { dcbaMock.Object, acbaMock.Object });
            acbaMock.Setup(x => x.Word).Returns("acba");
            abbaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { acbaMock.Object, abbaMock.Object });
            abbaMock.Setup(x => x.Word).Returns("abba");
            abcaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abbaMock.Object, abcaMock.Object });
            abcaMock.Setup(x => x.Word).Returns("abca");
            abcdMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abcaMock.Object });
            abcdMock.Setup(x => x.Word).Returns(startWord);

            Dictionary<string, INode> returnedNodes = new Dictionary<string, INode>();
            returnedNodes.Add(abcdMock.Object.Word, abcdMock.Object);
            returnedNodes.Add(abcaMock.Object.Word, abcaMock.Object);
            returnedNodes.Add(abbaMock.Object.Word, abbaMock.Object);
            returnedNodes.Add(acbaMock.Object.Word, acbaMock.Object);
            returnedNodes.Add(dcbaMock.Object.Word, dcbaMock.Object);

            wordLadderMock.Setup(x => x.StartWord).Returns(startWord);
            wordLadderMock.Setup(x => x.EndWord).Returns(endWord);
            wordLadderMock.Setup(x => x.Nodes).Returns(returnedNodes);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(false);

            List<string> expectedWords = new List<string>()
            {
                abcdMock.Object.Word,
                abcaMock.Object.Word,
                abbaMock.Object.Word,
                acbaMock.Object.Word,
                dcbaMock.Object.Word
            };

            IWordLadderTraversalResult wordLadderTraversalResult = this._wordLadderTraverser.Traverse(wordLadderMock.Object);

            Assert.Equal(expectedWords, wordLadderTraversalResult.ResultedWords);
        }       

        [Fact]
        public void Traverse_StartWordOfLength4_EndWordOfLength4_NodesDoesNotContainPossiblePath_EmptyResult()
        {
            string startWord = "abcd";
            string endWord = "dcba";

            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<INode> abcdMock = new Mock<INode>();
            Mock<INode> abcaMock = new Mock<INode>();
            Mock<INode> abbaMock = new Mock<INode>();
            Mock<INode> acwaMock = new Mock<INode>();
            Mock<INode> dcbaMock = new Mock<INode>();

            dcbaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() {  });
            dcbaMock.Setup(x => x.Word).Returns(endWord);
            acwaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abbaMock.Object, });
            acwaMock.Setup(x => x.Word).Returns("acwa");
            abbaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { acwaMock.Object, abbaMock.Object });
            abbaMock.Setup(x => x.Word).Returns("abba");
            abcaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abbaMock.Object, abcaMock.Object });
            abcaMock.Setup(x => x.Word).Returns("abca");
            abcdMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abcaMock.Object });
            abcdMock.Setup(x => x.Word).Returns(startWord);

            Dictionary<string, INode> returnedNodes = new Dictionary<string, INode>();
            returnedNodes.Add(abcdMock.Object.Word, abcdMock.Object);
            returnedNodes.Add(abcaMock.Object.Word, abcaMock.Object);
            returnedNodes.Add(abbaMock.Object.Word, abbaMock.Object);
            returnedNodes.Add(acwaMock.Object.Word, acwaMock.Object);
            returnedNodes.Add(dcbaMock.Object.Word, dcbaMock.Object);

            wordLadderMock.Setup(x => x.StartWord).Returns(startWord);
            wordLadderMock.Setup(x => x.EndWord).Returns(endWord);
            wordLadderMock.Setup(x => x.Nodes).Returns(returnedNodes);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(false);

            IWordLadderTraversalResult wordLadderTraversalResult = this._wordLadderTraverser.Traverse(wordLadderMock.Object);

            Assert.Equal(new List<string>(), wordLadderTraversalResult.ResultedWords);
        }

        [Fact]
        public void Traverse_StartWordOfLength4_EndWordOfLength4_NodesDoesNotContainPossiblePathAndHasDuplicateValues_EmptyResult()
        {
            string startWord = "abcd";
            string endWord = "dcba";

            Mock<IWordLadder> wordLadderMock = new Mock<IWordLadder>();
            Mock<INode> abcdMock = new Mock<INode>();
            Mock<INode> abcaMock = new Mock<INode>();
            Mock<INode> abbaMock = new Mock<INode>();
            Mock<INode> acwaMock = new Mock<INode>();
            Mock<INode> acwaDuplicateMock = new Mock<INode>();
            Mock<INode> dcbaMock = new Mock<INode>();

            dcbaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { });
            dcbaMock.Setup(x => x.Word).Returns(endWord);
            acwaDuplicateMock.Setup(x => x.Word).Returns("acwa");
            acwaDuplicateMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { acwaMock.Object });
            acwaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { acwaDuplicateMock.Object });            
            acwaMock.Setup(x => x.Word).Returns("acwa");
            abbaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abbaMock.Object, acwaDuplicateMock.Object });
            abbaMock.Setup(x => x.Word).Returns("abba");
            abcaMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abbaMock.Object, abcaMock.Object });
            abcaMock.Setup(x => x.Word).Returns("abca");
            abcdMock.Setup(x => x.LinkedNodes).Returns(new List<INode>() { abcaMock.Object });
            abcdMock.Setup(x => x.Word).Returns(startWord);

            Dictionary<string, INode> returnedNodes = new Dictionary<string, INode>();
            returnedNodes.Add(abcdMock.Object.Word, abcdMock.Object);
            returnedNodes.Add(abcaMock.Object.Word, abcaMock.Object);
            returnedNodes.Add(abbaMock.Object.Word, abbaMock.Object);
            returnedNodes.Add(acwaMock.Object.Word, acwaMock.Object);
            returnedNodes.Add(dcbaMock.Object.Word, dcbaMock.Object);

            wordLadderMock.Setup(x => x.StartWord).Returns(startWord);
            wordLadderMock.Setup(x => x.EndWord).Returns(endWord);
            wordLadderMock.Setup(x => x.Nodes).Returns(returnedNodes);
            wordLadderMock.Setup(x => x.CaseSensitive).Returns(false);

            IWordLadderTraversalResult wordLadderTraversalResult = this._wordLadderTraverser.Traverse(wordLadderMock.Object);

            Assert.Equal(new List<string>(), wordLadderTraversalResult.ResultedWords);
        }
    }
}
