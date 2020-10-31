using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int i = 0; i < size; i++)
            {
                primaryDiagonalSum += matrix[i, i];
            }

            int secondaryDiagonalSum = 0;

            for (int i = size - 1; i >= 0; i--)
            {
                secondaryDiagonalSum += matrix[size - 1 - i, i];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
