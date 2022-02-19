using System;
using System.Collections.Generic;
using System.Text;
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
                WriteLine(person.ToGerman(property.Name), property.GetValue(person));
                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(person, "Jas");
                    WriteLine("* STRING");
                }
                else if (property.PropertyType == typeof(byte))
                {
                    byte b = 255;
                    property.SetValue(person, b);
                    WriteLine("* BYTE");
                }
                else
                {
                    WriteLine(property.PropertyType);

                }
            }
            WriteLine(person.Name);
            WriteLine(person.Age);
        }
    }
    internal class Person
    {
        public string Name { get; set; }
        public byte Age { get; set; }

        public string ToGerman(string englishText)
        {
            string translatedText = "";
            switch (englishText)
            {
                case "Name":
                    translatedText = "VORNAME";
                    break;
            }
            return translatedText;
        }
    }
}
