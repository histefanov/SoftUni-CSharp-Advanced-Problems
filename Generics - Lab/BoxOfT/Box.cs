using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private const int INITIAL_CAPACITY = 2;
        private T[] internalArray = new T[INITIAL_CAPACITY];

        public int Count { get; private set; }

        private void Resize()
        {
            T[] copy = new T[this.internalArray.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.internalArray[i];
            }
            this.internalArray = copy;
        }

        private void Shrink()
        {
            T[] copy = new T[this.internalArray.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.internalArray[i];
            }
            this.internalArray = copy;
        }

        private void ShiftAllRight()
        {
            for (int i = this.Count; i > 0; i--)
            {
                this.internalArray[i] = this.internalArray[i - 1];
            }
        }

        private void ShiftAllLeft()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.internalArray[i] = this.internalArray[i + 1];
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.internalArray.Length)
            {
                this.Resize();
            }

            this.ShiftAllRight();
            this.internalArray[0] = item;
            this.Count++;
        }

        public void Print()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Console.Write(this.internalArray[i] + " ");
            }
            Console.WriteLine();
        }

        public T Remove()
        {
            T item = this.internalArray[0];
            this.ShiftAllLeft();
            this.Count--;

            if (this.Count <= this.internalArray.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }
    }
}
