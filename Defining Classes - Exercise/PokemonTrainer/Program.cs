using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string line;
            while ((line = Console.ReadLine()) != "Tournament")
            {
                string[] pokeInfo = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = pokeInfo[0];
                string pokemonName = pokeInfo[1];
                string element = pokeInfo[2];
                int health = int.Parse(pokeInfo[3]);

                if (!trainers.Exists(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }
                trainers[trainers.FindIndex(t => t.Name == trainerName)]
                    .Pokemons.Add(new Pokemon(pokemonName, element, health));
            }

            string targetElement;
            while ((targetElement = Console.ReadLine()) != "End")
            {
                trainers.ForEach(t =>
                {
                    if (t.Pokemons.Any(p => p.Element == targetElement))
                    {
                        t.Badges++;
                    }
                    else
                    {
                        t.Pokemons.ForEach(p =>
                        {
                            p.Health -= 10;                           
                        });

                        t.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                });
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
