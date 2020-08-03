using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }
        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";
            List<Pair> lstPair = new List<Pair>();
            foreach (var letter in word)
            {
                if (lstPair.Any(x => x.charName == letter.ToString()))
                {
                    lstPair.Where(x => x.charName == letter.ToString()).ToList().ForEach(x => x.charCount++);
                }
                else
                {
                    Pair pair = new Pair();
                    pair.charName = letter.ToString();
                    pair.charCount = 1;
                    lstPair.Add(pair);
                }
            }
            foreach (var pair in lstPair)
            {
                Console.WriteLine("Charact Name:" + pair.charName + "Character Count;" + pair.charCount);
            }           
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            foreach (var letter in a)
            {
                if (!b.Contains(letter.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
    public class Pair
    {
        public string charName { get; set; } 
        public int charCount { get; set; }
    }
}
