using GreenBikes.Controller;
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


            }
        }

        public void BikeCategoryMenu()
        {
            string title = "Bike Category";
            string[] options = { "Create", "List" };
            DisplayOptions(title, options);

            BikeCategoryController controller = new BikeCategoryController();
            switch (GetPressedKey())
            {
                case 1:
                    do
                    {
                        controller.CreateBikeCategory();
                    } while (GetChoice("Wiederholen?"));
                    BikeCategoryMenu();
                    break;
                case 2:
                    controller.ListItems(controller.bikeCategories);
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
        private uint GetPressedKey()
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
        private bool GetChoice(string prompt)
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