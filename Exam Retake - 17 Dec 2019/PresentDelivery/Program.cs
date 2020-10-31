using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[,] neighbourhood = new char[size, size];
            var santaPosition = new Position();
            int niceKids = 0;

            for (int r = 0; r < size; r++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int c = 0; c < size; c++)
                {
                    neighbourhood[r, c] = currentRow[c];
                    if (currentRow[c] == 'S')
                    {
                        santaPosition.Row = r;
                        santaPosition.Col = c;
                    }
                    else if (currentRow[c] == 'V')
                    {
                        niceKids++;
                    }
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "Christmas morning" &&
                    presentsCount > 0)
            {
                neighbourhood[santaPosition.Row, santaPosition.Col] = '-';
                santaPosition = MoveSanta(cmd, santaPosition);

                if (neighbourhood[santaPosition.Row, santaPosition.Col] == 'V')
                {
                    presentsCount--;
                }
                else if (neighbourhood[santaPosition.Row, santaPosition.Col] == 'C')
                {
                    neighbourhood[santaPosition.Row, santaPosition.Col] = 'S';

                    if (santaPosition.Row - 1 >= 0)
                    {
                        if (neighbourhood[santaPosition.Row - 1, santaPosition.Col] == 'X' ||
                            neighbourhood[santaPosition.Row - 1, santaPosition.Col] == 'V')
                        {
                            presentsCount--;
                            neighbourhood[santaPosition.Row - 1, santaPosition.Col] = '-';

                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }

                    if (santaPosition.Row + 1 < size)
                    {
                        if (neighbourhood[santaPosition.Row + 1, santaPosition.Col] == 'X' ||
                            neighbourhood[santaPosition.Row + 1, santaPosition.Col] == 'V')
                        {
                            presentsCount--;
                            neighbourhood[santaPosition.Row + 1, santaPosition.Col] = '-';

                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }

                    if (santaPosition.Col - 1 >= 0)
                    {
                        if (neighbourhood[santaPosition.Row, santaPosition.Col - 1] == 'X' ||
                            neighbourhood[santaPosition.Row, santaPosition.Col - 1] == 'V')
                        {
                            presentsCount--;
                            neighbourhood[santaPosition.Row, santaPosition.Col - 1] = '-';

                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }

                    if (santaPosition.Col + 1 < size)
                    {
                        if (neighbourhood[santaPosition.Row, santaPosition.Col + 1] == 'X' ||
                            neighbourhood[santaPosition.Row, santaPosition.Col + 1] == 'V')
                        {
                            presentsCount--;
                            neighbourhood[santaPosition.Row, santaPosition.Col + 1] = '-';

                            if (presentsCount == 0)
                            {
                                break;
                            }
                        }
                    }
                }

                neighbourhood[santaPosition.Row, santaPosition.Col] = 'S';
            }

            if (presentsCount == 0)
                Console.WriteLine("Santa ran out of presents!");

            PrintState(neighbourhood);
            int niceKidsRemaining = GetRemainingNiceKids(neighbourhood);

            Console.WriteLine(niceKidsRemaining == 0 ? 
                $"Good job, Santa! {niceKids} happy nice kid/s." :
                $"No presents for {niceKidsRemaining} nice kid/s.");
        }

        struct Position
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }

        static Position MoveSanta(string cmd, Position currentPosition)
        {
            switch (cmd)
            {
                case "up": currentPosition.Row--; break;
                case "down": currentPosition.Row++; break;
                case "left": currentPosition.Col--; break;
                case "right": currentPosition.Col++; break;
            }

            return currentPosition;
        }

        static int GetRemainingNiceKids(char[,] matrix)
        {
            int niceKids = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r,c] == 'V')
                    {
                        niceKids++;
                    }
                }
            }

            return niceKids;
        }

        static void PrintState(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r,c] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
