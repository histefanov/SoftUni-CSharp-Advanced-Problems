using System;
using System.IO;

namespace _04.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstStreamReader = new StreamReader("../../../input1.txt");
            var secondStreamReader = new StreamReader("../../../input2.txt");

            using (var writer = new StreamWriter("../../../output.txt"))
            {
                string firstLine = firstStreamReader.ReadLine();
                string secondLine = secondStreamReader.ReadLine();
                bool thereIsMoreText = true;
                while (thereIsMoreText)
                {
                    if (firstLine != null)
                    {
                        writer.WriteLine(firstLine);
                    }
                    if (secondLine != null)
                    {
                        writer.WriteLine(secondLine);
                    }

                    if (firstLine == null && secondLine == null)
                    {
                        thereIsMoreText = false;
                    }

                    firstLine = firstStreamReader.ReadLine();
                    secondLine = secondStreamReader.ReadLine();
                }
            }
        }
    }
}
