using System;
using System.Collections.Generic;
using System.Text;

namespace Implementing_List_and_Stack
{
    public class CustomList
    {
        private int[] items;
        private const int INITIAL_CAPACITY = 2;

        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get ; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        private void Resize()
        {
            int[] resizedArray = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                resizedArray[i] = this.items[i];
            }
            this.items = resizedArray;
        }

        private void Shrink()
        {
            int[] shrinkedArray = new int[this.items.Length / 2];

            for (int i = 0; i < shrinkedArray.Length; i++)
            {
                shrinkedArray[i] = this.items[i];
            }
            this.items = shrinkedArray;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int item = this.items[index];
            this.items[index] = default;
            this.ShiftLeft(index);
            this.Count--;
            

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        public void Insert(int index, int item)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            this.Count++;
            this.items[index] = item;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == item)
                    return true;
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= this.Count || secondIndex < 0 ||
                secondIndex >= this.Count || secondIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public int Find(Predicate<int> match)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (match(this.items[i]))
                {
                    return this.items[i];
                }
            }
            return default;
        }

        public void Reverse()
        {
            int[] reversedArray = new int[this.items.Length];

            for (int i = 0, j = this.Count - 1; i < this.Count; i++, j--)
            {
                reversedArray[i] = this.items[j];
            }
            this.items = reversedArray;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.Append(this.items[i] + " ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
