using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (engineInfo.Length)
                {
                    case 2:
                        {
                            engines.Add(new Engine(engineInfo[0], int.Parse(engineInfo[1])));
                        }
                        break;

                    case 3:
                        {
                            if (Int32.TryParse(engineInfo[2], out int displacement))
                            {
                                engines.Add(new Engine(engineInfo[0],
                                    int.Parse(engineInfo[1]),
                                    displacement));
                            }
                            else
                            {
                                engines.Add(new Engine(engineInfo[0],
                                    int.Parse(engineInfo[1]),
                                    engineInfo[2]));
                            }
                        }
                        break;

                    case 4:
                        {
                            engines.Add(new Engine(
                                engineInfo[0],
                                int.Parse(engineInfo[1]),
                                int.Parse(engineInfo[2]),
                                engineInfo[3]));
                        }
                        break;
                    default:
                        break;
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (carInfo.Length)
                {
                    case 2:
                        {
                            cars.Add(new Car(carInfo[0], engines.Find(e => e.Model == carInfo[1])));
                        }
                        break;

                    case 3:
                        {
                            if (Int32.TryParse(carInfo[2], out int weight))
                            {
                                cars.Add(new Car(carInfo[0], 
                                    engines.Find(e => e.Model == carInfo[1]),
                                    weight));
                            }
                            else
                            {
                                cars.Add(new Car(carInfo[0],
                                    engines.Find(e => e.Model == carInfo[1]),
                                    carInfo[2]));
                            }
                        }
                        break;

                    case 4:
                        {
                            cars.Add(new Car(
                                carInfo[0],
                                engines.Find(e => e.Model == carInfo[1]),
                                int.Parse(carInfo[2]),
                                carInfo[3]));
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
