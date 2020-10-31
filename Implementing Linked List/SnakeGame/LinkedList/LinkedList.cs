using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public Node Peek()
        {
            return this.Head;
        }
        public void ForEach(Action<Node> action)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }

        public void ReverseForEach(Action<Node> action)
        {
            var currentNode = Tail;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Previous;
            }
        }

        public void AddHead(Node newHead)
        {
            if (Head == null)
            {
                Head = Tail = newHead;
            }
            else
            {
                newHead.Next = Head;
                Head.Previous = newHead;
                Head = newHead;
            }
        }

        public void AddTail(Node newTail)
        {
            if (Tail == null)
            {
                Head = Tail = newTail;
            }
            else
            {
                newTail.Previous = Tail;
                Tail.Next = newTail;
                Tail = newTail;
            }
        }

        public void PrintList()
        {
            ForEach(x => Console.WriteLine(x.Value));
        }

        public void ReversePrintList()
        {
            var currentNode = Tail;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }

        public Node RemoveFirst()
        {
            var oldHead = Head;
            Head = Head.Next;
            Head.Previous = null;
            return oldHead;
        }

        public Node RemoveLast()
        {
            var oldTail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            return oldTail;
        }

        public Position[] ToArray()
        {
            var resultList = new List<Position>();
            this.ForEach(x => resultList.Add(x.Value));
            return resultList.ToArray();
        }
    }
}
