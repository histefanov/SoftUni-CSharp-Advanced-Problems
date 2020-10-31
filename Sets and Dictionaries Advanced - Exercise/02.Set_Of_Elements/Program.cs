using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Set_Of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < lengths[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < lengths[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            //foreach (var num in firstSet)
            //{
            //    if (secondSet.Contains(num)) Console.Write(num + " ");
            //}

            Console.WriteLine(string.Join(" ", firstSet.Intersect(secondSet)));
        }
    }
}
