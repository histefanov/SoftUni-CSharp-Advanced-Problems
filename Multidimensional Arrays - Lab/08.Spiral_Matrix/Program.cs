using System;
using System.Data;

namespace _08.Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            string direction = "right";
            int row = 0;
            int col = 0;

            int startRow = 0;
            int endRow = n - 1;
            int startCol = 0;
            int endCol = n - 1;

            for (int i = 1; i <= n * n; i++)
            {
                matrix[row, col] = i;

                if (direction == "right")
                {
                    if (col < endCol)
                    {
                        col++;
                    }
                    else
                    {
                        direction = "down";
                        row++;
                        startRow++;
                    }
                }
                else if (direction == "down")
                {
                    if (row < endRow)
                    {
                        row++;
                    }
                    else
                    {
                        direction = "left";
                        col--;
                        endCol--;
                    }
                }
                else if (direction == "left")
                {
                    if (col > startCol)
                    {
                        col--;
                    }
                    else
                    {
                        direction = "up";
                        row--;
                        endRow--;
                    }
                }
                else if (direction == "up")
                {
                    if (row > startRow)
                    {
                        row--;
                    }
                    else
                    {
                        direction = "right";
                        col++;
                        startCol++;
                    }
                }
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
