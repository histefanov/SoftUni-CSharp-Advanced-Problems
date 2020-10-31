using System;
using System.IO;

namespace _04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (var writer = new FileStream("../../../copiedImage.png", FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (reader.CanRead)
                    {
                        int bytesRead = reader.Read(buffer, 0, buffer.Length);
                        if (bytesRead == 0) break;

                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
