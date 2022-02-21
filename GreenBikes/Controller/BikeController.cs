using GreenBikes.Model;
using System.Collections.Generic;
using System.Reflection;
using static System.Console;

namespace GreenBikes.Controller
{
    internal class BikeController
    {
        public List<Bike> bikes = new List<Bike>();
        public void CreateBike()
        {
            Clear();
            WriteLine(Assets.MenuTitles.create + "\n\nHier kannst du eine neues Fahrrad eintragen.\nGib bitte nachfolgend deine gewünschten Werte ein.\n");

            Bike newBike = new Bike();
            Utilities.CreateEntry(newBike, new string[] { "Category" }); // Um davor die Liste der Kategorien anzuzeigen, wird der Wert für Kategorie selber bestimmt

            SetCategory(newBike);

            bikes.Add(newBike);
            Utilities.Save(bikes);
        }
        public void Load()
        {
            bikes = Utilities.LoadList(new Bike()); // Leeres Objekt für den XMLSerializer
        }

        public void Delete()
        {
            int index = Utilities.ReadNumberWithMaxValue(ReadLine(), bikes.Count);
            bikes.RemoveAt(index); // Exceptions werden durch ReadNumberWithMaxValue bereits abgefangen
            Utilities.Save(bikes);
        }
        public void Edit(int index = -1)
        {
            PropertyInfo property;
            if (index == -1)
            {
                index = Utilities.GetChosenIndex(bikes); // Frage Index ab, weil keiner vorliegt
                property = Utilities.EditEntry(bikes, new string[] { "Category" }, index);

            }
            else
            {
                property = Utilities.EditEntry(bikes, new string[] { "Category" }, index);
            }

            if (property.Name == "Category")
            {
                SetCategory(bikes[index]);
            }

            Utilities.Save(bikes);
            WriteLine("\n >> " + bikes[index].ToString());

            if (Menu.GetChoice("Änderung wurde vorgenommen. Möchtest du noch etwas ändern?"))
            {
                Edit(index);
            }
            new Menu().BikeListMenu();
        }
        public void SetCategory(Bike bike)
        {
            Write("\n");

            List<BikeCategory> categories = Utilities.LoadList(new BikeCategory()); // Leeres Objekt für den XMLSerializer ä: in die methode
            Utilities.ListItems(categories);

            Write("\nZu welcher Kategorie gehört dieses Fahrrad?: ");
            int index = Utilities.ReadNumberWithMaxValue(ReadLine(), categories.Count);
            bike.Category = categories[index];
        }
    }
}
