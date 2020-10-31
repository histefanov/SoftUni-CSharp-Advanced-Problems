using System;
using System.Linq;

namespace _02.SumNums
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> intParser = str => int.Parse(str);
            int[] nums = Console.ReadLine()
                .Split(", ")
                .Select(intParser)
                .ToArray();

            PrintResult(nums, x => x.Length, GetSum);
        }

        static int GetSum(int[] nums)
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }
            return sum;
        }
        
        static int GetCount(int[] nums)
        {
            return nums.Length;
        }

        static void PrintResult(int[] nums, Func<int[], int> count, Func<int[], int> sum)
        {
            Console.WriteLine(count(nums));
            Console.WriteLine(sum(nums));
        }
    }
}
