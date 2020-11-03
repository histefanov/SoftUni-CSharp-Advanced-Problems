using System;

namespace NFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(x));
        }

        static int Factorial(int x)
        {
            if (x == 1)
            {
                return 1;
            }

            return x * Factorial(x - 1);
        }
    }
}
