using System;
using System.Text;

namespace GreenBikes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Zur Anzeige von Sonderzeichen 
            new Menu().StartMenu();
        }
    }
}
