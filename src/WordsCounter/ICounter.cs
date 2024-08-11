using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounter
{
    public interface ICounter
    {
        Dictionary<string,int> CountInParallel(IEnumerable<string> items);
    }
}
