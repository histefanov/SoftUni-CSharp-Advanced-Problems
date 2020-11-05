using System;
using System.Linq;

namespace SumOfCoins
{
    public class SumOfCoins
    {
        static void Main(string[] args)
        {
            int[] availableCoins = Console.ReadLine()
                .Substring(7)
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(c => c)
                .ToArray();
            int desiredSum = int.Parse(Console.ReadLine().Substring(5));
            int[] coinsCount = new int[availableCoins.Length];

            for (int i = 0; i < availableCoins.Length; i++)
            {
                coinsCount[i] += desiredSum / availableCoins[i];
                desiredSum -= coinsCount[i] * availableCoins[i];
            }

            if (desiredSum > 0)
            {
                Console.WriteLine("Error");
                return;
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {coinsCount.Aggregate((acc, next) => acc + next)}");
                for (int i = 0; i < availableCoins.Length; i++)
                {
                    if (coinsCount[i] > 0)
                    {
                        Console.WriteLine($"{coinsCount[i]} coin(s) with value {availableCoins[i]}");
                    }
                }
            }
        }
    }
}
