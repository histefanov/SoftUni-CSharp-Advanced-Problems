using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> chemicalElements = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var element in input)
                {
                    chemicalElements.Add(element);
                }
            }

            chemicalElements
                .OrderBy(el => el)
                .ToList()
                .ForEach(el => Console.Write(el + " "));
        }
    }
}
