using SnakeGame.Helpers;
using SnakeGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    public class Snake : IDrawable
    {
        public Snake(Position headPosition, Action spawnFood)
        {
            this.SpawnFood = spawnFood;
            this.SnakeBody = new LinkedList();
            this.SnakeBody.AddHead(new Node(headPosition));
            this.Foods = new List<Food>();
            for (int i = 1; i <= 3; i++)
            {
                SnakeBody.AddTail(new Node(new Position
                    (headPosition.X + i, headPosition.Y)));
            }
        }
        public Action SpawnFood { get; set; }

        public LinkedList SnakeBody { get; set; }

        public List<Food> Foods { get; set; }

        public void Draw()
        {
            SnakeBody.ForEach(n =>
            {
                var text = "*";              
                if (n == SnakeBody.Head)
                {
                    text = "@";
                }
                ConsoleHelper.Write(n.Value, text);
            });
        }

        public bool CheckIfSnakeHasEatenItself()
        {
            HashSet<Position> set = new HashSet<Position>();
            bool hasEatenItself = false;
            SnakeBody.ForEach(n =>
            {
                if (set.Contains(n.Value)) hasEatenItself = true;
                set.Add(n.Value);
            });

            return hasEatenItself;
        }

        public void Move(Position position)
        {
            if (position.X == 0 && position.Y == 0)
            {
                return;
            }

            ConsoleHelper.Clear(SnakeBody.Tail.Value);

            SnakeBody.ReverseForEach(n =>
            {
                if (n.Previous != null)
                {
                    n.Value.X = n.Previous.Value.X;
                    n.Value.Y = n.Previous.Value.Y;
                }
            });

            this.SnakeBody.Head.Value.ChangePosition(position);

            for (int i = 0; i < this.Foods.Count; i++)
            {
                if (this.Foods[i].Position == this.SnakeBody.Head.Value)
                {
                    Foods[i].EatFood();
                    Grow(position);
                    SpawnFood();
                }
            }
        }

        public void Grow(Position position)
        {
            var oldPosition = SnakeBody.Head.Value;

            var newHead = new Node(new Position(oldPosition.X, oldPosition.Y));
            //  newHead.Value.ChangePosition(position);
            BoundariesChecker.CheckBoundaries(newHead.Value, position);
            SnakeBody.AddHead(newHead);
        }
    }
}
