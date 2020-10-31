using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int r = 0; r < size; r++)
            {
                int[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            string[] bombCoordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var bomb in bombCoordinates)
            {
                int[] coordinates = bomb
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinates[0];
                int col = coordinates[1];

                if (matrix[row, col] > 0)
                {
                    int damage = matrix[row, col];
                    matrix[row, col] = 0;

                    if (row - 1 >= 0)
                    {
                        if (matrix[row - 1, col] > 0)
                        {
                            matrix[row - 1, col] -= damage;
                        }
                        if (col - 1 >= 0)
                        {
                            if (matrix[row - 1, col - 1] > 0)
                            {
                                matrix[row - 1, col - 1] -= damage;
                            }
                        }
                        if (col + 1 < size)
                        {
                            if (matrix[row - 1, col + 1] > 0)
                            {
                                matrix[row - 1, col + 1] -= damage;
                            }                           
                        }
                    }

                    if (row + 1 < size)
                    {
                        if (matrix[row + 1, col] > 0)
                        {
                            matrix[row + 1, col] -= damage;
                        }
                        
                        if (col - 1 >= 0)
                        {
                            if (matrix[row + 1, col - 1] > 0)
                            {
                                matrix[row + 1, col - 1] -= damage;
                            }                           
                        }
                        if (col + 1 < size)
                        {
                            if (matrix[row + 1, col + 1] > 0)
                            {
                                matrix[row + 1, col + 1] -= damage;
                            }
                        }
                    }

                    if (col - 1 >= 0)
                    {
                        if (matrix[row, col - 1] > 0)
                        {
                            matrix[row, col - 1] -= damage;
                        }                  
                    }

                    if (col + 1 < size)
                    {
                        if (matrix[row, col + 1] > 0)
                        {
                            matrix[row, col + 1] -= damage;
                        }
                    }
                }
            }

            List<int> aliveCells = GetAliveCells(matrix);
            Console.WriteLine($"Alive cells: {aliveCells.Count}\nSum: {aliveCells.Sum()}");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + " ");
                }
                Console.WriteLine();
            }
        }

        static List<int> GetAliveCells(int[,] matrix)
        {
            List<int> aliveCells = new List<int>();

            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells.Add(cell);
                }
            }

            return aliveCells;
        }
    }
}
