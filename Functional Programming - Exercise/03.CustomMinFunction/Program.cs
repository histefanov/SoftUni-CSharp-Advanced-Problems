using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> getMin = nums =>
            {
                int minNumber = int.MaxValue;

                foreach (var num in nums)
                {
                    if (num < minNumber)
                        minNumber = num;
                }
                return minNumber;
            };

            int[] nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(getMin(nums));
        }
    }
}
