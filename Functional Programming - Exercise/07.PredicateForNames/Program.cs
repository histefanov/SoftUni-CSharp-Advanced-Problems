using System;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthFilter = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> printer = n =>
            {
                if (n.Length <= lengthFilter)
                    Console.WriteLine(n);
            };

            foreach (var name in names)
            {
                printer(name);
            }
        }
    }
}
