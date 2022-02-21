using GreenBikes.Assets;
using GreenBikes.Model;
using GreenBikes.View;
using System.Collections.Generic;
using System.Reflection;
using static System.Console;


namespace GreenBikes.Controller
{
    internal class CustomerController : IController
    {
        public List<Customer> customers = new List<Customer>();
        public void Create()
        {
            Clear();
            WriteLine(MenuTitles.create + "\n\nHier kannst du einen neuen Kunden erstellen.\nGib bitte nachfolgend deine gewünschten Werte ein.\n");

            Customer newCustomer = new Customer();
            Utilities.CreateEntry(newCustomer, new string[] { "BankAccountNumber" });

            SetBankAccountNumber(newCustomer);
            customers.Add(newCustomer);
            Utilities.Save(customers);
        }
        public void Load()
        {
            customers = Utilities.LoadList(new Customer()); // Leeres Objekt für den XMLSerializer
        }

        public void Edit(int index = -1)
        {
            PropertyInfo property;
            if (index == -1)
            {
                index = Utilities.GetChosenIndex(customers); // Frage Index ab, weil keiner vorliegt
                property = Utilities.EditEntry(customers, new string[] { "BankAccountNumber" }, index);
            }
            else
            {
                property = Utilities.EditEntry(customers, new string[] { "BankAccountNumber" }, index);
            }

            if (property.Name == "BankAccountNumber")
            {
                SetBankAccountNumber(customers[index]);
            }

            Utilities.Save(customers);
            WriteLine("\n >> " + customers[index].ToString());

            if (Menu.GetChoice("Änderung wurde vorgenommen. Möchtest du noch etwas ändern?"))
            {
                Edit(index);
            }
            new CustomerMenu().List();
        }
        private void SetBankAccountNumber(Customer customer)
        {
            if (Menu.GetChoice("IBAN angeben?"))
            {
                Write("\nIBAN: ");
                customer.BankAccountNumber = Utilities.ReadString(3);
            }
            else
            {
                customer.BankAccountNumber = "<BAR>";
            }
        }
    }
}
