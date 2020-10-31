using System;

namespace _07.Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            if (rows == 1)
            {
                Console.WriteLine("1");
                return;
            }

            long[][] triangle = new long[rows][];
            triangle[0] = new long[1] { 1 };
            triangle[1] = new long[2] { 1, 1 };
            int length = 3;

            for (int r = 2; r < rows; r++)
            {
                triangle[r] = new long[length];
                for (int c = 0; c < triangle[r].Length; c++)
                {
                    if (c == 0 || c == triangle[r].Length - 1)
                    {
                        triangle[r][c] = 1;
                    }
                    else
                    {
                        triangle[r][c] = triangle[r - 1][c - 1] + triangle[r - 1][c];
                    }
                }
                length++;
            }

            foreach (var line in triangle)
            {
                Console.WriteLine(string.Join(" ", line));
            }
        }
    }
}
