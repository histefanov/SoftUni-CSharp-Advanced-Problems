using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public StackElement<T> FirstElement { get; set; }

        public void Push(T newFirstElementValue)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new StackElement<T>(newFirstElementValue);
            }
            else
            {
                var newFirstElement = new StackElement<T>(newFirstElementValue);
                newFirstElement.Next = this.FirstElement;
                this.FirstElement = newFirstElement;
            }
        }

        public T Pop()
        {
            if (this.FirstElement != null)
            {
                var returnValue = FirstElement.Value;
                FirstElement = FirstElement.Next;
                return returnValue;
            }
            else
            {
                Console.WriteLine("No elements");
                return default;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.FirstElement;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
