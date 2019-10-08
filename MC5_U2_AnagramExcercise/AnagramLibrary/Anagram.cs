using System;

namespace AnagramLibrary
{
    public class Anagram
    {
        public string WordOne { get; set; }

        public string WordTwo { get; set; }

        public static Boolean CheckAnagram(string Word1, string Word2)
        {
            char[] chArr1 = Word1.ToCharArray();
            char[] chArr2 = Word2.ToCharArray();
            Array.Sort(chArr1);
            Array.Sort(chArr2);
            string val1 = new string(chArr1);
            string val2 = new string(chArr2);

            return val1 == val2;
        }

        public Boolean IsAnagram(string Word1, string Word2)
        {
            return Anagram.CheckAnagram(WordOne, WordTwo);
        }
    }
}
