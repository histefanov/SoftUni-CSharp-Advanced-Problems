using System;
using System.Linq;

namespace _05.Square_With_Max_Sum
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

            for (int row = 0; row < sizes[0]; row++)
            {
                int[] line = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int currentBiggestSum = int.MinValue;
            int[,] submatrix = new int[2, 2];
            int[,] currentBestSubmatrix = new int[2, 2];

            for (int row = 0; row < sizes[0] - 1; row++)
            {
                for (int col = 0; col < sizes[1] - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (sum > currentBiggestSum)
                    {
                        currentBiggestSum = sum;
                        currentBestSubmatrix[0, 0] = matrix[row, col];
                        currentBestSubmatrix[0, 1] = matrix[row, col + 1];
                        currentBestSubmatrix[1, 0] = matrix[row + 1, col];
                        currentBestSubmatrix[1, 1] = matrix[row + 1, col + 1];
                    }
                }
            }

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    Console.Write(currentBestSubmatrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(currentBiggestSum);
        }
    }
}
