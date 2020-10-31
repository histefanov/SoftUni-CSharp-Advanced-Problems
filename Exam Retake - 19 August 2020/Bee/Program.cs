using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            var bee = new BeePosition();
            int pollinatedFlowers = 0;

            for (int r = 0; r < size; r++)
            {
                string currentRow = Console.ReadLine();
                for (int c = 0; c < size; c++)
                {
                    field[r, c] = currentRow[c];
                    if (currentRow[c] == 'B')
                    {
                        bee.Row = r;
                        bee.Col = c;
                    }
                }
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "End")
            {
                field[bee.Row, bee.Col] = '.';
                bee = MoveBee(cmd, bee);

                if (!IsInside(bee, size))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (field[bee.Row, bee.Col] == 'O')
                {
                    field[bee.Row, bee.Col] = '.';
                    bee = MoveBee(cmd, bee);
                }
                if (field[bee.Row, bee.Col] == 'f')
                {
                    pollinatedFlowers++;                    
                }
                field[bee.Row, bee.Col] = 'B';
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }

            PrintState(field);
        }

        static bool IsInside(BeePosition bee, int fieldSize)
        {
            if (bee.Row >= 0 && bee.Row < fieldSize &&
                bee.Col >= 0 && bee.Col < fieldSize)
            {
                return true;
            }
            return false;
        }

        static BeePosition MoveBee(string direction, BeePosition beePosition)
        {
            switch (direction)
            {
                case "up": beePosition.Row--; break;
                case "down": beePosition.Row++; break;
                case "left": beePosition.Col--; break;
                case "right": beePosition.Col++; break;
                default: break;
            }

            return beePosition;
        }

        struct BeePosition
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }

        static void PrintState(char[,] field)
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
    }
}
