using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            Stack<string> input = new Stack<string>(
                Console.ReadLine()
                .Split());

            Queue<Hall> halls = new Queue<Hall>();

            while (input.Count > 0)
            {
                var item = input.Pop();

                if (Int32.TryParse(item, out int reservationCount))
                {
                    if (halls.Count > 0)
                    {                       
                        if (halls.Peek().SeatsRemaining >= reservationCount)
                        {
                            halls.Peek().AddReservation(reservationCount);
                        }
                        else
                        {
                            Console.WriteLine(halls.Dequeue());
                            if (halls.Count > 0)
                            {
                                if (halls.Peek().SeatsRemaining >= reservationCount)
                                {
                                    halls.Peek().AddReservation(reservationCount);
                                }
                            }
                        }
                    }
                }
                else
                {
                    halls.Enqueue(new Hall(char.Parse(item), hallCapacity));
                }
            }
        }

        class Hall
        {
            private List<int> reservationList;

            public Hall(char name, int capacity)
            {
                Name = name;
                Capacity = capacity;
                reservationList = new List<int>();
            }

            public char Name { get; set; }
            public int Capacity { get; set; }
            public int SeatsRemaining { get => Capacity - reservationList.Sum(); }

            public void AddReservation(int reservation)
            {
                reservationList.Add(reservation);
            }

            public override string ToString()
            {
                return $"{Name} -> {string.Join(", ", reservationList)}";
            }
        }
    }
}
