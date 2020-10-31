using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linesArray = File.ReadAllLines("../../../text.txt");

            for (int i = 0; i < linesArray.Length; i++)
            {
                string currentLine = linesArray[i];
                int punctuationCount = new Regex(@"[,.!?\-':;]").Matches(currentLine).Count;
                int lettersCount = new Regex(@"[A-za-z]").Matches(currentLine).Count;

                linesArray[i] = $"Line {i + 1}: {currentLine} ({lettersCount})({punctuationCount})";
            }
            File.WriteAllLines("../../../output.txt", linesArray);
        }
    }
}
