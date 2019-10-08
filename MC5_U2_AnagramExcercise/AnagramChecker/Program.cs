using AnagramLibrary;
using System;
using System.Threading.Tasks;

namespace AnagramChecker
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            if((args.Length < 2 || args.Length > 3))
            {
                falseInput();
                return 1;
            }

            int totalArgs = args.Length;
            for(int i = 0; i < totalArgs; i++)
            {
                if (string.IsNullOrEmpty(args[i]))
                {
                    falseInput();
                    return 1;
                }

                args[i] = args[i].ToLower();
            }

            if(args[0].Equals("check") && totalArgs == 3)
            {
                if(Anagram.CheckAnagram(args[1], args[2]))
                {
                    Console.WriteLine("\"" + args[1] + "\" and \"" + args[2] + "\" are anagrams");
                }
                else
                {
                    Console.WriteLine("\"" + args[1] + "\" and \"" + args[2] + "\" are no anagrams");
                }

                return 0;
            }
            else if(args[0].Equals("getknown") && totalArgs == 2)
            {
                var anagFile = "anagrams.txt";
                var anagramText = await System.IO.File.ReadAllLinesAsync(anagFile);
                int count = 0;

                foreach(var anag in anagramText)
                {
                    var words = anag.Split(' ');

                    if(words[0].Equals(args[1]))
                    {
                        Console.WriteLine(words[1]);
                        count++;
                    }
                    else if(words[1].Equals(args[1]))
                    {
                        Console.WriteLine(words[0]);
                        count++;
                    }
                }

                if(count == 0)
                {
                    Console.WriteLine("No known anagrams found");
                }

                return 0;
            }

            falseInput();
            return 1;
        }

        public static void falseInput()
        {
            Console.WriteLine("Commands for Program:\n" +
                    "AnagramChecker check <word1> <word2>\n" +
                    "AnagramChecker getKnown <word>");
        }
    }
}
