using GreenBikes.Assets;
using GreenBikes.Controller;
using GreenBikes.View;
using System;
using static System.Console;

namespace GreenBikes
{
    internal class Menu
    {
        public void StartMenu()
        {

            string title = MenuTitles.start + "\n\nWillkommen bei Green Bikes!\n(Wähle einen Menüpunkt aus, indem du die dazugehörige Zahl auf deiner Tastatur drückst)";
            string[] options = { "Fahrradkategorien [Übersicht]", "Fahrräder [Übersicht]", "Kunden [Übersicht]", "Buchungen [Übersicht]" };
            Utilities.DisplayOptions(title, options);

            switch (GetPressedKey(options.Length))
            {
                case 1:
                    new BikeCategoryMenu().Start();
                    break;
                case 2:
                    new BikeMenu().Start();
                    break;
                case 3:
                    new CustomerMenu().Start();
                    break;
                case 4:
                    new BookingMenu().Start();
                    break;
            }
        }
        public static int GetPressedKey(int maxLength)
        {

            // Direkter Wechsel zum Menüpunkt, unterstützt jedoch maximal eine Länge von 9 Optionen
            // In allen anderen Fällen wird Utilities.ReadNumberWithMaxValue() genutzt

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