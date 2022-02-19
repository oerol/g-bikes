using GreenBikes.Assets;
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
            string[] options = { "Fahrradkategorien [Übersicht]", "Fahrräder [Übersicht]" };
            DisplayOptions(title, options);



            //Utilities.Save();
            //Utilities.LoadList();
            BikeCategoryController bikeCategoryController = new BikeCategoryController();
            switch (GetPressedKey())
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
                default:
                    StartMenu();
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

            switch (GetPressedKey())
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

            switch (GetPressedKey())
            {
                case 1:
                    Write("\nBitte wähle einen Index aus und bestätige mit ENTER: ");
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

            switch (GetPressedKey())
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

            switch (GetPressedKey())
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

        public static void DisplayOptions(string title, string[] options)
        {
            Clear();
            WriteLine(title + "\n");

            for (int i = 0; i < options.Length; i++)
            {
                string spacer = $" >> {i + 1}. ";
                WriteLine(spacer + options[i]);
            }
        }
        public static uint GetPressedKey()
        {
            ConsoleKey pressedKey = ReadKey(true).Key;

            switch (pressedKey)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return 1;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return 2;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return 3;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return 4;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return 5;
            }
            return 0;
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