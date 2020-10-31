using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
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
            int numberOfElementsToPop = info[1];
            int elementToFind = info[2];

            int[] numsArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> nums = new Stack<int>(numsArray);

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                nums.Pop();
            }

            int currentSmallestNumber = int.MaxValue;

            if (nums.Count > 0)
            {
                while (nums.Count > 0)
                {
                    int currentNum = nums.Pop();

                    if (currentNum == elementToFind)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    else if (currentNum < currentSmallestNumber)
                    {
                        currentSmallestNumber = currentNum;
                    }
                }

                Console.WriteLine(currentSmallestNumber);
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
