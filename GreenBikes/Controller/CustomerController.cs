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
            Utilities.CreateEntry(newCustomer, new string[] { "BankAccountNumber" });
            if (Menu.GetChoice("IBAN angeben?"))
            {
                Write("\nIBAN: ");
                newCustomer.BankAccountNumber = Utilities.ReadString(3);
            }
            else
            {
                newCustomer.BankAccountNumber = "<BAR>";
            }
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
        public void Edit(int index = -1)
        {
            if (index == -1)

            {
                index = Utilities.EditEntry(customers, new string[] { "BankAccountNumber" });
            }
            else
            {
                index = Utilities.EditEntry(customers, new string[] { "BankAccountNumber" }, index);
            }

            if (index != -1)
            {
                if (Menu.GetChoice("IBAN angeben?"))
                {
                    Write("\nIBAN: ");
                    customers[index].BankAccountNumber = Utilities.ReadString(3);
                }
                else
                {
                    customers[index].BankAccountNumber = "<BAR>";
                }

                Utilities.Save(customers);
                WriteLine("\n >> " + customers[index].ToString());


                if (Menu.GetChoice("Änderung wurde vorgenommen. Möchtest du noch etwas ändern?"))
                {
                    Edit(index);
                }
            }

            new Menu().CustomerListMenu();
        }

    }
}
