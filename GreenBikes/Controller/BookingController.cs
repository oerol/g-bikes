using GreenBikes.Assets;
using GreenBikes.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
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

            SetCustomer(newBooking);
            SetBike(newBooking);
            SetTotalCosts(newBooking);

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
            PropertyInfo property;
            if (index == -1) // -1 heißt: Es gibt nichts zum Bearbeiten
            {
                index = Utilities.GetChosenIndex(bookings);
                property = Utilities.EditEntry(bookings, new string[] { "EndDate", "TotalCosts", "Customer", "Bike" }, index);

            }
            else
            {
                property = Utilities.EditEntry(bookings, new string[] { "EndDate", "TotalCosts", "Customer", "Bike" }, index);
            }

            if (property.Name == "EndDate")
            {
                Write("Enddatum: ");
                GetEndDate(bookings[index]);
            }
            else if (property.Name == "Customer")
            {
                SetCustomer(bookings[index]);
            }
            else if (property.Name == "Bike")
            {
                SetBike(bookings[index]);
            }

            SetTotalCosts(bookings[index]);

            Utilities.Save(bookings);
            WriteLine("\n >> " + bookings[index].ToString());

            if (Menu.GetChoice("Änderung wurde vorgenommen. Möchtest du noch etwas ändern?"))
            {
                Edit(index);
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
        private void SetTotalCosts(Booking booking)
        {
            int days = (booking.EndDate - booking.StartDate).Days;
            int usageInWeeks = days / 7;
            int usageInDays = days % 7;

            float totalCosts = usageInWeeks * booking.Bike.Category.WeeklyFee + usageInDays * booking.Bike.Category.DailyFee;
            booking.TotalCosts = totalCosts;
        }

        private void SetCustomer(Booking booking)
        {
            Write("\n");

            List<Customer> customers = Utilities.LoadList(new Customer()); // Leeres Objekt für den XMLSerializer ä: in die methode
            Utilities.ListItems(customers);

            Write("\nUm welchen Kunden geht es? (Passe die Größe des Fensters an für eine Bessere Darstellung): ");
            int customerIndex = Utilities.ReadNumberWithMaxValue(ReadLine(), customers.Count);
            booking.Customer = customers[customerIndex];
        }

        private void SetBike(Booking bike)
        {
            List<Bike> bikes = Utilities.LoadList(new Bike()); // Leeres Objekt für den XMLSerializer ä: in die methode
            Utilities.ListItems(bikes);

            Write("\nWelches Fahrrad soll gebucht werden?: ");
            int bikesIndex = Utilities.ReadNumberWithMaxValue(ReadLine(), bikes.Count);
            bike.Bike = bikes[bikesIndex];
        }
    }
}
