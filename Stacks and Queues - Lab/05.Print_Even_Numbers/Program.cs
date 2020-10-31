using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numsQueue = new Queue<int>();
            List<int> evenIntegers = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                numsQueue.Enqueue(nums[i]);
            }

            while (numsQueue.Count > 0)
            {
                int currentNum = numsQueue.Peek();
                if (currentNum % 2 == 0)
                {
                    evenIntegers.Add(numsQueue.Dequeue());
                }
                else
                {
                    numsQueue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenIntegers));
        }
    }
}
