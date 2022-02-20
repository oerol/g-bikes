using GreenBikes.Controller;
using System;
using System.Collections.Generic;
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
            string iban = "DE00360605910001965466";
            string nums = iban.Remove(0, 4);
            WriteLine(nums.Length);
            ulong numbersOnly = ulong.Parse(Regex.Match(nums, @"\d+").Value);
            ulong rechnung = 98 - (numbersOnly % 97);
            WriteLine(rechnung);

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
