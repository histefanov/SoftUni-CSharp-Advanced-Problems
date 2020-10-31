using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace _09.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<StringBuilder> previousInstances = new Stack<StringBuilder>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < numberOfOperations; i++)
            {               
                string[] @operation = Console.ReadLine().Split();
                string action = operation[0];

                switch (action)
                {
                    case "1":
                        previousInstances.Push(new StringBuilder(text.ToString()));
                        string str = operation[1];
                        text.Append(str);
                        break;
                    case "2":
                        previousInstances.Push(new StringBuilder(text.ToString()));
                        int count = int.Parse(operation[1]);
                        text.Remove(text.Length - count, count);
                        break;
                    case "3":
                        int index = int.Parse(operation[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = previousInstances.Pop();
                        break;
                }
            }
        }
    }
}
