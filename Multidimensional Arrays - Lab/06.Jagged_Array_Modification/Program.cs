using System;
using System.Linq;

namespace _06.Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int r = 0; r < rows; r++)
            {
                int[] line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                matrix[r] = new int[line.Length];

                for (int c = 0; c < line.Length; c++)
                {
                    matrix[r][c] = line[c];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputInfo = input.Split();
                string command = inputInfo[0];
                int row = int.Parse(inputInfo[1]);
                int col = int.Parse(inputInfo[2]);
                int value = int.Parse(inputInfo[3]);

                if (row < matrix.Length && row >= 0 && col < matrix[row].Length && col >= 0)
                {
                    switch (command)
                    {
                        case "Add": matrix[row][col] += value; break;
                        case "Subtract": matrix[row][col] -= value; break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            foreach (var line in matrix)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }
    }
}
