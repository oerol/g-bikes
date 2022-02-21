using GreenBikes.Model;
using GreenBikes.View;
using System.Collections.Generic;
using System.Reflection;
using static System.Console;

namespace GreenBikes.Controller
{
    internal class BikeController : IController
    {
        public List<Bike> bikes = new List<Bike>();
        public void Create()
        {
            int categoriesCount = Utilities.LoadList(new BikeCategory()).Count;

            if (categoriesCount > 0)
            {
                Clear();

                WriteLine(Assets.MenuTitles.create + "\n\nHier kannst du eine neues Fahrrad eintragen.\nGib bitte nachfolgend deine gewünschten Werte ein.\n");

                Bike newBike = new Bike();
                Utilities.CreateEntry(newBike, new string[] { "Category" }); // Um davor die Liste der Kategorien anzuzeigen, wird der Wert für Kategorie selber bestimmt

                SetCategory(newBike);

                bikes.Add(newBike);
                Utilities.Save(bikes);

                if (Menu.GetChoice("Fahrradkategorie wurde erfolgreich erstellt! Eine weitere erstellen?"))
                {
                    Create();
                }
            }
            else
            {
                WriteLine("Bitte erstelle zuerst eine Fahrradkategorie bevor du ein Fahrrad erstellst!");
                System.Threading.Thread.Sleep(700);
            }
            new BikeMenu().Start();

        }
        public void Load()
        {
            bikes = Utilities.LoadList(new Bike()); // Leeres Objekt für den XMLSerializer
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
            new BikeMenu().List();
        }
        public void SetCategory(Bike bike)
        {
            Write("\n");

            List<BikeCategory> categories = Utilities.LoadList(new BikeCategory());

            Utilities.ListItems(categories);

            Write("\nZu welcher Kategorie gehört dieses Fahrrad?: ");
            int index = Utilities.ReadNumberWithMaxValue(ReadLine(), categories.Count);
            bike.Category = categories[index];
        }


    }
}
