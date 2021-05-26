using BluePrism.Core.Classes;
using BluePrism.Core.Extensions;
using BluePrism.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BluePrism.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 4)
                {
                    throw new Exception($"Arguments passed are less than the required: [{4}]");
                }

                string startWord = args[0];
                string endWord = args[1];
                string dictionaryFilePath = args[2];
                string answerFilePath = args[3];

                if (startWord != null && endWord != null
                    && (startWord.Length != 4 || endWord.Length != 4))
                {
                    throw new Exception("Only 4 letter start and end words are supported.");
                }

                IWordLadderExportResult wordLadderExportResult = new WordLadderImporter()
                    .Import(dictionaryFilePath, startWord, endWord, true)
                    .Traverse<WordLadderTraverser>()
                    .Export<WordLadderExporter>("->", answerFilePath);

                if (string.IsNullOrEmpty(wordLadderExportResult.Result))
                {
                    throw new Exception("There are no possibilities.");
                }

                System.Console.WriteLine(wordLadderExportResult.Result);
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"An exception has been thrown: {ex.Message}");                
                System.Console.ReadKey();
            }
        }
    }
}
