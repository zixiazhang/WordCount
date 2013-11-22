using System.Collections.Generic;
using System.IO;
using WordCount.Interfaces;

namespace WordCount
{
    public class FileReader : IFileReader
    {
        private FileStream fileStream;
        private readonly string fileName;

        public FileReader(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<char> GetCharacters()
        {
            try
            {
                this.fileStream = new FileStream(this.fileName, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(this.fileStream))
                {
                    while (!streamReader.EndOfStream)
                    {
                        yield return (char) streamReader.Read();
                    }
                }
            }
            finally
            {
                fileStream.DisposeIfNotNull();
            }
        }
    }
}