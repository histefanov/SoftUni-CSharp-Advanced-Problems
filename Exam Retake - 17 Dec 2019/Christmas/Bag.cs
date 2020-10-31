using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> data;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            data = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Count { get => data.Count; }

        public void Add(Present present)
        {
            if (data.Count < Capacity)
            {
                data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            return data.Remove(data.Find(p => p.Name == name));
        }

        public Present GetHeaviestPresent()
        {
            return data.OrderByDescending(p => p.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return data.FirstOrDefault(p => p.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
