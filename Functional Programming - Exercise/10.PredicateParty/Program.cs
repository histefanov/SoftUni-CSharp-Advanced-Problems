using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split();

                Func<string, bool> condition = tokens[1] switch
                {
                    "StartsWith" => str => str.Substring(0, tokens[2].Length) == tokens[2],
                    "EndsWith" => str => str.Substring(str.Length - tokens[2].Length, tokens[2].Length) == tokens[2],
                    "Length" => str => str.Length == int.Parse(tokens[2]),
                    _ => throw new NotImplementedException()
                };

                if (tokens[0] == "Remove")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (condition(guests[i])) 
                        {
                            guests.RemoveAt(i);
                            i--;
                        }
                    }
                }
                else if (tokens[0] == "Double")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (condition(guests[i]))
                        {
                            guests.Insert(i, guests[i]);
                            i++;
                        }
                    }
                }
            }
            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
