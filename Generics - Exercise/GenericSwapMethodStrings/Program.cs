using _01.GenericBoxOfString;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }

            string itemForComparison = Console.ReadLine();
            int largerItemsCounter = GenericMethods<string>.GetNumberOfLargerElements(boxes, itemForComparison);

            Console.WriteLine(largerItemsCounter);
        }
    }
}
