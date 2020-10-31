using System;

namespace Demo
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            person.Age = 2;
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}
