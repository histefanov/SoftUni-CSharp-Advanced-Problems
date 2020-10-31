using System;
using System.Collections.Generic;

namespace _08.Balanced_Parantheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> openingParantheses = new Stack<char>();
            string sequence = Console.ReadLine();
            bool isBalanced = true;

            for (int i = 0; i < sequence.Length; i++)
            {
                char currentParantheses = sequence[i];

                if (currentParantheses == '(' || currentParantheses == '{' | currentParantheses == '[')
                {
                    openingParantheses.Push(currentParantheses);
                }
                else if (openingParantheses.TryPop(out char lastElement))
                {
                    switch (currentParantheses)
                    {
                        case ')': if (lastElement != '(') isBalanced = false; break;
                        case '}': if (lastElement != '{') isBalanced = false; break;
                        case ']': if (lastElement != '[') isBalanced = false; break;
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine(isBalanced && sequence.Length > 1 ? "YES" : "NO");
        }
    }
}
