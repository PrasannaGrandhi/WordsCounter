namespace WordsCounter
{
    public class TextFile : IFile
    {
        char[] seperators = { ' ', ',', '.' };
        private readonly ICounter _counter;
        private readonly IEnumerable<string> _words;

        public TextFile(ICounter counter, string inputFile)
        {
            _counter = counter;
            _words = ReadWords(inputFile).Result;
        }

        public int GetDistinctWordsCount()
        {
            return _words.Distinct().Count();
        }

        public Dictionary<string, int> ProcessDistinctWords()
        {
            return _counter.CountInParallel(_words);
        }

        private async Task<IEnumerable<string>> ReadWords(string inputFile)
        {
            List<string> words = [];
            using StreamReader reader = File.OpenText(inputFile);
            string? lineText;
            while ((lineText = await reader.ReadLineAsync()) != null)
            {
                lock (words)
                {
                    var splitWords = lineText.Split(seperators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    words.AddRange(splitWords);
                }
            };
            return words;
        }

    }
}
