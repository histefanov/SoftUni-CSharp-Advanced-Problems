using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {           
            char[,] maze = GenerateMaze();
            FindPaths(maze, 0, 0, new bool[maze.GetLength(0), maze.GetLength(1)], "");
        }

        private static char[,] GenerateMaze()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] maze = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string line = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    maze[r, c] = line[c];
                }
            }

            return maze;
        }

        public static void FindPaths
            (char[,] maze, int row, int col, bool[,] visited, string path)
        {
            if (maze[row, col] == 'X')
            {
                Console.WriteLine(path);
                return;
            }

            visited[row, col] = true;

            if (IsSafe(maze, row + 1, col, visited))
            {
                FindPaths(maze, row + 1, col, visited, path + "D");
            }

            if (IsSafe(maze, row - 1, col, visited))
            {
                FindPaths(maze, row - 1, col, visited, path + "U");
            }

            if (IsSafe(maze, row, col + 1, visited))
            {
                FindPaths(maze, row, col + 1, visited, path + "R");
            }

            if (IsSafe(maze, row, col - 1, visited))
            {
                FindPaths(maze, row, col - 1, visited, path + "L");
            }

            visited[row, col] = false;
        }

        private static bool IsSafe
            (char[,] maze, int row, int col, bool[,] visited)
        {
            if (row < 0 || row >= maze.GetLength(0) ||
                col < 0 || col >= maze.GetLength(1))
            {
                return false;
            }
            if (maze[row,col] == '/')
            {
                return false;
            }
            if (visited[row,col] == true)
            {
                return false;
            }
            return true;
        }
    }
}
