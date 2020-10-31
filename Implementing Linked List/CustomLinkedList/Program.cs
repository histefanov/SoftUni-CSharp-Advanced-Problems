using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myLinkedList = new LinkedList();

            for (int i = 1; i <= 20; i++)
            {
                myLinkedList.AddHead(new Node(i));
            }

            Console.WriteLine("-- Initial LL:");
            myLinkedList.PrintList();
            Console.WriteLine(new string('-', 10));
            myLinkedList.Remove(1);
            myLinkedList.Remove(2);
            myLinkedList.Remove(21);
            myLinkedList.Remove(15);
            myLinkedList.PrintList();

            //myLinkedList.RemoveFirst();
            //myLinkedList.RemoveLast();
            //myLinkedList.PrintList();
            //Console.WriteLine(new string('-', 10));
            //myLinkedList.ForEach(x => Console.WriteLine($"current node: {x.Value}"));
            //Console.WriteLine(new string('-', 10));
            //Console.WriteLine("-- Reversed Print:");
            //myLinkedList.ReversePrintList();

            //for (int i = 55; i < 60; i++)
            //{
            //    myLinkedList.AddTail(new Node(i));
            //}
            //Console.WriteLine(new string('-', 10));
            //myLinkedList.PrintList();

            //Console.WriteLine(string.Join('>', myLinkedList.ToArray()));
        }
    }
}
