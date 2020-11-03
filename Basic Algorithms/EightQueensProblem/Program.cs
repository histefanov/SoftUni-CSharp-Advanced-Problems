using System;

namespace EightQueensProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            Console.WriteLine(GetQueens(matrix, 0));
        }

        static int GetQueens(int[,] matrix, int row)
        {
            if (row == matrix.GetLength(0))
            {
                PrintMatrix(matrix);
                return 1;
            }

            int foundQueens = 0;

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (IsSafe(matrix, row, col))
                {
                    matrix[row, col] = 1;
                    foundQueens += GetQueens(matrix, row + 1);
                    matrix[row, col] = 0;
                }
            }

            return foundQueens;
        }

        private static bool IsSafe(int[,] matrix, int row, int col)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (row - i >= 0 && matrix[row - i, col] == 1)
                {
                    return false;
                }
                if (row + i < matrix.GetLength(0) && matrix[row + i, col] == 1)
                {
                    return false;
                }
                if (col - i >= 0 && matrix[row, col - i] == 1)
                {
                    return false;
                }
                if (col + i < matrix.GetLength(0) && matrix[row, col + i] == 1)
                {
                    return false;
                }
                if (row - i >= 0 &&
                    col - i >= 0 &&
                    matrix[row - i, col - i] == 1)
                {
                    return false;
                }
                if (row + i < matrix.GetLength(0) &&
                    col - i >= 0 &&
                    matrix[row+i, col-i] == 1)
                {
                    return false;
                }
                if (row + i < matrix.GetLength(0) &&
                    col + i < matrix.GetLength(0) &&
                    matrix[row + i, col + i] == 1)
                {
                    return false;
                }
                if (row - i >= 0 &&
                    col + i < matrix.GetLength(0) &&
                    matrix[row - i, col + i] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 0)
                    {
                        Console.Write("_ ");
                    }
                    else
                    {
                        Console.Write("Q ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
