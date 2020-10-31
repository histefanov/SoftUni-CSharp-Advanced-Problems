using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_And_Minimum_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> elements = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                switch (input[0])
                {
                    case "1":
                        int element = int.Parse(input[1]);
                        elements.Push(element);
                        break;

                    case "2":
                        if (elements.Count > 0) elements.Pop();
                        break;

                    case "3":
                        if (elements.Count > 0) Console.WriteLine(elements.Max());
                        break;

                    case "4":
                        if (elements.Count > 0) Console.WriteLine(elements.Min());
                        break;
                }
            }
            List<int> remainingElements = new List<int>();

            while (elements.Count > 0)
            {
                remainingElements.Add(elements.Pop());
            }

            Console.WriteLine(string.Join(", ", remainingElements));
        }
    }
}
