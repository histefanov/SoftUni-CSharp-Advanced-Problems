using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            SnakePosition snakePos = new SnakePosition();
            bool gameOver = false;
            int foodEaten = 0;

            for (int r = 0; r < size; r++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int c = 0; c < size; c++)
                {
                    field[r, c] = currentRow[c];

                    if (field[r, c] == 'S')
                    {
                        snakePos.R = r;
                        snakePos.C = c;
                    }
                }
            }

            while (!gameOver)
            {
                string cmd = Console.ReadLine();
                field[snakePos.R, snakePos.C] = '.';

                switch (cmd)
                {
                    case "up": snakePos.R--; break;
                    case "down": snakePos.R++; break;
                    case "left": snakePos.C--; break;
                    case "right": snakePos.C++; break;
                    default: break;
                }

                if (!IsOutOfField(size, snakePos.R, snakePos.C))
                {
                    if (field[snakePos.R, snakePos.C] == 'B')
                    {
                        field[snakePos.R, snakePos.C] = '.';
                        int[] burrowPosition = GetBurrowPosition(field);
                        snakePos.R = burrowPosition[0];
                        snakePos.C = burrowPosition[1];
                    }
                    else if (field[snakePos.R, snakePos.C] == '*')
                    {
                        foodEaten++;
                        if (foodEaten == 10)
                        {
                            Console.WriteLine("You won! You fed the snake.");
                            gameOver = true;
                        }
                    }

                    field[snakePos.R, snakePos.C] = 'S';
                }
                else
                {
                    Console.WriteLine("Game over!");
                    gameOver = true;
                }
            }

            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(field);
        }
        
        static int[] GetBurrowPosition(char[,] field)
        {
            int[] position = new int[2];
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    if (field[r, c] == 'B')
                    {
                        position[0] = r;
                        position[1] = c;
                    }
                }
            }
            return position;
        }

        static bool IsOutOfField(int size, int r, int c)
        {
            return r < 0 || r > size - 1 ||
                   c < 0 || c > size - 1;
        }

        static void PrintMatrix(char[,] field)
        {
            for (int r = 0; r < field.GetLength(0); r++)
            {
                for (int c = 0; c < field.GetLength(1); c++)
                {
                    Console.Write(field[r, c]);
                }
                Console.WriteLine();
            }
        }

        struct SnakePosition
        {
            public int R { get; set; }
            public int C { get; set; }
        }
    }
}
