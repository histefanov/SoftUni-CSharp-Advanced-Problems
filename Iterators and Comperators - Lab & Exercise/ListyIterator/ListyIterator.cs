using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;
        private List<T> internalCollection;

        public ListyIterator(T[] collection)
        {
            this.internalCollection = collection.ToList();
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.internalCollection.Count > 0)
            {
                return index + 1 < this.internalCollection.Count;
            }
            return false;
        }

        public void Print()
        {
            if (this.internalCollection.Count > 0 && this.index < this.internalCollection.Count)
            {
                Console.WriteLine(this.internalCollection[this.index]);
            }
            else
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public void PrintAll()
        {
            foreach (var item in this.internalCollection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.internalCollection.Count; i++)
            {
                yield return this.internalCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
