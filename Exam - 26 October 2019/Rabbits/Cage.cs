using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Rabbit>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get => data.Count; }

        public void Add(Rabbit rabbit)
        {
            if (data.Count < Capacity)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            return data.Remove(data.Find(r => r.Name == name));
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(r => r.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            int rabbitIndex = data.FindIndex(r => r.Name == name);
            data[rabbitIndex].Available = false;
            return data[rabbitIndex];
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbits = data.Where(r => r.Species == species).ToArray();
            foreach (var rabbit in data)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                }
            }
            return rabbits;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (var rabbit in data.Where(r => r.Available == true))
            {
                sb.AppendLine(rabbit.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
