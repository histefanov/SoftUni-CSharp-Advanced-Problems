using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> func = (str, length) =>
            {
                int sum = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    sum += str[i];
                }
                return sum >= length;
            };

            Console.WriteLine(GetTargetString(names, targetLength, func));
        }

        static string GetTargetString(string[] names, int targetLength, Func<string, int, bool> func)
        {
            foreach (var name in names)
            {
                if (func(name, targetLength))
                    return name;
            }
            throw new ArgumentNullException();
        } 
    }
}
