using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerWeb.Services
{
    internal class AnagramComparer : IAnagramComparer
    {
        private readonly ILogger<AnagramComparer> logger;

        public AnagramComparer(ILogger<AnagramComparer> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<string> Compare(IEnumerable<string> anagrams, string word)
        {
            var ret = new List<string>();
            foreach (var anag in anagrams)
            {
                var words = anag.Split(' ');

                if(words[0].Equals(word))
                {
                    ret.Add(words[1]);
                }
                else if(words[1].Equals(word))
                {
                    ret.Add(words[0]);
                }
            }
            return ret;
        }
    }
}
