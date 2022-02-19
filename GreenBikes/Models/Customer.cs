using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Models
{
    public class Customer : Person, IModel
    {
        public bool DrivingLicense { get; set; }
        public uint PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }

        public string ToGerman(string englishText)
        {
            string translatedText = "";
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
    }
}
