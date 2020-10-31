using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] lair = new char[sizes[0], sizes[1]];
            int pR = 0, pC = 0;

            for (int r = 0; r < lair.GetLength(0); r++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int c = 0; c < lair.GetLength(1); c++)
                {
                    lair[r, c] = line[c];

                    if (line[c] == 'P')
                    {
                        pR = r;
                        pC = c;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            bool hasEscaped = false;
            bool hasDied = false;

            foreach (var command in commands)
            {
                if (command == 'L')
                {
                    if (pC - 1 >= 0)
                    {
                        if (lair[pR, pC - 1] == '.')
                        {
                            lair[pR, pC - 1] = 'P';                           
                        }
                        else
                        {
                            hasDied = true;
                        }

                        lair[pR, pC] = '.';
                        pC--;
                    }
                    else
                    {
                        lair[pR, pC] = '.';
                        hasEscaped = true;
                    }
                }

                else if (command == 'R')
                {
                    if (pC + 1 < lair.GetLength(1))
                    {
                        if (lair[pR, pC + 1] == '.')
                        {
                            lair[pR, pC + 1] = 'P';
                        }
                        else
                        {
                            hasDied = true;
                        }

                        lair[pR, pC] = '.';
                        pC++;
                    }
                    else
                    {
                        lair[pR, pC] = '.';
                        hasEscaped = true;
                    }
                }

                else if (command == 'U')
                {
                    if (pR - 1 >= 0)
                    {
                        if (lair[pR - 1, pC] == '.')
                        {
                            lair[pR - 1, pC] = 'P';
                        }
                        else
                        {
                            hasDied = true;
                        }

                        lair[pR, pC] = '.';
                        pR--;
                    }
                    else
                    {
                        lair[pR, pC] = '.';
                        hasEscaped = true;
                    }
                }

                else if (command == 'D')
                {
                    if (pR + 1 < lair.GetLength(0))
                    {
                        if (lair[pR + 1, pC] == '.')
                        {
                            lair[pR + 1, pC] = 'P';
                        }
                        else
                        {
                            hasDied = true;
                        }

                        lair[pR, pC] = '.';
                        pR++;
                    }
                    else
                    {
                        lair[pR, pC] = '.';
                        hasEscaped = true;
                    }
                }

                SpreadBunnies(lair);

                if (lair[pR, pC] == 'B')
                {
                    hasDied = true;
                }

                if (hasEscaped)
                {
                    PrintMatrix(lair);
                    Console.WriteLine($"won: {pR} {pC}");
                    return;
                }
                else if (hasDied)
                {
                    PrintMatrix(lair);
                    Console.WriteLine($"dead: {pR} {pC}");
                    return;
                }
            }      
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }

        static void SpreadBunnies(char[,] matrix)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { r, c });
                    }
                }
            }

            bunniesCoordinates.ForEach(coordinates =>
            {
                int r = coordinates[0];
                int c = coordinates[1];

                if (r + 1 < matrix.GetLength(0)) matrix[r + 1, c] = 'B';
                if (r - 1 >= 0) matrix[r - 1, c] = 'B';
                if (c + 1 < matrix.GetLength(1)) matrix[r, c + 1] = 'B';
                if (c - 1 >= 0) matrix[r, c - 1] = 'B';
            });
        }
    }
}
