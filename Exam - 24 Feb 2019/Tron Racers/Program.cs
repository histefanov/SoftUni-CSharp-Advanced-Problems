using System;

namespace Tron_Racers
{
    class Program
    {
        class PlayerStatus
        {
            public PlayerStatus(int matrixSize)
            {
                IsAlive = true;
            }

            public int Row { get; set; }
            public int Col { get; set; }
            public bool IsAlive { get; set; }

            public void GetNextPosition(string cmd, int matrixSize)
            {
                switch (cmd)
                {
                    case "up": if (--Row < 0) Row = matrixSize - 1; break;
                    case "down": if (++Row == matrixSize) Row = 0; break;
                    case "left": if (--Col < 0) Col = matrixSize - 1;  break;
                    case "right": if (++Col == matrixSize) Col = 0; break;
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            var f = new PlayerStatus(n);
            var s = new PlayerStatus(n);

            for (int r = 0; r < n; r++)
            {
                string line = Console.ReadLine();

                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = line[c];
                    if (line[c] == 'f')
                    {
                        f.Row = r;
                        f.Col = c;
                    }
                    else if (line[c] == 's')
                    {
                        s.Row = r;
                        s.Col = c;
                    }
                }
            }

            string[] cmd;
            while (f.IsAlive && s.IsAlive)
            {
                cmd = Console.ReadLine().Split();
                var fCmd = cmd[0];
                var sCmd = cmd[1];

                f.GetNextPosition(fCmd, n);

                if (matrix[f.Row, f.Col] != 's')
                {
                    matrix[f.Row, f.Col] = 'f';
                }
                else
                {
                    matrix[f.Row, f.Col] = 'x';
                    f.IsAlive = false;
                    break;
                }

                s.GetNextPosition(sCmd, n);

                if (matrix[s.Row, s.Col] != 'f')
                {
                    matrix[s.Row, s.Col] = 's';
                }
                else
                {
                    matrix[s.Row, s.Col] = 'x';
                    s.IsAlive = false;
                    break;
                }
            }
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
    }
}
