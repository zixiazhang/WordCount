using System.Collections.Generic;

namespace WordCount.Interfaces
{
    public interface ITrieNode
    {
        TrieNode AddCharacter(char keyCharacter);
        void GetWordCount(Dictionary<string, int> wordCountDictionary);
        string ToString();
    }
}