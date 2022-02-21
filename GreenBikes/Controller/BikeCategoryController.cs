using GreenBikes.Assets;
using GreenBikes.Model;
using GreenBikes.View;
using System.Collections.Generic;
using static System.Console;
namespace GreenBikes.Controller
{
    internal class BikeCategoryController : IController
    {
        public List<BikeCategory> bikeCategories = new List<BikeCategory>();
        public void Create()
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
        public void Edit(int index = -1) // Einzige Klasse, die den Parameter nicht braucht
        {
            index = Utilities.GetChosenIndex(bikeCategories); // Frage Index ab, weil keiner vorliegt

            Utilities.EditEntry(bikeCategories, new string[] { }, index);
            new BikeCategoryMenu().List();
        }

    }
}
