using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    public class BikeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DailyFee { get; set; }
        public float WeeklyFee { get; set; }
        public byte MaximumSpeed { get; set; }

        override public string ToString()
        {
            return $"Name: {Name}, Gebühr (T): {DailyFee}, Gebühr (W): {WeeklyFee}, Höchstgeschwindigkeit: {MaximumSpeed}";
        }
    }
}
