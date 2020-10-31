using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Queue<int> females = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                if (males.Peek() <= 0)
                {
                    males.Pop();
                    continue;
                }
                else if (males.Peek() % 25 == 0)
                {
                    males.Pop();
                    if (males.Count > 0)
                    {
                        males.Pop();
                    }
                    continue;
                }

                if (females.Peek() <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                else if (females.Peek() % 25 == 0)
                {
                    females.Dequeue();
                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                if (females.Peek() == males.Peek())
                {
                    matches++;
                    females.Dequeue();
                    males.Pop();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
            }

            Console.WriteLine($"Matches: {matches}");
            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
