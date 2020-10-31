using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            using (var reader = new StreamReader("../../../words.txt"))
            {
                string currentWord = ExtractWord(reader);
                while (true)
                {
                    wordCounts.Add(currentWord.ToString(), 0);
                    currentWord = ExtractWord(reader);
                    if (reader.EndOfStream)
                    {
                        wordCounts.Add(currentWord.ToString(), 0);
                        break;
                    }
                }

            }

            using (var reader = new StreamReader("../../../input.txt"))
            {
                string currentLine = reader.ReadLine();
                var keys = new List<string>(wordCounts.Keys);
                while (currentLine != null)
                {
                    foreach (var word in keys)
                    {
                        var pattern = new Regex($@"\b{word}\b", RegexOptions.IgnoreCase);
                        wordCounts[word] += pattern.Matches(currentLine).Count;
                    }
                    currentLine = reader.ReadLine();
                }
            }

            var sortedWordCounts = wordCounts
                    .OrderByDescending(word => word.Value)
                    .ToDictionary(w => w.Key, w => w.Value);

            using (var writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var word in sortedWordCounts)
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        static string ExtractWord(StreamReader reader)
        {
            var sb = new StringBuilder();
            var currentChar = (char)reader.Read();

            while (currentChar != ' ')
            {
                sb.Append(currentChar);
                currentChar = (char)reader.Read();
                if (reader.EndOfStream)
                {
                    sb.Append(currentChar);
                    break;
                }
            }

            if (sb.Length > 0)
            {
                return sb.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
