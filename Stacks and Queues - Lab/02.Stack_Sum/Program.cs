using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var num in nums)
            {
                stack.Push(num);
            }

            string[] command = Console.ReadLine().Split();
            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "add")
                {
                    stack.Push(int.Parse(command[1]));
                    stack.Push(int.Parse(command[2]));
                }
                else
                {
                    int numsToRemove = int.Parse(command[1]);

                    if (numsToRemove <= stack.Count)
                    {
                        for (int i = 0; i < numsToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }

            int sum = 0;

            while (stack.Count > 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
