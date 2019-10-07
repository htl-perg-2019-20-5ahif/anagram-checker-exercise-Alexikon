using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramCheckerWeb.Services;
using AnagramLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnagramCheckerWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AnagramController : ControllerBase
    {
        private readonly IAnagramReader reader;
        private readonly IDictionaryComparer comparer;

        public SpellCheckerController(IAnagramReader reader, IDictionaryComparer comparer)
        {
            this.reader = reader;
            this.comparer = comparer;
        }





        
    }
}
