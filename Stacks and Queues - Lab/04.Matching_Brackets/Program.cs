using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input [i] == ')')
                {
                    int openingParanthesesIndex = stack.Pop();
                    int closingParanthesesIndex = i;

                    Console.WriteLine(input.Substring(openingParanthesesIndex, closingParanthesesIndex - openingParanthesesIndex + 1));
                }
            }

        }
    }
}
