using GreenBikes.Controller;
using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace GreenBikes
{
    internal class Test
    {
        public void Run()
        {
            Person person = new Person();
            foreach (var property in person.GetType().GetProperties())
            {
                // WriteLine(person.ToGerman(property.Name), property.GetValue(person));
                string spacer = ": ";
                Write(person.ToGerman(property.Name) + spacer);

                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(person, Utilities.ReadString());
                    WriteLine("* STRING");
                }
                else if (property.PropertyType == typeof(byte))
                {
                    property.SetValue(person, Utilities.ReadByte());
                    WriteLine("* BYTE");
                }
                else if (property.PropertyType == typeof(float))
                {
                    property.SetValue(person, Utilities.ReadFloat());
                    WriteLine("* FLOAT");
                }
                else if (property.PropertyType == typeof(uint))
                {
                    property.SetValue(person, Utilities.ReadUint());
                    WriteLine("* UINT");
                }
                else
                {
                    WriteLine(property.PropertyType);

                }
            }
            WriteLine(person.Name);
            WriteLine(person.Age);
        }

        public void Run2()
        {

            Customer customer = new Customer();
            Person person = new Person();


            if (person.GetType().BaseType == typeof(object))
            {
                Write("JAAAAAAAAAAAAAAAAAAAAAAAAa");
                List<string> parentProperties = new List<string>();
                foreach (var property in customer.GetType().BaseType.GetProperties())
                {
                    parentProperties.Add(property.Name);
                    // Do Stuffä
                }
                foreach (var property in customer.GetType().GetProperties())
                {
                    if (!parentProperties.Contains(property.Name))
                    {
                        Write("MEW" + property.Name);
                        // Do Stuff

                    }
                }
            }


            int count = 0;


            WriteLine("\n");
            WriteLine(count);

            WriteLine("TEST" + person.GetType().BaseType.ToString());
            WriteLine("TEST" + person.GetType().BaseType.Name);
            WriteLine("TEST" + customer.GetType().BaseType);

            foreach (var property in new Person().GetType().BaseType.GetProperties())
            {
                WriteLine(property);
            }
        }
    }
    internal class Person
    {
        public string Name { get; set; }
        public byte Age { get; set; }

        public uint Cash { get; set; }

        public string ToGerman(string englishText)
        {
            string translatedText = "";
            switch (englishText)
            {
                case "Name":
                    translatedText = "VORNAME";
                    break;
                case "Age":
                    translatedText = "ALTER";
                    break;
                case "Cash":
                    translatedText = "GELD";
                    break;
                default:
                    translatedText = "WEISS NET";
                    break;
            }
            return translatedText;
        }
    }
}
