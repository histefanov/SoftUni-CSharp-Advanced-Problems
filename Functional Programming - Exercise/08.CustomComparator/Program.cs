using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(arr, (int a, int b) =>
            {
                if (Math.Abs(a % 2) > Math.Abs(b % 2))
                {
                    return 1;
                }
                else if (Math.Abs(a % 2) < Math.Abs(b % 2))
                {
                    return -1;
                }
                else
                {
                    return a.CompareTo(b);
                }
            });

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
