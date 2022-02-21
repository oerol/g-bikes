using GreenBikes.Assets;
using GreenBikes.Model;
using GreenBikes.View;
using System;
using System.Collections.Generic;
using System.Reflection;
using static System.Console;
namespace GreenBikes.Controller
{
    internal class BookingController : IController
    {
        public List<Booking> bookings = new List<Booking>();
        public void Create()
        {
            int bikesCount = Utilities.LoadList(new Bike()).Count;
            int customersCount = Utilities.LoadList(new Bike()).Count;
            if (bikesCount > 0 && customersCount > 0)
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

                if (Menu.GetChoice("Buchung wurde erfolgreich erstellt! Eine weitere erstellen?"))
                {
                    Create();
                }
            }
            else
            {
                WriteLine("Bitte stelle sicher, dass mindestens eine Fahrradkategorie, ein Fahrrad und ein Kunde existiert!");
                System.Threading.Thread.Sleep(1500);
            }
            new BookingMenu().Start();

        }
        public void Load()
        {
            bookings = Utilities.LoadList(new Booking()); // Leeres Objekt für den XMLSerializer
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
            new BookingMenu().List();
        }
        private void GetEndDate(Booking booking)
        {
            DateTime endDate = Utilities.ReadDate();

            if (booking.StartDate <= endDate)
            {
                booking.EndDate = endDate;
            }
            else
            {
                Write("Das Enddatum darf nicht vor dem Startdatum liegen. Versuche es bitte erneut: ");
                GetEndDate(booking);

            }

        }
        private void SetTotalCosts(Booking booking)
        {
            int days = (booking.EndDate - booking.StartDate).Days;
            int usageInWeeks = days / 7;
            int usageInDays = days % 7;
            WriteLine(days);

            if (days == 0) // Bei gleichem Start- und Enddatum werden kosten in Höhe eines Tages berechnet
            {
                booking.TotalCosts = booking.Bike.Category.DailyFee;
            }
            else
            {
                float totalCosts = usageInWeeks * booking.Bike.Category.WeeklyFee + usageInDays * booking.Bike.Category.DailyFee;
                booking.TotalCosts = totalCosts;
            }

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

        private void SetBike(Booking booking)
        {
            List<Bike> bikes = Utilities.LoadList(new Bike()); // Leeres Objekt für den XMLSerializer ä: in die methode
            Utilities.ListItems(bikes);

            Write("\nWelches Fahrrad soll gebucht werden?: ");


            Bike chosenBike = bikes[Utilities.ReadNumberWithMaxValue(ReadLine(), bikes.Count)];
            int licensedMaximumSpeed = 25;

            if (chosenBike.Category.MaximumSpeed > licensedMaximumSpeed)
            {
                if (!booking.Customer.DrivingLicense)
                {
                    Write($"Ein Kunde darf keinem Fahrrad dieser Kategorie zugeordnet werden! Wähle ein Fahrrad aus einer Fahrradkategorie, welches nicht schneller als {licensedMaximumSpeed} km/h ist.\n ");
                    SetBike(booking);
                }
            }

            booking.Bike = chosenBike;
        }
    }
}
