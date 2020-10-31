using System;

namespace _07.Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] board = new char[n,n];

            for (int r = 0; r < n; r++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int c = 0; c < n; c++)
                {
                    board[r, c] = line[c];
                }
            }

            int removedKnights = 0;

            bool isAttacking = RemoveKnight(board) > 0;

            while (isAttacking)
            {
                removedKnights++;
                isAttacking = RemoveKnight(board) > 0;
            }

            Console.WriteLine(removedKnights);
        }

        static void PrintMatrix(char[,] matrix)
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

        static int RemoveKnight(char[,] matrix)
        {
            int maxCounter = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'K')
                    {
                        int counter = 0;

                        if (r - 1 >= 0 && c - 2 >= 0 && matrix[r - 1, c - 2] == 'K') counter++;
                        if (r - 2 >= 0 && c - 1 >= 0 && matrix[r - 2, c - 1] == 'K') counter++;
                        if (r - 2 >= 0 && c + 1 < matrix.GetLength(1) && matrix[r - 2, c + 1] == 'K') counter++;
                        if (r - 1 >= 0 && c + 2 < matrix.GetLength(1) && matrix[r - 1, c + 2] == 'K') counter++;
                        if (r + 1 < matrix.GetLength(0) && c + 2 < matrix.GetLength(0) && matrix[r + 1, c + 2] == 'K') counter++;
                        if (r + 2 < matrix.GetLength(0) && c + 1 < matrix.GetLength(1) && matrix[r + 2, c + 1] == 'K') counter++;
                        if (r + 2 < matrix.GetLength(0) && c - 1 >= 0 && matrix[r + 2, c - 1] == 'K') counter++;
                        if (r + 1 < matrix.GetLength(0) && c - 2 >= 0 && matrix[r + 1, c - 2] == 'K') counter++;

                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            maxRow = r;
                            maxCol = c;
                        }
                    }
                }
            }

            if (maxCounter > 0)
            {
                matrix[maxRow, maxCol] = '0';
            }

            return maxCounter;
        }
    }
}
