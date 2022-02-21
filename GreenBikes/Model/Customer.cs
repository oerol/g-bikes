using GreenBikes.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Model
{
    public class Customer : Person, IModel
    {
        public bool DrivingLicense { get; set; }
        public string PhoneNumber { get; set; } // String, da keine Rechnungen durchgeführt werden müssen
        public string BankAccountNumber { get; set; }

        public string ToGerman(string englishText)
        {
            string translatedText;
            switch (englishText)
            {
                case "DrivingLicense":
                    translatedText = "AM-Führerschein";
                    break;
                case "PhoneNumber":
                    translatedText = "Telefonnummer";
                    break;
                case "BankAccountNumber":
                    translatedText = "IBAN";
                    break;
                case "FirstName":
                    translatedText = "Vorname";
                    break;
                case "LastName":
                    translatedText = "Nachname";
                    break;
                case "City":
                    translatedText = "Stadt";
                    break;
                case "Street":
                    translatedText = "Straße";
                    break;
                case "PostalCode":
                    translatedText = "Postleitzahl";
                    break;
                default:
                    translatedText = "<<FEHLERHAFTE ÜBERSETZUNG>>";
                    break;
            }
            return translatedText;
        }
        public override string ToString()
        {
            return $"Vorname: {FirstName}, Nachname: {LastName}, Telefonnummer: {PhoneNumber} Stadt: {City}, Straße: {Street}, Postleitzahl: {PostalCode}, AM-Führerschein: {Utilities.TranslateBool(DrivingLicense)}, IBAN: {BankAccountNumber}";
        }
    }
}
