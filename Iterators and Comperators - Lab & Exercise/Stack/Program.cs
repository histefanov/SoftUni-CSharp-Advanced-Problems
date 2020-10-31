using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input.StartsWith("Push"))
                {
                    int[] tokens = input
                        .Substring(4)
                        .TrimStart()
                        .Split(", ")
                        .Select(int.Parse)
                        .ToArray();

                    foreach (var token in tokens)
                    {
                        stack.Push(token);
                    }
                }
                else
                {
                    stack.Pop();
                }
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }           
        }
    }
}
