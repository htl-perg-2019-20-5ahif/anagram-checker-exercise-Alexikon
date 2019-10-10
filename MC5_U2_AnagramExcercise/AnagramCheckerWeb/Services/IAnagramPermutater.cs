using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerWeb.Services
{
    public interface IAnagramPermutater
    {
        IEnumerable<string> Permutate(string word);
    }
}
