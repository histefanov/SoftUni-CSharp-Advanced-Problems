using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();          

            for (int i = 0; i < n; i++)
            {
                string[] member = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(member[0], int.Parse(member[1])));
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
