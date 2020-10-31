using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int carsPassed = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else if (input == "green" && cars.Count > 0)
                {
                    bool queueEmpty = false;
                    string currentCar = cars.Dequeue();
                    List<char> currentCarChars = currentCar.ToList();

                    for (int i = 0; i < greenLightDuration; i++)
                    {
                        if (currentCarChars.Count == 0)
                        {
                            carsPassed++;

                            if (cars.Count > 0)
                            {
                                currentCar = cars.Dequeue();
                                currentCarChars = currentCar.ToList();                             
                            }
                            else
                            {
                                queueEmpty = true;
                                break;
                            }
                        }

                        currentCarChars.RemoveAt(0);
                    }

                    if (queueEmpty) continue;

                    for (int i = 0; i < freeWindowDuration; i++)
                    {
                        if (currentCarChars.Count == 0) break;   
                        
                        currentCarChars.RemoveAt(0);
                    }

                    if (currentCarChars.Count > 0)
                    {
                        Console.WriteLine($"A crash happened!\n{currentCar} was hit at {currentCarChars[0]}.");
                        return;
                    }
                    else
                    {
                        carsPassed++;
                    }
                }
            }

            Console.WriteLine($"Everyone is safe.\n{carsPassed} total cars passed the crossroads.");
        }
    }
}
