using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(string[] info)
        {
            Model = info[0];
            Engine = new Engine(int.Parse(info[1]), int.Parse(info[2]));
            Cargo = new Cargo(int.Parse(info[3]), info[4]);
            Tires = new Tire[4]
            {
                new Tire(double.Parse(info[5]), int.Parse(info[6])),
                new Tire(double.Parse(info[7]), int.Parse(info[8])),
                new Tire(double.Parse(info[9]), int.Parse(info[10])),
                new Tire(double.Parse(info[11]), int.Parse(info[12]))
            };
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }
    }
}

//string model, int engineSpeed, int enginePower,
//int cargoWeight, string cargoType, double tire1Pressure,
//int tire1Age, double tire2Pressure, int tire2Age,
//double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age