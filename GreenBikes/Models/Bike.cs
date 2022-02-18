using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    public class Bike
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public uint Power { get; set; }
        public BikeCategory Category { get; set; }

        override public string ToString()
        {
            return $"Hersteller: {Manufacturer}, Modell: {Model}, Leistung (W): {Power}, Kategorie: {Category.Name}";
        }
    }

}
