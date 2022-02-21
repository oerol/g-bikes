﻿using GreenBikes.Assets;
using GreenBikes.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.View
{
    internal class CustomerMenu
    {
        public void Start()
        {
            string title = MenuTitles.customer + "\nWillkommen zur Kundenübersicht.\nWähle eine Aktion.";
            string[] options = { "Einen neuen Kunden erstellen", "Liste aller Kunden", "Zurück" };
            Utilities.DisplayOptions(title, options);

            CustomerController controller = new CustomerController();
            controller.Load();

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    do
                    {
                        controller.Create();
                    } while (Menu.GetChoice("Kunde wurde erfolgreich erstellt! Einen weiteren erstellen?"));
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
            string title = MenuTitles.list + "\n\nUnten findest du eine Liste aller Kunden.\nMöchtest du Änderungen vornehmen?" + "\n(Tipp: Ändere die leicht die Größe dieses Fensters, für eine bessere Darstellung)";
            string[] options = { "Kunden bearbeiten", "Kunden löschen", "Zurück" };
            Utilities.DisplayOptions(title, options);

            CustomerController controller = new CustomerController();
            controller.Load();

            Utilities.ListItems(controller.customers);

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    controller.Edit();
                    break;
                case 2:
                    Utilities.RemoveEntry(controller.customers);
                    List();
                    break;
                case 3:
                    Start();
                    break;
            }
        }

    }
}
