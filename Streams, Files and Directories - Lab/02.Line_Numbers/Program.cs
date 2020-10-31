using System;
using System.IO;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../input.txt"))
            {
                using (var writer = new StreamWriter("../../../output.txt"))
                {
                    string line = reader.ReadLine();
                    int lineNumber = 1;
                    while (line != null)
                    {
                        writer.WriteLine("{0}. {1}", lineNumber, line);
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
