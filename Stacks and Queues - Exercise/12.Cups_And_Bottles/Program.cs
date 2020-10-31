using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Cups_And_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Stack<int> bottles = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int currentCup = 0, currentBottle = 0, wastedWater = 0, temp = 0;

            while ((cups.Count > 0 || currentCup > 0) && bottles.Count > 0)
            {
                if (currentCup <= 0)
                {
                    currentCup = cups.Dequeue();
                }

                currentBottle = bottles.Pop();
                temp = currentBottle;
                currentBottle -= currentCup;
                currentCup -= temp;
                if (currentBottle > 0) wastedWater += currentBottle;
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            else if (bottles.Count == 0)
            {
                if (cups.Count > 0)
                {
                    if (currentCup > 0)
                    {
                        Console.WriteLine($"Cups: {currentCup} {string.Join(' ', cups)}");
                    }
                    else
                    {
                        Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                    }
                }
                else if (currentCup > 0)
                {
                    Console.WriteLine($"Cups: {currentCup}");
                }
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
