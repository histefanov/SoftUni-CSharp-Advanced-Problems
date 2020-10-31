using System;
using System.Linq;

namespace _04.FindEvensOrOdss
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string condition = Console.ReadLine();

            Func<int, bool> conditionDelegate = GetCondition(condition);

            for (int i = range[0]; i <= range[1]; i++)
            {
                if(conditionDelegate(i))
                    Console.Write(i + " ");
            }
        }

        static Func<int, bool> GetCondition(string condition)
        {
            switch (condition)
            {
                case "even": return n => n % 2 == 0;
                case "odd": return n => n % 2 != 0;
                default:
                    return null;
            }
        }
    }
}
