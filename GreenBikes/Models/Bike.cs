using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    public class Bike : Base, IModel
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public uint Power { get; set; }
        public BikeCategory Category { get; set; }

        override public string ToString()
        {
            return $"Hersteller: {Manufacturer}, Modell: {Model}, Leistung (W): {Power}, Kategorie: {Category.Name}";
        }
        public string ToGerman(string englishText)
        {
            string translatedText = "";
            switch (englishText)
            {
                case "Manufacturer":
                    translatedText = "Hersteller";
                    break;
                case "Model":
                    translatedText = "Modell";
                    break;
                case "Power":
                    translatedText = "Leistung";
                    break;
                case "Category":
                    translatedText = "Kategorie";
                    break;
                default: // Zur Identifikation von vergessenen/fehlerhaften Strings
                    translatedText = "<<FEHLENDE ÜBERSETZUNG>>";
                    break;
            }
            return translatedText;
        }
    }

}
