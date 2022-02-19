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
        public void Edit()
        {
            Utilities.EditEntry(bikeCategories);
            new Menu().BikeCategoryListMenu();
        }

    }
}
