using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterMode
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] tokens = command.Split(';');
                string action = tokens[0];
                string filterType = tokens[1];
                string param = tokens[2];

                Predicate<string> filter = filterType switch
                {
                    "Starts with" => str => str.Substring(0, param.Length) == param,
                    "Ends with" => str => str.Substring(str.Length - param.Length) == param,
                    "Length" => str => str.Length == int.Parse(param),
                    "Contains" => str => str.Contains(param),
                    _ => throw new NotImplementedException()
                };

                switch (action)
                {
                    case "Add filter": filters.Add(filterType + ";" + param, filter); break;
                    case "Remove filter": filters.Remove(filterType + ";" + param); break;
                }
            }

            foreach (var filter in filters)
            {
                guests.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", guests));
        }
    }
}
