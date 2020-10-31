using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] info = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int numberOfElements = info[0];
            int elementsToDequeue = info[1];
            int elementToFind = info[2];

            int[] numsArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> nums = new Queue<int>(numsArray);

            for (int i = 0; i < elementsToDequeue; i++)
            {
                nums.Dequeue();
            }

            int currentSmallestElement = int.MaxValue;

            if (nums.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            while (nums.Count > 0)
            {
                int currentElement = nums.Dequeue();

                if (currentElement == elementToFind)
                {
                    Console.WriteLine("true");
                    return;
                }
                else if (currentElement < currentSmallestElement)
                {
                    currentSmallestElement = currentElement;
                }
            }

            Console.WriteLine(currentSmallestElement);
        }
    }
}
