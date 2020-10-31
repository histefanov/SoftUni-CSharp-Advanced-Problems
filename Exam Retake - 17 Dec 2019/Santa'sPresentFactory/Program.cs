using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_sPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> materials = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            Queue<int> magic = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            var presents = new Presents();
            bool craftSuccessful = false;

            while (materials.Count > 0 && magic.Count > 0)
            {
                craftSuccessful = false;

                if (materials.Peek() == 0 || magic.Peek() == 0)
                {
                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                    }
                    if (magic.Peek() == 0)
                    {
                        magic.Dequeue();
                    }
                    continue;
                }

                int product = materials.Peek() * magic.Peek();

                if (product < 0)
                {
                    materials.Push(materials.Pop() + magic.Dequeue());
                }
                else if (product == 150)
                {
                    presents.Dolls++;
                    craftSuccessful = true;
                }
                else if (product == 250)
                {
                    presents.WoodenTrains++;
                    craftSuccessful = true;
                }
                else if (product == 300)
                {
                    presents.TeddyBears++;
                    craftSuccessful = true;
                }
                else if (product == 400)
                {
                    presents.Bicycles++;
                    craftSuccessful = true;
                }
                else
                {
                    magic.Dequeue();
                    materials.Push(materials.Pop() + 15);
                }

                if (craftSuccessful)
                {
                    magic.Dequeue();
                    materials.Pop();
                }
            }

            if ((presents.Dolls > 0 && presents.WoodenTrains > 0) ||
                (presents.TeddyBears > 0 && presents.Bicycles > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magic.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            if (presents.Bicycles > 0)
            {
                Console.WriteLine($"Bicycle: {presents.Bicycles}");
            }
            if (presents.Dolls > 0)
            {
                Console.WriteLine($"Doll: {presents.Dolls}");
            }
            if (presents.TeddyBears > 0)
            {
                Console.WriteLine($"Teddy bear: {presents.TeddyBears}");
            }
            if (presents.WoodenTrains > 0)
            {
                Console.WriteLine($"Wooden train: {presents.WoodenTrains}");
            }
        }

        struct Presents
        {
            public int Dolls { get; set; }
            public int WoodenTrains { get; set; }
            public int TeddyBears { get; set; }
            public int Bicycles { get; set; }
        }
    }
}
