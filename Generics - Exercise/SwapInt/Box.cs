using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {

        public Box(T content)
        {
            this.Content = content;
        }

        public T Content { get; set; }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.Content}";
        }
    }
}
