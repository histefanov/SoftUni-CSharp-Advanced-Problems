using System;
using System.IO.Compression;

namespace _06.Zip_And_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../../FilesToZip", "../../../ZippedFiles/png.zip");
            ZipFile.ExtractToDirectory("../../../ZippedFiles/png.zip", "../../../ExtractedZip");
        }
    }
}
