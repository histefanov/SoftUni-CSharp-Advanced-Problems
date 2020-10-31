using System;
using System.Linq;
using System.Text;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            var pos = new Position();

            for (int r = 0; r < size; r++)
            {
                string currentRow = Console.ReadLine();
                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = currentRow[c];
                    if (currentRow[c] == 'P')
                    {
                        pos.Row = r;
                        pos.Col = c;
                    }
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "end")
            {              
                var nextPos = MovePlayer(cmd, pos);
                if (!IsInside(size, nextPos))
                {
                    if (sb.Length > 0)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    PrintMatrix(matrix);
                    continue;
                }

                matrix[pos.Row, pos.Col] = '-';

                if (matrix[nextPos.Row, nextPos.Col] != '-')
                {
                    sb.Append(matrix[nextPos.Row, nextPos.Col]);
                }

                pos = nextPos;
                matrix[nextPos.Row, nextPos.Col] = 'P';
                PrintMatrix(matrix);
            }

            Console.WriteLine(sb.ToString());
            PrintMatrix(matrix);
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

        static Position MovePlayer(string cmd, Position currentPosition)
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

        static bool IsInside(int size, Position position)
        {
            if (position.Row >= 0 && position.Row < size &&
                position.Col >= 0 && position.Col < size)
            {
                return true;
            }
            return false;
        }

        struct Position
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }
    }
}
