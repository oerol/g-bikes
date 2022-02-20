using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using static System.Console;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace GreenBikes.Controller
{
    public class Utilities
    {
        private static string errorMessage = "Bitte versuche es erneut: ";
        private static string noNumbersMessage = "Hier sind nur Buchstaben erlaubt. " + errorMessage;
        private static string onlyNumbersMessage = "Hier sind nur Zahlen erlaubt. " + errorMessage;

        public static string ReadString(uint mode = 0)
        {
            string result = ReadLine();

            if (result != "")
            {
                if (mode == 0)
                {
                    return result;
                }
                else if (mode == 1)
                {
                    if (ReadAlphabetical(result))
                    {
                        return result;
                    }
                    return ReadString(1);
                }
                else if (mode == 2)
                {
                    if (ReadPhoneNumber(result))
                    {
                        return result;
                    }
                    return ReadString(2);
                }
                else if (mode == 3)
                {
                    if (ReadBankAccountNumber(result))
                    {
                        return result;
                    }
                    return ReadString(3);

                }
            }

            Write(errorMessage);
            return ReadString(mode);
        }

        private static bool ReadAlphabetical(string input)
        {
            Regex noNumbers = new Regex("^[a-zA-Z]+$");
            bool containsNoNumbers = noNumbers.IsMatch(input);
            if (containsNoNumbers)
            {
                return true;
            }
            else
            {
                Write(noNumbersMessage);
                return false;
            }
        }
        private static bool ReadPhoneNumber(string input)
        {
            uint minLength = 11;
            uint maxLength = 13;

            if (input.Length >= 11 && input.Length <= 13)
            {
                return true;
            }
            else
            {
                Write($"Eine Handynummer muss zwischen {minLength} und {maxLength} Zeichen haben: ");

            }
            return false;
        }
        private static bool ReadBankAccountNumber(string input)
        {
            string bankAccountNumberCountry = "DE";
            Regex startsWith = new Regex($"^{bankAccountNumberCountry}");
            bool correctCountryCode = startsWith.IsMatch(input.ToUpper()); // ToUpper() um Fälle wie "de", "De" abzufangen 
            if (correctCountryCode)
            {
                uint bankAccountNumberLength = 22;
                if (input.Length == bankAccountNumberLength)
                {
                    return true;
                }
                Write($"IBAN muss eine Länge von {bankAccountNumberLength} Zeichen besitzen {errorMessage}");
                return false;

            }
            else
            {
                Write($"IBAN muss mit {bankAccountNumberCountry} starten: {errorMessage}");
                return false;
            }
        }
        public static float ReadFloat()
        {
            float number = 0;
            while (number == 0)
            {
                try
                {
                    number = float.Parse(ReadLine());
                    return number;
                }
                catch (FormatException)
                {
                    Write(errorMessage);
                }
            }
            return number;
        }
        public static byte ReadByte()
        {
            byte number = 0;
            while (number == 0)
            {
                try
                {
                    number = byte.Parse(ReadLine());
                    return number;
                }
                catch (Exception e)
                {
                    if (e is OverflowException)
                    {
                        Write("Dein Wert scheint zu hoch zu sein, versuche es erneut:  ");
                    }
                    else if (e is FormatException)
                    {
                        Write(errorMessage);
                    }
                }
            }
            return number;
        }
        public static uint ReadUint(int minLength = 0, int maxLength = 0)
        {
            uint number;
            try
            {
                number = uint.Parse(ReadLine());
                if (minLength == 0 && maxLength == 0)
                {
                    return number;
                }
                else
                {
                    if (number.ToString().Length >= minLength && number.ToString().Length <= maxLength)
                    {
                        return number;
                    }

                    if (minLength != maxLength)
                    {
                        Write($"Deine Eingabe muss zwischen {minLength} und {maxLength} Zeichen haben: ");
                    }
                    else
                    {
                        Write($"Deine Eingabe muss zwischen genau {maxLength} Zeichen haben: ");

                    }
                    return ReadUint(minLength, maxLength);
                }
            }
            catch (Exception e)
            {
                if (e is OverflowException)
                {
                    Write("Dein Wert scheint zu hoch zu sein, versuche es erneut:  ");
                }
                else if (e is FormatException)
                {
                    Write(onlyNumbersMessage);
                }
                return ReadUint(minLength, maxLength);
            }
        }
        public static bool ReadBool()
        {
            return Menu.GetChoice("Wähle weise");
        }
        public static void Save<T>(List<T> list)
        {

            XmlSerializer serializer = GetSerializer<T>();


            using (StreamWriter writer = new StreamWriter(list.GetType().GetGenericArguments()[0].Name + ".xml"))
            {
                serializer.Serialize(writer, list);
            }

        }
        public static XmlSerializer GetSerializer<T>()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            return serializer;
        }

        public static List<T> LoadList<T>(T element)
        {
            List<T> list = new List<T>();
            XmlSerializer serializer = GetSerializer<T>();
            try
            {
                using (FileStream myFileStream = new FileStream(element.GetType().Name + ".xml", FileMode.Open))
                {
                    // Deserialize-Methode aufrufen und Return-Wert casten
                    list = (List<T>)serializer.Deserialize(myFileStream);
                    return list;
                }
            }
            catch (FileNotFoundException)
            {
                return list; // Übergebe leere Liste, falls keine gespeicherte Datei vorliegt
            }


        }
        public static void ListItems<T>(List<T> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {

                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine(i + 1 + ". " + list[i].ToString());
                ResetColor();
            }
            Write("\n");

        }
        public static int ReadNumberWithMaxValue(string input, int maxValue)
        {
            int index;
            try
            {
                index = int.Parse(input) - 1;
            }
            catch (FormatException)
            {
                Write($"Bitte wähle einen Wert zwischen 1 und {maxValue}: ");
                return ReadNumberWithMaxValue(ReadLine(), maxValue);
            }
            if (index > maxValue - 1 || index < 0) // Ersetzt das spätere Fangen der ArgumentOutOutOfRange Exception 
            {
                Write($"Bitte wähle einen Wert zwischen 1 und {maxValue}: ");
                return ReadNumberWithMaxValue(ReadLine(), maxValue);
            }

            return index;
        }
        public static DateTime ReadDate()
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
                        return ReadDate();
                    }
                }
                try
                {
                    DateTime date = DateTime.Parse(input);
                    return date;
                }
                catch (FormatException) // Stimmt das Format TT.MM.JJ, so wird geprüft ob das Datum auch richtig ist
                {

                    Write(formatException);
                    return ReadDate();
                }
            }
            else
            {
                Write(formatError);
                return ReadDate();
            }
        }
        public static List<T> RemoveEntry<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                WriteLine("Keine Einträge zum Löschen verfügbar!");
                System.Threading.Thread.Sleep(700); // Danach wird der Warnhinweis ausgeblendet
                return list;
            }
            else
            {
                Write("\nBitte wähle einen Index aus und bestätige mit ENTER: ");
                int index = Utilities.ReadNumberWithMaxValue(ReadLine(), list.Count);

                list.RemoveAt(index); // Exceptions werden durch ReadNumberWithMaxValue bereits abgefangen
                Save(list);

                return list;
            }
        }
        public static void CreateEntry<T>(T model, string[] ignore = null) where T : IModel
        {
            foreach (var property in model.GetType().GetProperties())
            {
                if (ignore != null)
                {
                    if (ignore.Contains(property.Name))
                    {
                        continue;
                    }
                }
                string spacer = ": ";
                Write(model.ToGerman(property.Name) + spacer);

                SetPropertyValue(model, property);
            }

        }

        public static string SpecificStringOptions(string property)
        {
            string[] noNumbers = { "FirstName", "LastName", "City" };

            string bankAccountNumber = "BankAccountNumber";
            string phoneNumber = "PhoneNumber";

            if (noNumbers.Contains(property))
            {
                return ReadString(1);
            }
            else if (phoneNumber == property)
            {
                return ReadString(2);
            }
            else if (bankAccountNumber == property)
            {
                return ReadString(3);
            }
            else
            {
                return ReadString();
            }
        }
        public static uint SpecificUintOptions(string property)
        {
            if (property == "PostalCode")
            {
                return ReadUint(5, 5);
            }
            else
            {
                return ReadUint();
            }
        }



        public static void SetPropertyValue<T>(T model, PropertyInfo property, string[] ignore = null) where T : IModel
        {
            if (ignore != null)
            {
                if (ignore.Contains(property.Name))
                {
                    return;
                }
            }

            if (property.PropertyType == typeof(string))
            {
                property.SetValue(model, SpecificStringOptions(property.Name));
            }
            else if (property.PropertyType == typeof(byte))
            {
                property.SetValue(model, ReadByte());
            }
            else if (property.PropertyType == typeof(float))
            {
                property.SetValue(model, ReadFloat());
            }
            else if (property.PropertyType == typeof(uint))
            {
                property.SetValue(model, SpecificUintOptions(property.Name));
            }
            else if (property.PropertyType == typeof(bool))
            {
                property.SetValue(model, Menu.GetChoice(""));
                Write("\n");
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                property.SetValue(model, ReadDate());
            }
        }
        public static int EditEntry<T>(List<T> modelList, string[] ignore = null, int index = -1) where T : IModel
        {
            string noEntriesToEdit = "Keine Einträge zum Bearbeiten verfügbar!";
            string askForIndex = "\nWas möchtest du ändern?";
            if (modelList.Count == 0)
            {
                WriteLine(noEntriesToEdit);
                System.Threading.Thread.Sleep(700); // Danach wird der Warnhinweis ausgeblendet
                return -1;
            }

            if (index == -1) // Fragt Index ab, sofern keiner vorliegt
            {

                Write("\nBitte wähle einen Index aus und bestätige mit ENTER: ");
                index = Utilities.ReadNumberWithMaxValue(ReadLine(), modelList.Count);
            }
            string[] translatedProperties = GetGermanProperties(modelList[index]);
            string editPrompt = Assets.MenuTitles.edit + "\n>>> " + modelList[index].ToString() + askForIndex;
            Menu.DisplayOptions(editPrompt, translatedProperties);


            int pressedKey = Menu.GetPressedKey(modelList[index].GetType().GetProperties().Length) - 1;



            var chosenProperty = modelList[index].GetType().GetProperties()[pressedKey];

            if (ignore != null && ignore.Contains(chosenProperty.Name))
            {
                return index;
            }

            string spacer = ": ";
            Write(translatedProperties[pressedKey] + spacer);
            SetPropertyValue(modelList[index], chosenProperty, ignore);

            Utilities.Save(modelList);
            WriteLine("\n >> " + modelList[index].ToString());

            if (Menu.GetChoice("Änderung wurde vorgenommen. Möchtest du noch etwas ändern?"))
            {
                EditEntry(modelList, ignore, index);
            }
            return -1;
        }
        private static string[] GetGermanProperties<T>(T model) where T : IModel
        {
            var properties = model.GetType().GetProperties();

            string[] translatedProperties = new string[0]; // Array statt Liste, weil das Array nach Erstellung nicht bearbeitet wird

            foreach (var property in properties)
            {
                string translated = model.ToGerman(property.Name);
                translatedProperties = translatedProperties.Append(translated).ToArray();
            }
            return translatedProperties;
        }
        public static string TranslateBool(bool b)
        {
            string translatedText = b ? "Ja" : "Nein";
            return translatedText;
        }
    }
}
