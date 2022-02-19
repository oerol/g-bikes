using GreenBikes.Assets;
using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace GreenBikes.Controller
{
    internal class BikeCategoryController
    {
        public List<BikeCategory> bikeCategories = new List<BikeCategory>();
        public void CreateBikeCategory()
        {
            Clear();
            WriteLine(MenuTitles.create + "\n\nHier kannst du eine neue Fahrradkategorie erstellen.\nGib bitte nachfolgend deine gewünschten Werte ein.\n");

            BikeCategory newBikeCategory = new BikeCategory();
            Utilities.CreateEntry(newBikeCategory);

            bikeCategories.Add(newBikeCategory);
            Utilities.Save(bikeCategories);
        }
        public void Load()
        {
            bikeCategories = Utilities.LoadList(new BikeCategory()); // Leeres Objekt für den XMLSerializer
        }

        public void Delete()
        {

            int index = Utilities.ReadNumberWithMaxValue(ReadLine(), bikeCategories.Count);
            bikeCategories.RemoveAt(index); // Exceptions werden durch ReadNumberWithMaxValue bereits abgefangen
            Utilities.Save(bikeCategories);
        }
        public void Edit(int index = -1)
        {
            if (index == -1)
            {
                index = Utilities.ReadNumberWithMaxValue(ReadLine(), bikeCategories.Count);
            }

            Menu.DisplayOptions(bikeCategories[index].ToString() + "\nWas möchtest du ändern?", new string[] { "Name", "Tägliche Gebühr", "Wöchentliche Gebühr", "Maximale Geschwindigkeit" });


            Write("\n");
            switch (Menu.GetPressedKey())
            {
                case 1:
                    Write("Name: ");
                    bikeCategories[index].Name = Utilities.ReadString();
                    break;
                case 2:
                    Write("Tägliche Gebühr: ");
                    bikeCategories[index].DailyFee = Utilities.ReadFloat();
                    break;
                case 3:
                    Write("Wöchentliche Gebühr: ");
                    bikeCategories[index].WeeklyFee = Utilities.ReadFloat();
                    break;
                case 4:
                    Write("Maximale Geschwindigkeit: ");
                    bikeCategories[index].MaximumSpeed = Utilities.ReadByte();
                    break;
            }

            Utilities.Save(bikeCategories);
            WriteLine("\n >> " + bikeCategories[index].ToString());

            if (Menu.GetChoice("Änderung wurde vorgenommen. Möchtest du noch etwas ändern?"))
            {
                Edit(index); // Wiederholt das Bearbeiten, überspringt aber das Abfragen des Index
            }
            else
            {
                new Menu().BikeListMenu();
            }

        }

    }
}
