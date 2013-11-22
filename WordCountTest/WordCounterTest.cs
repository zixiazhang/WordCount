using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using WordCount;
using WordCount.Interfaces;

namespace WordCountTest
{
    [TestClass]
    public class WordCounterTest
    {
        [TestMethod]
        public void ReturnEmptyDictionaryWhenFileEmpty()
        {
            var fileReader = GetFileReaderWithReturnValues("");
            var dictionary = CreateDictionary(fileReader);
            Assert.AreEqual(dictionary.Count, 0);
        }

        [TestMethod]
        public void ReturnSingleWordWithCountOne()
        {
            var fileReader = GetFileReaderWithReturnValues("a");
            var dictionary = CreateDictionary(fileReader);
            Assert.AreEqual(dictionary["a"], 1);
        }

        [TestMethod]
        public void ReturnSingleWordWithCountThree()
        {
            var fileReader = GetFileReaderWithReturnValues("a a a");

            var dictionary = CreateDictionary(fileReader);

            Assert.AreEqual(dictionary["a"], 3);
        }

        [TestMethod]
        public void ReturnMultipleWordsWithCount()
        {
            var fileReader = GetFileReaderWithReturnValues("this this this test test correct");

            var dictionary = CreateDictionary(fileReader);

            Assert.AreEqual(dictionary["this"], 3);
            Assert.AreEqual(dictionary["test"], 2);
            Assert.AreEqual(dictionary["correct"], 1);

        }

        private static IFileReader GetFileReaderWithReturnValues(string returnValues)
        {
            var charEnumerable = returnValues.ToCharArray();
            var fileReader = MockRepository.GenerateStub<IFileReader>();
            fileReader.Stub(x => x.GetCharacters()).Return(charEnumerable);
            return fileReader;
        }

        private static Dictionary<string, int> CreateDictionary(IFileReader fileReader)
        {
            var rootTrieNode = new TrieNode(null, ' ');
            IWordCounter wordCounter = new WordCounter(fileReader, rootTrieNode);
            wordCounter.StartCount();
            var dictionary = wordCounter.GetWordCountDictionary();
            return dictionary;
        }
    }
}
