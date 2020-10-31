using System;
using System.Linq;

namespace _04.Matrix_Shuffling
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
                string[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = line[c];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "swap" && tokens.Length == 5)
                {
                    int r1 = int.Parse(tokens[1]);
                    int c1 = int.Parse(tokens[2]);
                    int r2 = int.Parse(tokens[3]);
                    int c2 = int.Parse(tokens[4]);

                    if (
                        r1 >= 0 && r1 < matrix.GetLength(0) &&
                        r2 >= 0 && r2 < matrix.GetLength(0) &&
                        c1 >= 0 && c1 < matrix.GetLength(1) &&
                        c2 >= 0 && c2 < matrix.GetLength(1)
                        )
                    {
                        string temp = matrix[r1, c1];
                        matrix[r1, c1] = matrix[r2, c2];
                        matrix[r2, c2] = temp;
                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }              
            }
        }

        static void PrintMatrix(string[,] matrix)
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
    }
}
