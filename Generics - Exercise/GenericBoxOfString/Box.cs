using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        private T content;

        public Box(T content)
        {
            this.content = content;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {this.content}";
        }
    }
}
