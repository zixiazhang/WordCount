using System;
using System.IO;
using WordCount.Interfaces;

namespace WordCount
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please specify file to count");
            var fileToCount = Console.ReadLine();

            if (File.Exists(fileToCount))
            {
                ProcessFile(fileToCount);
            }
            else
            {
                Console.WriteLine("File not found");
            }
            Console.ReadLine();
        }

        private static void ProcessFile(string fileToCount)
        {
            IFileReader fileReader = new FileReader(fileToCount);
            var rootTrieNode = new TrieNode(null, ' ');
            IWordCounter wordCounter = new WordCounter(fileReader, rootTrieNode);
            wordCounter.StartCount();
            var totalDictionary = wordCounter.GetWordCountDictionary();

            foreach (var word in totalDictionary)
            {
                Console.WriteLine("{0}: {1}", word.Value, word.Key);
            }
        }
    }
}
