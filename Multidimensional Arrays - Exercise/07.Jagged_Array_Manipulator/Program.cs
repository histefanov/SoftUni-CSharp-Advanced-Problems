using System;
using System.Linq;

namespace _07.Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = PopulateMatrix(rows);
            AnalyzeMatrix(matrix);
            ManipulateMatrix(matrix);
            PrintMatrix(matrix);
        }

        static double[][] PopulateMatrix(int rows)
        {
            double[][] matrix = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = new double[line.Length];

                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i][j] = line[j];
                }
            }

            return matrix;
        }

        static void AnalyzeMatrix(double[][] matrix)
        {
            for (int r = 0; r < matrix.Length - 1; r++)
            {
                if (matrix[r].Length == matrix[r + 1].Length)
                {
                    for (int c = 0; c < matrix[r].Length; c++)
                    {
                        matrix[r][c] *= 2;
                        matrix[r + 1][c] *= 2;
                    }
                }
                else
                {
                    for (int c = 0; c < matrix[r].Length; c++)
                    {
                        matrix[r][c] /= 2;
                    }

                    for (int c = 0; c < matrix[r + 1].Length; c++)
                    {
                        matrix[r + 1][c] /= 2;
                    }
                }
            }
        }

        static void ManipulateMatrix(double[][] matrix)
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if ((row >= 0 && row < matrix.Length) &&
                    (col >= 0 && col < matrix[row].Length))
                {
                    switch (command)
                    {
                        case "Add": matrix[row][col] += value; break;
                        case "Subtract": matrix[row][col] -= value; break;
                    }
                }
            }
        }

        static void PrintMatrix(double[][] matrix)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    Console.Write(matrix[r][c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
