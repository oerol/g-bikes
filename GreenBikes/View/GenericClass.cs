using GreenBikes.Assets;
using GreenBikes.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.View
{
    public class MenuInherit
    {
        public void Start<T>(T controller, string title, string[] options) where T : IController
        {
            Utilities.DisplayOptions(title, options);

            controller.Load();

            switch (Menu.GetPressedKey(options.Length))
            {
                case 1:
                    do
                    {
                        controller.Create();
                    } while (Menu.GetChoice("Fahrradkategorie wurde erfolgreich erstellt! Eine weitere erstellen?"));
                    Start(controller, title, options);
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

        }
    }
    class Testy : MenuInherit
    {
    }
}
