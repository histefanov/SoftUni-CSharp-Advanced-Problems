using Microsoft.VisualBasic.CompilerServices;
using System;

namespace CarManufacturer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Car opelaNaMama = new Car();
            opelaNaMama.Make = "Opel";
            opelaNaMama.Model = "Meriva";
            opelaNaMama.Year = 2016;

            Console.WriteLine($"Make: {opelaNaMama.Make}\nModel: {opelaNaMama.Model}\nYear: {opelaNaMama.Year}");
        }
    }
}
