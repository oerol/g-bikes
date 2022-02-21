using GreenBikes.Assets;
using GreenBikes.Controller;
using static System.Console;

namespace GreenBikes.View
{
    internal class BikeCategoryMenu
    {
        public void Start()
        {
            string title = MenuTitles.bikeCategory + "\nHier dreht sich alles um Fahrradkategorien.\nWähle eine Aktion.";
            string[] options = { "Eine neue Fahrradkategorie erstellen", "Liste aller Fahrradkategorien", "Zurück" };
            Utilities.DisplayOptions(title, options);

            BikeCategoryController controller = new BikeCategoryController();
            controller.Load();

            switch (Menu.GetPressedKey(3))
            {
                case 1:
                    do
                    {
                        controller.CreateBikeCategory();
                    } while (Menu.GetChoice("Fahrradkategorie wurde erfolgreich erstellt! Eine weitere erstellen?"));
                    Start();
                    break;
                case 2:
                    List();
                    break;
                case 3:
                    new Menu().StartMenu();
                    break;
            }

        }
        public void List()
        {
            string title = MenuTitles.list + "\n\nUnten findest du eine Liste aller Fahrradkategorien.\nMöchtest du Änderungen vornehmen?" + "\n(Tipp: Ändere die leicht die Größe dieses Fensters, für eine bessere Darstellung)";
            string[] options = { "Bearbeiten", "Löschen", "Zurück" };
            Utilities.DisplayOptions(title, options);

            BikeCategoryController controller = new BikeCategoryController();
            controller.Load();

            Utilities.ListItems(controller.bikeCategories);

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    controller.Edit();
                    break;
                case 2:
                    Utilities.RemoveEntry(controller.bikeCategories);
                    List();
                    break;
                case 3:
                    Start();
                    break;
            }
        }
    }
}
