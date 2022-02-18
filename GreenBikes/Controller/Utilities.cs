using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using static System.Console;

namespace GreenBikes.Controller
{
    public class Utilities
    {
        private static string errorMessage = "Bitte versuche es erneut: ";

        public static string ReadString()
        {
            string result = "";
            while (result == "")
            {
                result = ReadLine();
                if (result != "")
                {
                    return result;
                }
                else
                {
                    Write(errorMessage);
                }
            }
            return result;
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
        public static void Save<T>(List<T> list)
        {

            XmlSerializer serializer = GetSerializer<T>();
            WriteLine(serializer.ToString());


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
            Write("\n");
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
            if (index > maxValue - 1) // Ersetzt das Fangen der ArgumentOutOutOfRange Exception 
            {
                Write($"Bitte wähle einen Wert zwischen 1 und {maxValue}: ");
                return ReadNumberWithMaxValue(ReadLine(), maxValue);
            }
            return index;
        }
    }
}
