using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private List<Car> cars;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count
            => this.cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Exists(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
            => cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNum in registrationNumbers)
            {
                cars.Remove(cars.FirstOrDefault(c => c.RegistrationNumber == regNum)); 
            }
        }
    }
}
