using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerWeb.Services
{
    internal class AnagramPermutater : IAnagramPermutater
    {
        public IEnumerable<string> Permutate(string word)
        {
            if (word.Length == 1) return new List<string> { word };

            var permutations = from c in word
                               from p in Permutate(new String(word.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }
    }
}
