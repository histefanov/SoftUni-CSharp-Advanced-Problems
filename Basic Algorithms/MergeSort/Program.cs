using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] res = MergeSort(arr);

            Console.WriteLine($"Sorted: {string.Join(", ", res)}");
        }

        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }

            int[] leftArr = arr.Take(arr.Length / 2).ToArray();
            int[] rightArr = arr.Skip(arr.Length / 2).ToArray();

            leftArr = MergeSort(leftArr);
            rightArr = MergeSort(rightArr);

            return Merge(leftArr, rightArr);
        }

        public static int[] Merge(int[] leftArr, int[] rightArr)
        {
            int[] mergedArr = new int[leftArr.Length + rightArr.Length];
            int i = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
            {
                if (leftArr[leftIndex] > rightArr[rightIndex])
                {
                    mergedArr[i] = rightArr[rightIndex];
                    rightIndex++;
                }
                else
                {
                    mergedArr[i] = leftArr[leftIndex];
                    leftIndex++;
                }

                i++;
            }

            while (leftIndex < leftArr.Length)
            {
                mergedArr[i] = leftArr[leftIndex];
                i++;
                leftIndex++;
            }

            while (rightIndex < rightArr.Length)
            {
                mergedArr[i] = rightArr[rightIndex];
                i++;
                rightIndex++;
            }

            return mergedArr;
        }
    }
}
