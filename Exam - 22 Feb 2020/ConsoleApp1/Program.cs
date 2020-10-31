using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int claimedItems = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int sum = firstLootBox.Peek() + secondLootBox.Peek();

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }

            Console.WriteLine(firstLootBox.Count > 0 ? "Second lootbox is empty" : "First lootbox is empty");
            Console.WriteLine(claimedItems >= 100 ? 
                $"Your loot was epic! Value: {claimedItems}" :
                $"Your loot was poor... Value: {claimedItems}");
        }
    }
}
