using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    public class Booking : IModel
    {
        public Customer Customer { get; set; }
        public Bike Bike { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float TotalCosts { get; set; }
        public string ToGerman(string englishText)
        {
            string translatedText;
            switch (englishText)
            {
                case "Customer":
                    translatedText = "Kunde";
                    break;
                case "Bike":
                    translatedText = "Fahrrad";
                    break;
                case "StartDate":
                    translatedText = "Startdatum";
                    break;
                case "EndDate":
                    translatedText = "Enddatum";
                    break;
                case "TotalCosts":
                    translatedText = "Gesamtkosten";
                    break;
                default:
                    translatedText = "<<FEHLERHAFTE ÜBERSETZUNG>>";
                    break;
            }
            return translatedText;
        }
        public override string ToString()
        {
            return $"Kunde: {Customer.FirstName} {Customer.LastName}, Fahrrad: {Bike.Model} ({Bike.Manufacturer}), Fahrradkategorie: {Bike.Category.Name}, Startdatum: {StartDate.ToShortDateString()}, Enddatum: {EndDate.ToShortDateString()}, Gesamtkosten: {TotalCosts}";
        }
    }
}
