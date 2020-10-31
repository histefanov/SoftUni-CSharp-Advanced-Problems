using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse));

            Queue<int> threads = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            int taskToBeKilled = int.Parse(Console.ReadLine());
            bool isKilled = false;

            while (!isKilled)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (task == taskToBeKilled)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToBeKilled}");
                    isKilled = true;
                    continue;
                }

                threads.Dequeue();
                if (thread >= task)
                {
                    tasks.Pop();                 
                }
            }

            Console.WriteLine(string.Join(' ', threads));
        }
    }
}
