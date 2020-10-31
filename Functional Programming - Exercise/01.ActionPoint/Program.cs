using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = str => Console.WriteLine(str);
            foreach (var word in Console.ReadLine().Split(" "))
            {
                print(word);
            }
        }
    }
}
