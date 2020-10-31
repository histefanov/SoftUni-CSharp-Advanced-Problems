using System;
using System.Collections;
using System.Collections.Generic;

namespace _07.Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] childrenNames = Console.ReadLine().Split();
            int numberOfTosses = int.Parse(Console.ReadLine());
            Queue<string> participants = new Queue<string>(childrenNames);

            while (participants.Count > 1)
            {
                for (int i = 1; i < numberOfTosses; i++)
                {
                    participants.Enqueue(participants.Dequeue());
                }
                Console.WriteLine($"Removed {participants.Dequeue()}"); 
            }

            Console.WriteLine($"Last is {participants.Peek()}");
        }
    }
}
