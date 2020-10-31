using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    customers.Enqueue(input);
                }
                else
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
