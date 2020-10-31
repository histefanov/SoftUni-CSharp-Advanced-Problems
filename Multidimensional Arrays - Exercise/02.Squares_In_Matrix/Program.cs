using System;
using System.Linq;

namespace _02.Squares_In_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[sizes[0], sizes[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] line = Console.ReadLine().Split();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            int equalityCounter = 0;

            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    if (
                        matrix[r, c].CompareTo(matrix[r, c + 1]) == 0 &&
                        matrix[r, c].CompareTo(matrix[r + 1, c]) == 0 &&
                        matrix[r, c].CompareTo(matrix[r + 1, c + 1]) == 0
                        )
                    {
                        equalityCounter++;
                    }
                }
            }

            Console.WriteLine(equalityCounter);
        }
    }
}
