using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    internal class BikeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DailyFee { get; set; }
        public float WeeklyFee { get; set; }
        public byte MaximumSpeed { get; set; }

        public BikeCategory(string name, float dailyFee, float weeklyFee, byte maximumSpeed)
        {
            Name = name;
            DailyFee = dailyFee;
            WeeklyFee = weeklyFee;
            MaximumSpeed = maximumSpeed;
        }
        override public string ToString()
        {
            return $"Name: {Name}, Gebühr (T): {DailyFee}, Gebühr (W): {WeeklyFee}, Höchstgeschwindigkeit: {MaximumSpeed}";
        }
    }
}
