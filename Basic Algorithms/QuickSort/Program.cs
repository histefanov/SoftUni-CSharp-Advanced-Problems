using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace QuickSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your array of integers, separated by whitespaces:");
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sortedArr = QuickSort(arr, 0, arr.Length - 1);

            Console.WriteLine($"Sorted array:{Environment.NewLine}{string.Join(", ", sortedArr)}");
        }

        public static int[] QuickSort(int[] arr, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(arr, start, end);
                QuickSort(arr, start, pivot - 1);
                QuickSort(arr, pivot + 1, end);
            }

            return arr;
        }
        public static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(arr, ++i, j);
                }
            }
            Swap(arr, ++i, end);
            return i;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
