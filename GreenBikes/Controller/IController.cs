using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Controller
{
    public interface IController
    {
        public void Create();
        public void Load(); // Laden aller Elemente aus XML-Datei (sofern vorhanden)
        public void Edit(int index = -1);

    }
}
