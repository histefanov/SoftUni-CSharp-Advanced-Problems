using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get => data.Count; }

        public void Add(Car car)
        {
            if (Capacity > 0)
            {
                data.Add(car);
                Capacity--;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var carToRemove = data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
            if (carToRemove != null)
            {
                Capacity++;
            }
            return data.Remove(carToRemove);
        }

        public Car GetLatestCar()
        {
            return data.OrderByDescending(c => c.Year).FirstOrDefault();
        }

        public Car GetCar(string manufacturer, string model)
        {
            return data.Find(c => c.Manufacturer == manufacturer && c.Model == model);
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            data.ForEach(c => sb.AppendLine(c.ToString()));

            return sb.ToString().TrimEnd();
        }
    }
}
