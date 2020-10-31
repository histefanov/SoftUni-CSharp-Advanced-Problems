using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        class Flower
        {
            public Flower(int row, int col)
            {
                Row = row;
                Col = col;
            }

            public int Row { get; set; }
            public int Col { get; set; }
        }

        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = sizes[0];
            int m = sizes[1];
            int[,] matrix = new int[n, m];

            List<Flower> flowers = new List<Flower>();

            string input;
            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (IsInside(n, m, coordinates))
                {
                    flowers.Add(new Flower(coordinates[0], coordinates[1]));
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var flower in flowers)
            {
                for (int c = 0; c < m; c++)
                {
                    matrix[flower.Row, c]++;
                }

                for (int r = 0; r < n; r++)
                {
                    matrix[r, flower.Col]++;
                }

                matrix[flower.Row, flower.Col]--;
            }

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

        static bool IsInside(int n, int m, int[] coordinates)
        {
            int row = coordinates[0];
            int col = coordinates[1];

            if (row >= 0 && row < n &&
                col >= 0 && col < m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }   
}
