using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var pouch = new Pouch();

            Queue<int> bombEffects =
                new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            Stack<int> bombCasings =
                new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            while (!pouch.isFilled() && bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                int effect = bombEffects.Peek();
                int casing = bombCasings.Pop();
                int bombMixture = effect + casing;

                if (bombMixture == 40)
                {
                    bombEffects.Dequeue();
                    pouch.DaturaBombs++;
                }
                else if (bombMixture == 60)
                {
                    bombEffects.Dequeue();
                    pouch.CherryBombs++;
                }
                else if (bombMixture == 120)
                {
                    bombEffects.Dequeue();
                    pouch.SmokeDecoyBombs++;
                }
                else
                {
                    bombCasings.Push(casing - 5);
                }
            }

            if (pouch.isFilled())
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }

            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            Console.WriteLine(pouch.GetPouchContent());
        }

        class Pouch
        {
            public int DaturaBombs { get; set; }
            public int CherryBombs { get; set; }
            public int SmokeDecoyBombs { get; set; }

            public bool isFilled()
            {
                return DaturaBombs >= 3 && 
                       CherryBombs >= 3 && 
                       SmokeDecoyBombs >= 3;
            }

            public string GetPouchContent()
            {
                var sb = new StringBuilder();
                sb.AppendLine($"Cherry Bombs: {CherryBombs}");
                sb.AppendLine($"Datura Bombs: {DaturaBombs}");
                sb.AppendLine($"Smoke Decoy Bombs: {SmokeDecoyBombs}");
                return sb.ToString().TrimEnd();
            }
        }
    }
}
