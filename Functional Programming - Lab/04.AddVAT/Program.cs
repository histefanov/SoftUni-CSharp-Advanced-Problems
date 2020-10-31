using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = num => num * 1.2;
            double[] prices = Console.ReadLine()
                .Split(", ")
                .Select(p => double.Parse(p))
                .Select(addVAT)
                .ToArray();

            foreach (var item in prices)
            {
                Console.WriteLine(item.ToString("F"));
            }
        }
    }
}
