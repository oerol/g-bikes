using System;
using System.Collections.Generic;
using System.Text;

namespace GreenBikes.Controller
{
    public interface IController
    {
        public void Create();
        public void Load();
        public void Edit(int index = -1);

    }
}
