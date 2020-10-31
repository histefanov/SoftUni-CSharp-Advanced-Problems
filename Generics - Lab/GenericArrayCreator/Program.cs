using System;
using System.Collections.Generic;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var res = ArrayCreator.Create(5, 5);
            Console.WriteLine(string.Join(" <3 ", res));
        }
    }
}
