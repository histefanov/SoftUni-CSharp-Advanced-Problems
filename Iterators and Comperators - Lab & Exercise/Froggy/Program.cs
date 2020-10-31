using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            var lake = new Lake(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());

            var path = new List<int>();

            foreach (var stone in lake)
            {
                path.Add(stone);
            }

            Console.WriteLine(string.Join(", ", path));
        }
    }
}
