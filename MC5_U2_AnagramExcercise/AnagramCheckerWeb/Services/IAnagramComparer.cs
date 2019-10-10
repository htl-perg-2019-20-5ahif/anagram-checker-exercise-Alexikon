using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerWeb.Services
{
    public interface IAnagramComparer
    {
        IEnumerable<string> Compare(IEnumerable<string> anagrams, string word);
    }
}
