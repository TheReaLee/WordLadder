using BluePrism.Core.Exceptions;
using BluePrism.Core.Extensions;
using BluePrism.Core.Interfaces;
using BluePrism.Core.Internals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BluePrism.Core.Classes
{
    /// <summary>
    /// Default  <see cref="IWordLadderImporter"/> implementation.
    /// </summary>
    public class WordLadderImporter : IWordLadderImporter
    {
        private IEnumerable<string> _getWordsFromDictionaryFile(string dictionaryFilePath, int wordLength)
        {
            List<string> words = new List<string>();

            // Loading only wordLength words in memory.
            using (FileStream fileStream = new FileStream(dictionaryFilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string word = streamReader.ReadLine();
                        if (word.Length == wordLength)
                        {
                            words.Add(word);
                        }
                    }
                }
            }

            return words;
        }

        private IDictionary<string, INode> _constructMultiLinkedListFromDictionary(IEnumerable<string> words, string startWord, string endWord, StringComparison stringComparison)
        {
            Dictionary<string, INode> linkedDictionary = new Dictionary<string, INode>();
            linkedDictionary.Add(startWord, new Node(startWord));

            if (!startWord.Equals(endWord, stringComparison))
            {
                linkedDictionary.Add(endWord, new Node(endWord));
            }

            foreach (string word in words)
            {
                // Get all the nodes which have not more than (word.Length -1) similarities.
                List<INode> similarNodes = linkedDictionary.Where(x =>
                {
                    int similarityCount = 0;
                    for (int i = 0; i < word.Length; i++)
                    {                        
                        if (x.Key[i].ToString().Equals(word[i].ToString(), stringComparison))
                        {
                            similarityCount++;
                        }
                    }
                    return similarityCount == word.Length - 1;
                }).Select(x => x.Value).ToList();

                INode currentNode = null;
                if (linkedDictionary.ContainsKey(word))
                {
                    currentNode = linkedDictionary[word];
                }
                else
                {
                    currentNode = new Node(word);
                    linkedDictionary.Add(word, currentNode);
                }

                foreach (INode node in similarNodes)
                {
                    if (node.Word != endWord)
                    {
                        currentNode.LinkNode(node);
                    }
                    node.LinkNode(currentNode);
                }
            }

            return linkedDictionary;
        }

        /// <inheritdoc/>        
        public IWordLadder Import(string dictionaryFilePath, string startWord, string endWord, bool caseSensitive)
        {
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(dictionaryFilePath), dictionaryFilePath);
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(startWord), startWord);
            Argument.IsNotNullOrEmptyOrWhiteSpace(nameof(endWord), endWord);
            
            if (!startWord.IsOfEqualLength(endWord))
            {
                throw new WordLengthNotEqualException(startWord, endWord);
            }

            if (!File.Exists(dictionaryFilePath))
            {
                throw new FileNotFoundException("The specified dictionary file was not found", Path.GetFileName(dictionaryFilePath));
            }                        

            IEnumerable<string> words = this._getWordsFromDictionaryFile(dictionaryFilePath, startWord.Length);

            if (words == null || words.Count() < 1)
            {
                throw new NoMatchingLengthWordsException(startWord.Length);
            }

            return new WordLadder(
                this._constructMultiLinkedListFromDictionary(words, startWord, endWord, caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase),
                startWord,
                endWord,
                caseSensitive);            
        }
    }
}
