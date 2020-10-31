using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            string tireInput;
            while ((tireInput = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = tireInput.Split();
                tires.Add(new Tire[]
                {
                    new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])),
                    new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
                    new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[6]), double.Parse(tokens[7])),
                });
            }

            List<Engine> engines = new List<Engine>();
            string engineInput;
            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = engineInput.Split();
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            List<Car> cars = new List<Car>();
            string carInfo;
            while ((carInfo = Console.ReadLine()) != "Show special")
            {
                string[] tokens = carInfo.Split();
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                cars.Add(new Car(
                    make,
                    model,
                    year,
                    fuelQuantity,
                    fuelConsumption,
                    engines[engineIndex],
                    tires[tiresIndex])
                );
            }

            foreach (var car in cars)
            {
                if (IsSpecialCar(car))
                {
                    car.Drive(20);

                    Console.WriteLine(
                        $"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\n" +
                        $"HorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }
        }

        static bool IsSpecialCar(Car car)
        {
            double tirePressureSum = GetTirePressureSum(car.Tires);
            return (car.Year >= 2017 &&
                    car.Engine.HorsePower > 330 &&
                    tirePressureSum > 9 &&
                    tirePressureSum < 10);
        }

        static double GetTirePressureSum(Tire[] tires)
        {
            double pressureSum = 0.0;
            foreach (var tire in tires)
            {
                pressureSum += tire.Pressure;
            }
            return pressureSum;
        }
    }
}
