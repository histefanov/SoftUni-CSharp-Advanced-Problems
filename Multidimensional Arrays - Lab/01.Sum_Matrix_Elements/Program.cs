using System;
using System.Linq;
using System.Numerics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int columns = input[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = line[column];
                }
            }

            int sum = 0;

            foreach (var num in matrix)
            {
                sum += num;
            }

            Console.WriteLine("{0}\n{1}\n{2}", rows, columns, sum);
        }
    }
}
