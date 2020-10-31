using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //PrintCapitalWords(words, IsCapital);

            Func<string, bool> checker = (w) => w[0] == w.ToUpper()[0];
            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)));
        }

        //static string[] ExtractWords(string text)
        //{
        //    var wordsCollection = new Regex(@"\b[A-Za-z]+\b").Matches(text);
        //    string[] words = new string[wordsCollection.Count];

        //    for (int i = 0; i < wordsCollection.Count; i++)
        //    {
        //        words[i] = wordsCollection[i].Value;
        //    }

        //    return words;
        //}

        //static bool IsCapital(string word)
        //{
        //    return word[0] == word.ToUpper()[0];
        //}

        //static void PrintCapitalWords(string[] words, Func<string, bool> capitalChecker)
        //{
        //    foreach (var word in words)
        //    {
        //        if (capitalChecker(word))
        //        {
        //            Console.WriteLine(word);
        //        }
        //    }
        //}
    }
}
