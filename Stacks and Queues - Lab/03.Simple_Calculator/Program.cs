using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);
            // 2 + 5 + 10 - 2 - 1
            while (stack.Count > 1)
            {
                int firstOperand = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int secondOperand = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    stack.Push((firstOperand + secondOperand).ToString());
                }
                else
                {
                    stack.Push((firstOperand - secondOperand).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
