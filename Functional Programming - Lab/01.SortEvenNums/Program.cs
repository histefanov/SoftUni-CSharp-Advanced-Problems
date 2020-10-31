using System;
using System.Linq;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ",
                Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)));
        }
    }
}
