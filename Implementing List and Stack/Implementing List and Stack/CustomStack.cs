using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_List_and_Stack
{
    public class CustomStack<T>
    {
        private const int INITIAL_CAPACITY = 4;
        private T[] items;

        public CustomStack()
        {
            this.items = new T[INITIAL_CAPACITY];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.items.Length)
            {
                T[] copy = new T[this.items.Length * 2];

                for (int i = 0; i < this.Count; i++)
                {
                    copy[i] = this.items[i];
                }
                this.items = copy;
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            T poppedItem = this.items[this.Count - 1];
            this.Count--;
            return poppedItem;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            return this.items[this.Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
