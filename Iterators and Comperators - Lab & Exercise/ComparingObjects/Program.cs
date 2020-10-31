using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                people.Add(new Person(input.Split()));
            }

            int index = int.Parse(Console.ReadLine());
            var personToCompare = people[index - 1];
            int equalityCounter = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (i == index - 1) continue;

                if (personToCompare.CompareTo(people[i]) == 0)
                {
                    equalityCounter++;
                }
            }

            if (equalityCounter > 0)
            {
                Console.WriteLine($"{++equalityCounter} {people.Count - equalityCounter} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
