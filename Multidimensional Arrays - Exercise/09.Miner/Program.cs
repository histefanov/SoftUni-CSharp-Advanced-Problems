using System;
using System.Data;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rowPos = 0;
            int colPos = 0;
            int minedCoal = 0;
            int coalAvailable = 0;

            for (int r = 0; r < size; r++)
            {
                char[] line = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int c = 0; c < size; c++)
                {
                    field[r, c] = line[c];

                    if (line[c] == 's')
                    {
                        rowPos = r;
                        colPos = c;
                    }
                    else if (line[c] == 'c')
                    {
                        coalAvailable++;
                    }
                }
            }

            foreach (var command in commands)
            {           
                switch (command)
                {
                    case "left":
                        if (colPos - 1 >= 0) colPos--;                       
                        break;

                    case "right":
                        if (colPos + 1 < size) colPos++;
                        break;

                    case "up":
                        if (rowPos - 1 >= 0) rowPos--;
                        break;

                    case "down":
                        if (rowPos + 1 < size) rowPos++;
                        break;
                }

                switch (field[rowPos, colPos])
                {
                    case 'c':
                        field[rowPos, colPos] = '*';
                        coalAvailable--;
                        minedCoal++;
                        break;

                    case 'e':
                        Console.WriteLine("Game over! ({0}, {1})", rowPos, colPos);
                        return;
                }

                if (coalAvailable == 0)
                {
                    Console.WriteLine("You collected all coals! ({0}, {1})", rowPos, colPos);
                    return;
                }
            }

            Console.WriteLine("{0} coals left. ({1}, {2})", coalAvailable, rowPos, colPos);
        }
    }
}
