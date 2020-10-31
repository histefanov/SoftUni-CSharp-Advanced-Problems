using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class StackElement<T>
    {
        public StackElement(T value)
        {
            this.Value = value;
        }
        public StackElement<T> Next { get; set; }
        public T Value { get; set; }
    }
}
