using SnakeGame.Helpers;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SnakeGame
{
    public class GameEngine
    {
        private bool isRunning = false;
        private List<IDrawable> gameItems = new List<IDrawable>();
        private Random rand = new Random();

        public Snake Snake { get; set; }

        public GameEngine()
        {
            Snake = new Snake(new Position(30, 20), SpawnFood);
            gameItems.Add(Snake);
            SpawnFood();     
        }

        public void Start()
        {
            isRunning = true;
            Position movement = new Position(0, 0);

            while (isRunning == true)
            {
                BoundariesChecker.CheckBoundaries(Snake.SnakeBody.Head.Value, movement);
                Snake.Move(movement);
                if (Snake.CheckIfSnakeHasEatenItself())
                {
                    ConsoleHelper.Write(new Position(0, 0), "G A M E   O V E R !\n\nYou ate yourself.");
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(false).Key;
                    movement = ReadUserInput.GetMovement(key);
                }
                Thread.Sleep(100);
                gameItems.ForEach(i => i.Draw());
            }
        }

        public void Stop()
        {
            isRunning = false;
        }

        private void SpawnFood()
        {
            var food = new Food(new Position(
                rand.Next(0, Console.WindowWidth - 1),
                rand.Next(0, Console.WindowHeight - 1)));

            gameItems.Add(food);
            Snake.Foods.Add(food);
        }
    }
}
