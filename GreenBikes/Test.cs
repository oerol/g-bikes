using GreenBikes.Controller;
using System;
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

        public void ReadDate()
        {
            string input = ReadLine();
            uint dateLength = 8;

            string formatError = "Gib das Datum bitte im Format TT.MM.JJ an: ";
            string formatException = "Etwas stimmt mit deinem Datum nicht. Bitte probiere es erneut: ";

            if (input.Length == dateLength)
            {
                string[] dateComponents = input.Split('.'); // Zum Testen des Formats

                foreach (string component in dateComponents)
                {
                    if (component.Length != 2)
                    {
                        Write(formatError);
                        ReadDate();
                    }
                }
                try
                {
                    DateTime date = DateTime.Parse(input);
                    WriteLine(date.ToString());

                }
                catch (FormatException) // Stimmt das Format TT.MM.JJ, so wird geprüft ob das Datum auch richtig ist
                {

                    Write(formatException);
                    ReadDate();
                }
            }
            else
            {
                Write(formatError);
                ReadDate();
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
