using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void ForEach(Action<Node> action)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                action(currentNode);
                currentNode = currentNode.Next;
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

        public bool Remove(int value)
        {
            var currentNode = Head;
            var isFound = false;

            while (!isFound && currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    if (currentNode == Head)
                    {
                        this.RemoveFirst();
                    }
                    else if (currentNode == Tail)
                    {
                        this.RemoveLast();   
                    }
                    else
                    {
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                    }
                    isFound = true;
                }
                currentNode = currentNode.Next;
            }
            return isFound;
        }

        public int[] ToArray()
        {
            var resultList = new List<int>();
            this.ForEach(x => resultList.Add(x.Value));
            return resultList.ToArray();
        }
    }
}
