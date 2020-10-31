using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                Regex pattern = new Regex("[-,.!?]");
                int lineNumber = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (lineNumber % 2 == 0)
                    {
                        line = pattern.Replace(line, "@");
                        string reversedLine = string.Join(' ', line.Split(' ').Reverse());
                        Console.WriteLine(reversedLine);
                    }

                    line = reader.ReadLine();
                    lineNumber++;
                }
            }
        }
    }
}
