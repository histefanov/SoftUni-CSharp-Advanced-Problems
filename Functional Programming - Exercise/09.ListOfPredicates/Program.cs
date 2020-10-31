using System;
using System.Linq;

namespace _09.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Select(int.Parse)
                .OrderByDescending(n => n)
                .ToArray();

            for (int i = 1; i <= n; i++)
            {
                if (IsDivisible(i, dividers))
                {
                    Console.Write(i + " ");
                }
            }
        }

        static bool IsDivisible(int num, int[] dividers)
        {
            foreach (var divider in dividers)
            {
                if (num % divider != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
