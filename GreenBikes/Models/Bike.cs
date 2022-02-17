using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    internal class Bike
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public uint Power { get; set; } // Einheit: Watt
    }
}
