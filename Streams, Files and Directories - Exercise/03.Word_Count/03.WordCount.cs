using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordOccurences = new Dictionary<string, int>();
            string[] words = File.ReadAllLines("../../../words.txt");
            string text = File.ReadAllText("../../../text.txt");

            foreach (var word in words)
            {
                int wordCount = new Regex($@"\b{word}\b", RegexOptions.IgnoreCase).Matches(text).Count;
                wordOccurences.Add(word, wordCount);
            }

            List<string> resultLines = new List<string>();

            foreach (var word in wordOccurences.OrderByDescending(w => w.Value))
            {
                resultLines.Add($"{word.Key} - {word.Value}");
            }

            File.WriteAllText("../../../actualResult.txt", string.Join(Environment.NewLine, resultLines));
            Console.WriteLine($"Task successful: {CompareResults()}");
        }

        static bool CompareResults()
        {
            string actualResult = File.ReadAllText("../../../actualResult.txt");
            string expectedResult = File.ReadAllText("../../../expectedResult.txt");
            return actualResult == expectedResult;
        }
    }
}
