using System;
using System.IO;

namespace _05.Slice_A_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            using (var writer = new StreamWriter("../../../allparts.txt")) writer.Write(text);
            int pieceCount = 4;

            using (var stream = new FileStream("../../../allparts.txt", FileMode.Open))
            {
                long size = stream.Length / pieceCount;

                for (int i = 0; i < pieceCount; i++)
                {
                    using (var pieceStream = 
                        new FileStream($"../../../part{i + 1}.txt", FileMode.OpenOrCreate))
                    {
                        byte[] buffer = new byte[1];

                        int count = 0;
                        while (count < size)
                        {
                            stream.Read(buffer, 0, buffer.Length);
                            pieceStream.Write(buffer, 0, buffer.Length);
                            count += buffer.Length;
                        }
                    }
                }
            }
        }
    }
}
