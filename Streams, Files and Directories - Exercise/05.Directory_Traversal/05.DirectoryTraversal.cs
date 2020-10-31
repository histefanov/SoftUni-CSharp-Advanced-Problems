using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.Directory_Traversal
{

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> allFiles
                = new Dictionary<string, Dictionary<string, double>>();
            string[] files = Directory.GetFiles("MyFolder");

            foreach (var file in files)
            {
                FileInfo currentFile = new FileInfo(file);
                
                if (!allFiles.ContainsKey(currentFile.Extension))
                {
                    allFiles.Add(currentFile.Extension, new Dictionary<string, double>());
                }

                allFiles[currentFile.Extension].Add(currentFile.Name, currentFile.Length * 1.0 / 1024);
            }

            using (var writer = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/report.txt"))
            {
                foreach (var item in allFiles.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key))
                {
                    writer.WriteLine(item.Key);

                    foreach (var file in item.Value.OrderBy(f => f.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value:F3}kb");
                    }
                }
            }
        }
    }
}
