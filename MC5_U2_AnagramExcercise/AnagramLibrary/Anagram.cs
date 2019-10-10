using System;

namespace AnagramLibrary
{
    public class Anagram
    {
        public string W1 { get; set; }

        public string W2 { get; set; }

        public static bool CheckAnagram(string Word1, string Word2)
        {
            char[] chArr1 = Word1.ToCharArray();
            char[] chArr2 = Word2.ToCharArray();
            Array.Sort(chArr1);
            Array.Sort(chArr2);
            string val1 = new string(chArr1);
            string val2 = new string(chArr2);

            return val1.Equals(val2);
        }

        public bool IsAnagram()
        {
            return Anagram.CheckAnagram(W1, W2);
        }
    }
}
