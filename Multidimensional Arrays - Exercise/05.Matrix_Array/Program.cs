using System;
using System.Linq;

namespace _05.Matrix_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string snakeChars = Console.ReadLine();
            int charCounter = 0;

            char[,] matrix = new char[sizes[0], sizes[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                if (r % 2 == 0)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        matrix[r, c] = snakeChars[charCounter % snakeChars.Length];
                        charCounter++;
                    }
                }
                else
                {
                    for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
                    {
                        matrix[r, c] = snakeChars[charCounter % snakeChars.Length];
                        charCounter++;
                    }
                }
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
