using System;
using static System.Console;

namespace GreenBikes
{
    internal class Menu
    {
        public void StartMenu()
        {
            string title = "Welcome to Green Bikes. How can I help you?";
            string[] options = { "Bike Categories" };
            DisplayOptions(title, options);

            switch (GetChoice())
            {
                case 1:
                    BikeCategoryMenu();
                    break;

            }
        }

        public void BikeCategoryMenu()
        {
            string title = "Bike Category";
            string[] options = { "Create" };
            DisplayOptions(title, options);

            switch (GetChoice())
            {
                case 1:

                    break;

            }
        }

        private void DisplayOptions(string title, string[] options)
        {
            Clear();
            WriteLine(title + "\n");

            for (int i = 0; i < options.Length; i++)
            {
                string spacer = $" > {i + 1}. ";
                WriteLine(spacer + options[i]);
            }
        }
        private uint GetChoice()
        {
            ConsoleKey pressedKey = ReadKey().Key;

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
    }

}