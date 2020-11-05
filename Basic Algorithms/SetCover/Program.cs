using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine()
                .Substring(10)
                .Split(", ")
                .Select(int.Parse)
                .ToList();

            int numberOfSets = int.Parse((Console.ReadLine().Last().ToString()));
            
            var setList = new List<int[]>();
            var resultSets = new List<int[]>();

            for (int i = 0; i < numberOfSets; i++)
            {
                int[] currentSet = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                setList.Add(currentSet);
            }
            
            while (universe.Count > 0)
            {
                var currentSet = setList.OrderByDescending(s => s.Count(universe.Contains))
                    .FirstOrDefault();
                setList.Remove(currentSet);
                resultSets.Add(currentSet);
                foreach (var item in currentSet)
                {
                    universe.Remove(item);
                }
            }

            Console.WriteLine($"Sets to take ({resultSets.Count}):");
            foreach (var set in resultSets)
            {
                var setString = String.Join(", ", set);
                Console.WriteLine($"{{ {setString} }}");
            }
        }
    }
}
