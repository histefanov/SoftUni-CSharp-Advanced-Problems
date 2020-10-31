using System;
using System.Linq;

namespace _02.Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int currentSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    currentSum += matrix[row, col];
                }

                Console.WriteLine(currentSum);
            }
        }
    }
}
