using System;
using System.IO;

namespace _06.Directory_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("TestFolder");

            for (int i = 0; i < 5; i++)
            {
                using (var writer =
                new StreamWriter($"TestFolder/file{i+1}.txt"))
                {
                    writer.Write(Console.ReadLine());
                }
            }

            string[] files = Directory.GetFiles("TestFolder");
            double sizeSum = 0;

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                sizeSum += info.Length;
            }

            File.WriteAllText("../../../output.txt", (sizeSum / 1024 / 1024).ToString());
        }
    }
}
