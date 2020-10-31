using System;
using System.Linq;

namespace _07.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> divisibleFilter = n => n % divider != 0;
            nums = ReverseArray(nums.Where(divisibleFilter).ToArray());
            Console.WriteLine(string.Join(" ", nums));
        }


        static int[] ReverseArray(int[] nums)
        {
            int[] numsReversed = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                numsReversed[i] = nums[nums.Length - 1 - i];
            }

            return numsReversed;
        }
    }
}
