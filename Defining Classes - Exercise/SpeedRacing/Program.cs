using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ");
                cars.Add(new Car(
                    carInfo[0], 
                    double.Parse(carInfo[1]), 
                    double.Parse(carInfo[2])));
            }

            string command;
            while((command = Console.ReadLine()) != "End") 
            {
                string[] tokens = command.Split();
                string carModel = tokens[1];
                int distanceInKm = int.Parse(tokens[2]);

                var currentCarIndex = cars.FindIndex(c => c.Model == carModel);
                cars[currentCarIndex].Drive(distanceInKm);
            }

            cars.ForEach(c => PrintCarInfo(c));
        }
        
        static void PrintCarInfo(Car car)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
        }
    }
}
