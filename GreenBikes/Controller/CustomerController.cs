using GreenBikes.Assets;
using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace GreenBikes.Controller
{
    internal class CustomerController
    {
        public List<Customer> customers = new List<Customer>();
        public void CreateCustomer()
        {
            Clear();
            WriteLine(MenuTitles.create + "\n\nHier kannst du einen neuen Kunden erstellen.\nGib bitte nachfolgend deine gewünschten Werte ein.\n");

            Customer newCustomer = new Customer();
            Utilities.CreateEntry(newCustomer);

            customers.Add(newCustomer);
            Utilities.Save(customers);
        }
        public void Load()
        {
            customers = Utilities.LoadList(new Customer()); // Leeres Objekt für den XMLSerializer
        }

        public void Delete()
        {

            int index = Utilities.ReadNumberWithMaxValue(ReadLine(), customers.Count);
            customers.RemoveAt(index); // Exceptions werden durch ReadNumberWithMaxValue bereits abgefangen
            Utilities.Save(customers);
        }
        public void Edit()
        {
            Utilities.EditEntry(customers);
            // new Menu().CustomerListMenu();
        }

    }
}
