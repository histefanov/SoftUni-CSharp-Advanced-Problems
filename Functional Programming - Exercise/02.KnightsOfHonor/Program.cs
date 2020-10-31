using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printTitle = str => Console.WriteLine("Sir " + str);
            foreach (var knight in Console.ReadLine().Split(" "))
            {
                printTitle(knight);
            }
        }
    }
}
