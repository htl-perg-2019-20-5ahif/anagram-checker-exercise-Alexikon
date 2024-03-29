﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramCheckerWeb.Services;
using AnagramLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramCheckerWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AnagramController : ControllerBase
    {
        private readonly IAnagramReader reader;
        private readonly IAnagramComparer comparer;
        private readonly IAnagramPermutater permutater;
        private readonly ILogger<AnagramController> logger;

        public AnagramController(IAnagramReader reader, IAnagramComparer comparer, IAnagramPermutater permutater, ILogger<AnagramController> logger)
        {
            this.reader = reader;
            this.comparer = comparer;
            this.permutater = permutater;
            this.logger = logger;
        }

        [HttpGet]
        [Route("checkAnagram/")]
        public IActionResult CheckAnagram([FromBody] Anagram anagram)
        {
            if(anagram == null || string.IsNullOrEmpty(anagram.W1) || string.IsNullOrEmpty(anagram.W2))
            {
                BadRequest();
            }

            if(anagram.IsAnagram())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("getKnownAnagrams/")]
        public async Task<IActionResult> GetKnownAnagrams([FromQuery(Name = "w")] string word)
        {
            if(string.IsNullOrEmpty(word))
            {
                BadRequest();
            }

            var anagrams = await reader.ReadAnagram();

            var foundAnag = comparer.Compare(anagrams, word);

            if(foundAnag.Count() > 0)
            {
                return Ok(foundAnag);
            }

            logger.LogWarning("word \"{word}\" not found in anagram list", word);
            return NotFound();
        }

        [HttpGet]
        [Route("getPermutations/")]
        public IActionResult GetPermutations([FromQuery(Name = "w")] string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                BadRequest();
            }

            var perumutated = permutater.Permutate(word);
            return Ok(perumutated);
        }
    }
}
