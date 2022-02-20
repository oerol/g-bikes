﻿using GreenBikes.Assets;
using GreenBikes.Controller;
using System;
using static System.Console;

namespace GreenBikes
{
    internal class Menu
    {
        public void StartMenu()
        {

            string title = MenuTitles.start + "\n\nWillkommen bei Green Bikes!\n(Wähle einen Menüpunkt aus, indem du die dazugehörige Zahl auf deiner Tastatur drückst)";
            string[] options = { "Fahrradkategorien [Übersicht]", "Fahrräder [Übersicht]", "Kunden [Übersicht]" };
            DisplayOptions(title, options);

            // TODO defaults entfernen bei switch
            // TODO getpressedkey mit options.length stuern

            //Utilities.Save();
            //Utilities.LoadList();
            BikeCategoryController bikeCategoryController = new BikeCategoryController();
            switch (GetPressedKey(options.Length))
            {
                case 0: // Tests
                    do
                    {
                        bikeCategoryController.CreateBikeCategory();
                    } while (GetChoice("Wiederholen?"));
                    break;
                case 1:
                    BikeCategoryMenu();
                    break;
                case 2:
                    BikeMenu();
                    break;
                case 3:
                    CustomerMenu();
                    break;

            }
        }


        public void BikeCategoryMenu()
        {
            string title = MenuTitles.bikeCategory + "\nHier dreht sich alles um Fahrradkategorien.\nWähle eine Aktion.";
            string[] options = { "Eine neue Fahrradkategorie erstellen", "Liste aller Fahrradkategorien", "Zurück" };
            DisplayOptions(title, options);

            BikeCategoryController controller = new BikeCategoryController();
            controller.Load();

            switch (GetPressedKey(3))
            {
                case 1:
                    do
                    {
                        controller.CreateBikeCategory();
                    } while (GetChoice("Fahrradkategorie wurde erfolgreich erstellt! Eine weitere erstellen?"));
                    BikeCategoryMenu();
                    break;
                case 2:
                    BikeCategoryListMenu();
                    break;
                case 3:
                    StartMenu();
                    break;
                default:
                    BikeCategoryMenu();
                    break;
            }

        }

        public void BikeCategoryListMenu()
        {
            string title = MenuTitles.list + "\n\nUnten findest du eine Liste aller Fahrradkategorien.\nMöchtest du Änderungen vornehmen?" + "\n(Tipp: Ändere die leicht die Größe dieses Fensters, für eine bessere Darstellung)";
            string[] options = { "Bearbeiten", "Löschen", "Zurück" };
            DisplayOptions(title, options);

            BikeCategoryController controller = new BikeCategoryController();
            controller.Load();

            Utilities.ListItems(controller.bikeCategories);

            switch (GetPressedKey(3))
            {
                case 1:
                    controller.Edit();
                    break;
                case 2:
                    do
                    {
                        Write("\nBitte wähle einen Index aus und bestätige mit ENTER: ");

                        Utilities.RemoveEntry(controller.bikeCategories);
                    } while (GetChoice("Wiederholen?"));
                    BikeCategoryListMenu();
                    break;
                case 3:
                    BikeCategoryMenu();
                    break;
                default:
                    BikeCategoryListMenu();
                    break;
            }
        }
        public void BikeMenu()
        {
            string title = MenuTitles.bike + "\nHier dreht sich alles um Fahrräder.\nWähle eine Aktion.";
            string[] options = { "Eine neues Fahrrad erstellen", "Liste aller Fahrräder", "Zurück" };
            DisplayOptions(title, options);

            BikeController controller = new BikeController();
            controller.Load();

            switch (GetPressedKey(3))
            {
                case 1:
                    do
                    {
                        controller.CreateBike();
                    } while (GetChoice("Fahrrad wurde erfolgreich erstellt! Ein weiteres erstellen ?"));
                    BikeMenu();
                    break;
                case 2:
                    BikeListMenu();
                    break;
                case 3:
                    StartMenu();
                    break;
                default:
                    BikeMenu();
                    break;
            }
        }

        public void BikeListMenu()
        {
            string title = MenuTitles.list + "\n\nUnten findest du eine Liste aller Fahrräder.\nMöchtest du Änderungen vornehmen?" + "\n(Tipp: Ändere die leicht die Größe dieses Fensters, für eine bessere Darstellung)";
            string[] options = { "Bearbeiten", "Löschen", "Zurück" };
            DisplayOptions(title, options);

            BikeController controller = new BikeController();
            controller.Load();

            Utilities.ListItems(controller.bikes);

            switch (GetPressedKey(3))
            {
                case 1:
                    controller.Edit();
                    break;
                case 2:
                    do
                    {
                        Utilities.RemoveEntry(controller.bikes);
                    } while (controller.bikes.Count != 0 && GetChoice("Eintrag gelöscht! Wiederholen?"));
                    BikeListMenu();
                    break;
                case 3:
                    BikeMenu();
                    break;
                default:
                    BikeListMenu();
                    break;
            }
        }

        public void CustomerMenu()
        {
            string title = MenuTitles.customer + "\nWillkommen zur Kundenübersicht.\nWähle eine Aktion.";
            string[] options = { "Einen neuen Kunden erstellen", "Liste aller Kunden", "Zurück" };
            DisplayOptions(title, options);

            CustomerController controller = new CustomerController();
            controller.Load();

            switch (GetPressedKey(3))
            {
                case 1:
                    do
                    {
                        controller.CreateCustomer();
                    } while (GetChoice("Kunde wurde erfolgreich erstellt! Eine weitere erstellen?"));
                    CustomerMenu();
                    break;
                case 2:
                    CustomerListMenu();
                    break;
                case 3:
                    StartMenu();
                    break;
            }
        }

        public void CustomerListMenu()
        {
            string title = MenuTitles.list + "\n\nUnten findest du eine Liste aller Fahrräder.\nMöchtest du Änderungen vornehmen?" + "\n(Tipp: Ändere die leicht die Größe dieses Fensters, für eine bessere Darstellung)";
            string[] options = { "Bearbeiten", "Löschen", "Zurück" };
            DisplayOptions(title, options);

            CustomerController controller = new CustomerController();
            controller.Load();

            Utilities.ListItems(controller.customers);

            switch (GetPressedKey(3))
            {
                case 1:
                    controller.Edit();
                    break;
                case 2:
                    do
                    {
                        Utilities.RemoveEntry(controller.customers);
                    } while (controller.customers.Count != 0 && GetChoice("Eintrag gelöscht! Wiederholen?"));
                    CustomerListMenu();
                    break;
                case 3:
                    CustomerMenu();
                    break;
                default:
                    BikeListMenu();
                    break;
            }
        }

        public static void DisplayOptions(string title, string[] options)
        {
            Clear();
            WriteLine(title + "\n");

            for (int i = 0; i < options.Length; i++)
            {
                string spacer = $" >> {i + 1}. ";
                WriteLine(spacer + options[i]);
            }
            Write("\n");
        }
        public static int GetPressedKey(int maxLength)
        {
            ConsoleKey pressedKey = ReadKey(true).Key;

            int selected = 0;
            switch (pressedKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    selected = 1;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    selected = 2;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    selected = 3;
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    selected = 4;
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    selected = 5;
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    selected = 6;
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    selected = 7;
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    selected = 8;
                    break;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    selected = 9;
                    break;
            }
            if (selected > maxLength)
            {
                Write($"\rBitte gib eine Zahl unter {maxLength} ein.");
                return GetPressedKey(maxLength);
            }
            return selected;
        }
        public static bool GetChoice(string prompt)
        {
            ConsoleKey pressedKey;

            do
            {
                Write(" \n" + prompt + "(j/n)");
                pressedKey = ReadKey().Key;

            } while (pressedKey != ConsoleKey.J && pressedKey != ConsoleKey.N);

            if (pressedKey == ConsoleKey.J)
            {
                return true;
            }
            return false;
        }
    }

}