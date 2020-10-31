using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string operation;
            while ((operation = Console.ReadLine()) != "end")
            {
                if (operation == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                }
                else
                {
                    Func<int, int> operationDelegate = operation switch
                    {
                        "add" => n => n + 1,
                        "multiply" => n => n * 2,
                        "subtract" => n => n - 1,
                        _ => n => n
                    };
                    nums = nums.Select(operationDelegate).ToArray();
                }
            }
        }

        //static Func<int, int> GetOperation(string operation)
        //{
        //    switch (operation)
        //    {
        //        case "add": return n => n + 1;
        //        case "multiply": return n => n * 2;
        //        case "subtract": return n => n - 1;
        //        default:
        //            return null;
        //    }
        //}
    }
}
