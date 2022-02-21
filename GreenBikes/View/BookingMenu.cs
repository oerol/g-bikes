using GreenBikes.Assets;
using GreenBikes.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.View
{
    internal class BookingMenu
    {
        public void Start()
        {
            string title = MenuTitles.customer + "\nWillkommen zur Kundenübersicht.\nWähle eine Aktion.";
            string[] options = { "Einen neuen Kunden erstellen", "Liste aller Kunden", "Zurück" };
            Utilities.DisplayOptions(title, options);

            BookingController controller = new BookingController();
            controller.Load();

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    do
                    {
                        controller.Create();
                    } while (Menu.GetChoice("Buchung wurde erfolgreich erstellt! Eine weitere erstellen?"));
                    Start();
                    break;
                case 2:
                    List();
                    break;
                case 3:
                    new Menu().StartMenu();
                    break;
            }

        }
        public void List()
        {
            string title = MenuTitles.list + "\n\nUnten findest du eine Liste aller Buchungen.\nMöchtest du Änderungen vornehmen?" + "\n(Tipp: Ändere die leicht die Größe dieses Fensters, für eine bessere Darstellung)";
            string[] options = { "Buchung bearbeiten", "Buchung löschen", "Zurück" };
            Utilities.DisplayOptions(title, options);

            BookingController controller = new BookingController();
            controller.Load();

            Utilities.ListItems(controller.bookings);

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    controller.Edit();
                    break;
                case 2:
                    Utilities.RemoveEntry(controller.bookings);
                    List();
                    break;
                case 3:
                    Start();
                    break;
            }
        }
    }
}
