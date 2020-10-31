using System;
using System.Collections.Generic;

namespace _08.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carCounter = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    int carsToPass = Math.Min(numberOfCars, cars.Count);
                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carCounter++;
                    }
                }
            }

            Console.WriteLine($"{carCounter} cars passed the crossroads.");
        }
    }
}
