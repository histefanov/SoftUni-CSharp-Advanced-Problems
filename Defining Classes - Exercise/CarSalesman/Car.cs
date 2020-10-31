﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }


        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Model}:\n" +
                   $"{Engine}\n" +
                   "  Weight: " + (Weight != 0 ? Weight.ToString() : "n/a") + "\n" +
                   "  Color: " + (Color ?? "n/a");
        }
    }
}
