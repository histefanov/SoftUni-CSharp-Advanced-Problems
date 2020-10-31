using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int cmdCount = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            var player = new Position();
            bool hasWon = false;

            for (int r = 0; r < n; r++)
            {
                string currentLine = Console.ReadLine();
                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = currentLine[c];

                    if (currentLine[c] == 'f')
                    {
                        player.Row = r;
                        player.Col = c;
                    }
                }
            }

            string cmd;
            for (int i = 0; i < cmdCount; i++)
            {
                cmd = Console.ReadLine();
                var nextPosition = MovePlayer(cmd, player);

                if (!IsInside(nextPosition, n))
                {
                    nextPosition = GetNewPosition(cmd, nextPosition, n);
                }

                if (matrix[nextPosition.Row, nextPosition.Col] == 'T')
                {
                    continue;
                }
                else if (matrix[nextPosition.Row, nextPosition.Col] == 'B')
                {
                    nextPosition = MovePlayer(cmd, nextPosition);
                    if (!IsInside(nextPosition, n))
                    {
                        nextPosition = GetNewPosition(cmd, nextPosition, n);
                    }
                }

                matrix[player.Row, player.Col] = '-';
                player = nextPosition;

                if (matrix[nextPosition.Row, nextPosition.Col] == '-')
                {
                    matrix[player.Row, player.Col] = 'f';
                }
                else if (matrix[nextPosition.Row, nextPosition.Col] == 'F')
                {
                    hasWon = true;
                    matrix[player.Row, player.Col] = 'f';
                    break;
                }
            }

            Console.WriteLine(hasWon ? "Player won!" : "Player lost!");
            PrintState(matrix);
        }

        struct Position
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }

        static Position MovePlayer(string cmd, Position position)
        {
            switch (cmd)
            {
                case "up": position.Row--; break;
                case "down": position.Row++; break;
                case "left": position.Col--; break;
                case "right": position.Col++; break;
            }

            return position;
        }

        static bool IsInside(Position position, int size)
        {
            if (position.Row >= 0 && position.Row < size &&
                position.Col >= 0 && position.Col < size)
            {
                return true;
            }
            return false;
        }

        static Position GetNewPosition(string cmd, Position position, int n)
        {
            switch (cmd)
            {
                case "up": position.Row = n - 1; break;
                case "down": position.Row = 0; break;
                case "left": position.Col = n - 1; break;
                case "right": position.Col = 0; break;
            }

            return position;
        }

        static void PrintState(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine(); ;
            }
        }
    }
}
