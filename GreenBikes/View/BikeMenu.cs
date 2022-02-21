using GreenBikes.Assets;
using GreenBikes.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.View
{
    internal class BikeMenu
    {
        public void Start()
        {
            string title = MenuTitles.bike + "\nHier dreht sich alles um Fahrräder.\nWähle eine Aktion.";
            string[] options = { "Eine neues Fahrrad erstellen", "Liste aller Fahrräder", "Zurück" };
            Utilities.DisplayOptions(title, options);

            BikeController controller = new BikeController();
            controller.Load();

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    do
                    {
                        controller.CreateBike();
                    } while (Menu.GetChoice("Fahrrad wurde erfolgreich erstellt! Ein weiteres erstellen ?"));
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
            string title = MenuTitles.list + "\n\nUnten findest du eine Liste aller Fahrräder.\nMöchtest du Änderungen vornehmen?" + "\n(Tipp: Ändere die leicht die Größe dieses Fensters, für eine bessere Darstellung)";
            string[] options = { "Fahrrad bearbeiten", "Fahrrad löschen", "Zurück" };
            Utilities.DisplayOptions(title, options);

            BikeController controller = new BikeController();
            controller.Load();

            Utilities.ListItems(controller.bikes);

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    controller.Edit();
                    break;
                case 2:
                    Utilities.RemoveEntry(controller.bikes);
                    List();
                    break;
                case 3:
                    Start();
                    break;
            }
        }
    }
}
