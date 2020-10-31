using System;
using System.Linq;

namespace _03.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            int currentBiggestSum = int.MinValue;
            int bestRow = 0, bestColumn = 0;

            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    int sum = matrix[r, c] + matrix[r, c + 1] + matrix[r, c + 2]
                            + matrix[r + 1, c] + matrix[r + 1, c + 1] + matrix[r + 1, c + 2]
                            + matrix[r + 2, c] + matrix[r + 2, c + 1] + matrix[r + 2, c + 2];

                    if (sum > currentBiggestSum)
                    {
                        currentBiggestSum = sum;
                        bestRow = r;
                        bestColumn = c;
                    }
                }
            }

            Console.WriteLine("Sum = " + currentBiggestSum);
            Console.WriteLine("{0} {1} {2}\n{3} {4} {5}\n{6} {7} {8}", 
                matrix[bestRow, bestColumn], matrix[bestRow, bestColumn + 1], matrix[bestRow, bestColumn + 2],
                matrix[bestRow + 1, bestColumn], matrix[bestRow + 1, bestColumn + 1], matrix[bestRow + 1, bestColumn + 2],
                matrix[bestRow + 2, bestColumn], matrix[bestRow + 2, bestColumn + 1], matrix[bestRow + 2, bestColumn + 2]);
        }
    }
}
