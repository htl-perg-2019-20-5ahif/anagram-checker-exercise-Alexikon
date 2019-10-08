using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerWeb.Services
{
    public class AnagramFileReader : IAnagramReader
    {
        private readonly IConfiguration config;
        private readonly ILogger<AnagramFileReader> logger;

        public AnagramFileReader(IConfiguration config, ILogger<AnagramFileReader> logger)
        {
            this.config = config;
            this.logger = logger;
        }

        /// <summary>
        /// Reads the anagram file
        /// </summary>
        /// <returns>Content of the anagram file</returns>
        public async Task<IEnumerable<string>> ReadAnagram()
        {
            var anagFile = config["anagramFileName"];
            var anagramText = await System.IO.File.ReadAllLinesAsync(anagFile);
            return anagramText;
        }
    }
}
