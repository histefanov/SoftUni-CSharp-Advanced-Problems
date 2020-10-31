using System;
using System.IO;

namespace _01.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../input.txt"))
            {
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    int lineIndex = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (lineIndex % 2 == 1) writer.WriteLine(line);
                        lineIndex++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
