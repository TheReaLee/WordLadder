using BluePrism.Core.Internals;
using System;
using System.Linq;
using Xunit;

namespace BluePrism.Core.Tests.Tests
{
    /// <summary>
    /// A set of unit tests aimed to test <see cref="Node"/>.
    /// </summary>
    /// <remarks> Naming convention used: Method_Condition1_Condition2_Condition3_etc_ExpectedResult() </remarks>
    public class NodeTests
    {
        [Fact]
        public void ctor_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Node(null));
        }

        [Fact]
        public void ctor_EmptyString_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Node(""));
        }

        [Fact]
        public void ctor_WhiteSpace_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Node(" "));
        }

        [Fact]
        public void ctor_ValidWord_NoException()
        {
            _ = new Node("test");
        }

        [Fact]
        public void GetWord_NodeInitializedWithWordTest_TestIsReturned()
        {
            Node node = new Node("Test");
            Assert.Equal("Test", node.Word);            
        }

        [Fact]
        public void GetLinkedNodes_NodeInitializedWithWordTest_EmptyLinkedNodes()
        {
            Node node = new Node("Test");
            Assert.Empty(node.LinkedNodes);            
        }

        [Fact]
        public void LinkNode_Null_ArgumentNullException()
        {
            Node node = new Node("Test");
            Assert.Throws<ArgumentNullException>(() => node.LinkNode(null));
        }

        [Fact]
        public void LinkNode_LinkItself_NodeNotLinkedAndLinkedNodesReturnsEmpty()
        {
            Node node = new Node("Test");
            node.LinkNode(node);

            Assert.Empty(node.LinkedNodes);
        }

        [Fact]
        public void LinkNode_LinkAlreadyLinkedNode_NodeNotLinkedAndLinkedNodesReturns1()
        {
            Node node = new Node("Test");
            Node existingNode = new Node("Existing");
            node.LinkNode(existingNode);
            node.LinkNode(existingNode);

            Assert.Single(node.LinkedNodes);
        }

        [Fact]
        public void LinkNode_Link1Node_LinkedNodesReturnsOnly1AndNodeIsValid()
        {
            Node node = new Node("Test");
            Node expectedNode = new Node("Expected");

            node.LinkNode(expectedNode);

            Assert.Single(node.LinkedNodes);
            Assert.Equal(node.LinkedNodes.FirstOrDefault(), expectedNode);
        }

        [Fact]
        public void LinkNode_Link2Nodes_LinkedNodesReturnsOnly2AndNodesAreValid()
        {
            Node node = new Node("Test");
            Node expectedNode1 = new Node("Expected1");
            Node expectedNode2 = new Node("Expected2");

            node.LinkNode(expectedNode1);
            node.LinkNode(expectedNode2);

            Assert.Equal(2, node.LinkedNodes.Count());
            Assert.Equal(node.LinkedNodes.ToArray()[0], expectedNode1);
            Assert.Equal(node.LinkedNodes.ToArray()[1], expectedNode2);
        }
    }
}
