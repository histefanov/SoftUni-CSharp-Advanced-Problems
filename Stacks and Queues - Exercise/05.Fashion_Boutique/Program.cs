using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            int racksUsedCounter = 0;
            int rackedClothes = 0;

            Stack<int> clothes = new Stack<int>(clothesArray);

            while (clothes.Count > 0)
            {
                if (rackedClothes + clothes.Peek() < rackCapacity)
                {
                    rackedClothes += clothes.Pop();
                }
                else if (rackedClothes + clothes.Peek() == rackCapacity)
                {
                    clothes.Pop();
                    rackedClothes = 0;
                    if (clothes.Count > 0) racksUsedCounter++;
                }
                else
                {
                    racksUsedCounter++;
                    rackedClothes = 0;
                }
            }
            Console.WriteLine(++racksUsedCounter);
        }
    }
}
