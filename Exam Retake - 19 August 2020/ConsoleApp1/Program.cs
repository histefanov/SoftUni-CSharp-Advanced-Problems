using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lillies = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            int wreathsCrafted = 0;
            int flowerLeftovers = 0;

            while (lillies.Count > 0 && roses.Count > 0)
            {
                int lilly = lillies.Pop();
                int rose = roses.Peek();
                int combined = lilly + rose;

                if (combined == 15)
                {
                    roses.Dequeue();
                    wreathsCrafted++;
                }
                else if (combined > 15)
                {
                    lillies.Push(lilly - 2);
                }
                else
                {
                    flowerLeftovers += combined;
                    roses.Dequeue();
                }
            }

            wreathsCrafted += flowerLeftovers / 15;

            if (wreathsCrafted >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCrafted} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCrafted} wreaths more!");
            }
        }
    }
}
