using System;
using System.Collections.Generic;

namespace Implementing_List_and_Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customStack = new CustomStack<int>();

            customStack.Push(1);
            customStack.Push(1);
            customStack.Push(1);

            Console.WriteLine(customStack.Count);
        }
    }
}
