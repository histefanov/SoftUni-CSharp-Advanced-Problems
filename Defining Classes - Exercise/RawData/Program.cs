using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                cars.Add(new Car(carInfo));
            }

            Func<Car, bool> outputFilter = Console.ReadLine() switch
            {
                "fragile" => c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1),
                "flamable" => c => c.Cargo.Type == "flamable" && c.Engine.Power > 250,
                _ => throw new ArgumentException()
            };

            foreach (var car in cars.Where(outputFilter))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
