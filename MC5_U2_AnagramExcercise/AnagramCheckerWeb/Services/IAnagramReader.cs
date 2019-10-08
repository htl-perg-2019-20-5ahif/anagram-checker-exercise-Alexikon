using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramCheckerWeb.Services
{
    interface IAnagramReader
    {
        Task<IEnumerable<string>> ReadAnagram();
    }
}
