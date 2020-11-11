using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int target = int.Parse(Console.ReadLine());

            int targetIndex = BinarySearch(nums, target, 0, nums.Length);
            Console.WriteLine($"Index found: {targetIndex}");
        }

        public static int BinarySearch(int[] arr, int target, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int midPoint = (start + end) / 2;

            if (target < arr[midPoint])
            {
                return BinarySearch(arr, target, start, midPoint - 1);
            }
            else if (target > arr[midPoint])
            {
                return BinarySearch(arr, target, midPoint + 1, end);
            }
            else
            {
                return midPoint;
            }
        }
    }
}
