using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Model
{
    public class BikeCategory : IModel
    {
        public string Name { get; set; }
        public float DailyFee { get; set; }
        public float WeeklyFee { get; set; }
        public byte MaximumSpeed { get; set; }

        override public string ToString()
        {
            return $"Name: {Name}, Gebühr (T): {DailyFee}, Gebühr (W): {WeeklyFee}, Höchstgeschwindigkeit: {MaximumSpeed}";
        }
        public string ToGerman(string englishText)
        {
            string translatedText;
            switch (englishText)
            {
                case "Name": // Zur Vollständigkeit
                    translatedText = "Name";
                    break;
                case "DailyFee":
                    translatedText = "Tägliche Gebühr";
                    break;
                case "WeeklyFee":
                    translatedText = "Wöchentliche Gebühr";
                    break;
                case "MaximumSpeed":
                    translatedText = "Maximale Geschwindigkeit";
                    break;
                default:
                    translatedText = "<<FEHLERHAFTE ÜBERSETZUNG>>";
                    break;
            }
            return translatedText;
        }
    }
}
