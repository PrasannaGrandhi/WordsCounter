using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounter
{
    public interface IFile
    {
        public int GetDistinctWordsCount();
        public Dictionary<string, int> ProcessDistinctWords();
    }
}
