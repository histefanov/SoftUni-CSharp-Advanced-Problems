using _01.GenericBoxOfString;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GenericSwapMethodStrings
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            boxes = GenericMethods.Swap(boxes, indexes[0], indexes[1]);
            boxes.ForEach(b => Console.WriteLine(b.ToString()));
        }
    }
}
