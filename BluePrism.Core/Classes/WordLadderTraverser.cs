using BluePrism.Core.Exceptions;
using BluePrism.Core.Extensions;
using BluePrism.Core.Interfaces;
using BluePrism.Core.Internals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluePrism.Core.Classes
{
    /// <summary>
    /// Default  <see cref="IWordLadderTraverser"/> implementation.
    /// </summary>    
    public class WordLadderTraverser : IWordLadderTraverser
    {
        private readonly List<KeyValuePair<int, string[]>> _traversalResult;
        private readonly Queue<KeyValuePair<INode, List<string>>> _bfsQueue;
        private readonly List<string> _traversedWords = null;

        /// <summary>
        /// Default constructor which initializes a new word ladder traverser.
        /// </summary>
        public WordLadderTraverser()
        {
            this._traversalResult = new List<KeyValuePair<int, string[]>>();
            this._bfsQueue = new Queue<KeyValuePair<INode, List<string>>>();
            this._traversedWords = new List<string>();
        }

        /// <inheritdoc/>        
        public IWordLadderTraversalResult Traverse(IWordLadder wordLadder)
        {
            Argument.IsNotNull(nameof(wordLadder), wordLadder);
            Argument.IsNotNull(nameof(wordLadder.StartWord), wordLadder.StartWord);
            Argument.IsNotNull(nameof(wordLadder.EndWord), wordLadder.EndWord);
            Argument.IsNotNull(nameof(wordLadder.Nodes), wordLadder.Nodes);

            if (!wordLadder.StartWord.IsOfEqualLength(wordLadder.EndWord))
            {
                throw new WordLengthNotEqualException(wordLadder.StartWord, wordLadder.EndWord);
            }

            // If wordLadder has no nodes, then return an empty result.
            if(wordLadder.Nodes.Count() == 0)
            {
                return new WordLadderTraversalResult(wordLadder, new List<string>());
            }

            StringComparison stringComparison = wordLadder.CaseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            try
            {
                this._bfsQueue.Enqueue(new KeyValuePair<INode, List<string>>(wordLadder.Nodes[wordLadder.StartWord], new List<string>() { wordLadder.StartWord }));

                while (this._bfsQueue.Count() > 0)
                {   
                    KeyValuePair<INode, List<string>> nodePair = this._bfsQueue.Dequeue();
                    if(nodePair.Equals(default(KeyValuePair<INode, List<string>>)))
                    {
                        continue;
                    }

                    if (nodePair.Key.Word.Equals(wordLadder.EndWord, stringComparison))
                    {
                        this._traversalResult.Add(new KeyValuePair<int, string[]>(nodePair.Value.Count(), nodePair.Value.ToArray()));

                        // Because BFS, break immediately means found the shortest path already.
                        break;
                    }
                    else
                    {
                        this._traversedWords.Add(nodePair.Key.Word);

                        if (nodePair.Key.LinkedNodes != null)
                        {
                            nodePair.Key.LinkedNodes.ToList().ForEach(x =>
                            {                                
                                if (!nodePair.Value.Contains(x.Word, stringComparison) && !this._traversedWords.Contains(x.Word, stringComparison))
                                {
                                    List<string> innerResultWords = new List<string>();
                                    innerResultWords.AddRange(nodePair.Value);
                                    innerResultWords.Add(x.Word);
                                    this._bfsQueue.Enqueue(new KeyValuePair<INode, List<string>>(x, innerResultWords));
                                }
                            });
                        }
                    }
                }
                // If no possible path was found, return an empty list.
                List<string> result = this._traversalResult.Count() == 0? new List<string>(): this._traversalResult.OrderBy(x => x.Key).Select(x => x.Value).FirstOrDefault().ToList();
                return new WordLadderTraversalResult(wordLadder, result);
            }
            finally
            {
                this._traversedWords.Clear();
                this._bfsQueue.Clear();
                this._traversalResult.Clear();
            }
        }
    }
}