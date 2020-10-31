using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityAvailable = int.Parse(Console.ReadLine());

            int[] ordersArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(ordersArray);

            Console.WriteLine(orders.Max());

            while (orders.Count > 0)
            {
                if (orders.Peek() <= quantityAvailable)
                {
                    quantityAvailable -= orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
                    return;
                }
            }

            Console.WriteLine("Orders complete");
        }
    }
}
