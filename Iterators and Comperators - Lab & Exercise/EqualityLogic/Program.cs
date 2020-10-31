using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sortedSetOfPerson = new SortedSet<Person>();
            var hashSetOfPerson = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] personalInfo = Console.ReadLine().Split();
                string name = personalInfo[0];
                int age = int.Parse(personalInfo[1]);
                sortedSetOfPerson.Add(new Person(name, age));
                hashSetOfPerson.Add(new Person(name, age));
            }

            Console.WriteLine(sortedSetOfPerson.Count);
            Console.WriteLine(hashSetOfPerson.Count);
        }
    }
}
