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
            using (StreamWriter writer = new StreamWriter(list[0].GetType().Name + ".xml"))
            {
                serializer.Serialize(writer, list);
            }

        }
        public static XmlSerializer GetSerializer<T>()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            return serializer;
        }

        public static void LoadList()
        {
            BikeCategory u = new BikeCategory();
            XmlSerializer serializer = GetSerializer<BikeCategory>();
            using (FileStream myFileStream = new FileStream(u.GetType().Name + ".xml", FileMode.Open))
            {
                // Deserialize-Methode aufrufen und Return-Wert casten
                u = (BikeCategory)serializer.Deserialize(myFileStream);
            }
            WriteLine("LOADEDXML: " + u.ToString());

        }
    }
}
