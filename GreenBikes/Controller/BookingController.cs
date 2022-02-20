using GreenBikes.Assets;
using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace GreenBikes.Controller
{
    internal class BookingController
    {
        public List<Booking> bookings = new List<Booking>();
        public void CreateBooking()
        {
            Clear();
            WriteLine(MenuTitles.create + "\n\nHier kannst du eine neue Buchung erstellen.\nGib bitte nachfolgend deine gewünschten Werte ein.\n");

            Booking newBooking = new Booking();
            Utilities.CreateEntry(newBooking, new string[] { "EndDate", "TotalCosts", "Customer", "Bike" });

            Write("Enddatum: ");
            GetEndDate(newBooking);

            Write("\n");

            List<Customer> customers = Utilities.LoadList(new Customer()); // Leeres Objekt für den XMLSerializer ä: in die methode
            Utilities.ListItems(customers);

            Write("\nUm welchen Kunden geht es? (Passe die Größe des Fensters an für eine Bessere Darstellung): ");
            int customerIndex = Utilities.ReadNumberWithMaxValue(ReadLine(), customers.Count);
            newBooking.Customer = customers[customerIndex];

            Write("\n");

            List<Bike> bikes = Utilities.LoadList(new Bike()); // Leeres Objekt für den XMLSerializer ä: in die methode
            Utilities.ListItems(bikes);

            Write("\nWelches Fahrrad wurde gebucht?: ");
            int bikesIndex = Utilities.ReadNumberWithMaxValue(ReadLine(), bikes.Count);
            newBooking.Bike = bikes[bikesIndex];

            newBooking.TotalCosts = CalculateTotalCosts(newBooking);

            bookings.Add(newBooking);
            Utilities.Save(bookings);
        }
        public void Load()
        {
            bookings = Utilities.LoadList(new Booking()); // Leeres Objekt für den XMLSerializer
        }

        public void Delete()
        {

            int index = Utilities.ReadNumberWithMaxValue(ReadLine(), bookings.Count);
            bookings.RemoveAt(index); // Exceptions werden durch ReadNumberWithMaxValue bereits abgefangen
            Utilities.Save(bookings);
        }
        public void Edit(int index = -1)
        {
            if (index == -1)

            {
                index = Utilities.EditEntry(bookings, new string[] { "BankAccountNumber" });
            }
            else
            {
                index = Utilities.EditEntry(bookings, new string[] { "BankAccountNumber" }, index);
            }

            new Menu().BookingListMenu();
        }
        private void GetEndDate(Booking booking)
        {
            DateTime endDate = Utilities.ReadDate();

            if (booking.StartDate > endDate)
            {
                Write("Das Enddatum darf nicht vor dem Startdatum liegen. Versuche es bitte erneut: ");
                GetEndDate(booking);
            }
            booking.EndDate = endDate;

        }
        private float CalculateTotalCosts(Booking booking) // wert hier direkt setzen
        {
            int days = (booking.EndDate - booking.StartDate).Days;
            int usageInWeeks = days / 7;
            int usageInDays = days % 7;

            float totalCosts = usageInWeeks * booking.Bike.Category.WeeklyFee + usageInDays * booking.Bike.Category.DailyFee;
            return totalCosts;
        }
    }
}
