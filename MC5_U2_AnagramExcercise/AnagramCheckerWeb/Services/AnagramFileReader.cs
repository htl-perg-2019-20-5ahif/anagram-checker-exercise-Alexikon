using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerWeb.Services
{
    public class AnagramFileReader : IAnagramReader
    {
        private readonly IConfiguration config;
        private readonly ILogger<DictionaryFileReader> logger;

        public AnagramFileReader(IConfiguration config, ILogger<DictionaryFileReader> logger)
        {
            this.config = config;
            this.logger = logger;
        }

        /// <summary>
        /// Reads the dictionary file
        /// </summary>
        /// <returns>Content of the dictionary file</returns>
        public async Task<string> ReadAnagram()
        {
            var dictFile = config["anagramFileName"];
            var dictionaryText = await System.IO.File.ReadAllTextAsync(dictFile);
            return dictionaryText;
        }
    }
}
