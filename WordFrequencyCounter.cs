using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounter
{
    public class WordFrequencyCounter : ICounter
    {
        public Dictionary<string, int> CountInParallel(IEnumerable<string> words)
        {
            Dictionary<string, int> wordsCount = new(StringComparer.OrdinalIgnoreCase);
            var lockObject = new Object();
            Parallel.ForEach(words, word =>
            {
                lock (lockObject)
                {
                    if (!wordsCount.TryAdd(word, 1))
                    {
                        wordsCount[word] += 1;
                    }
                }
            });
            return wordsCount;
        }
    }
}
