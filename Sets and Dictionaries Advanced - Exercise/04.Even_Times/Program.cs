using System;
using System.Collections.Generic;

namespace _04.Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nums = new Dictionary<string, int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string currentNum = Console.ReadLine();
                if (!nums.ContainsKey(currentNum))
                {
                    nums.Add(currentNum, 0);
                }
                nums[currentNum]++;
            }

            foreach (var num in nums)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                    return;
                }
            }
        }
    }
}
