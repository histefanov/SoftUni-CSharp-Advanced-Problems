using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            Queue<int> route = new Queue<int>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] tankInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                route.Enqueue(tankInfo[0] - tankInfo[1]);
            }

            for (int i = 0; i < numberOfPumps; i++)
            {
                Queue<int> currentRoute = new Queue<int>(route);
                route.Enqueue(route.Dequeue());
                int fuelTankContent = 0;

                while (currentRoute.Count > 0)
                {
                    fuelTankContent += currentRoute.Dequeue();

                    if (fuelTankContent < 0) break;                
                }

                if (fuelTankContent >= 0)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
        }
    }
}
