﻿using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace GreenBikes.Controller
{
    internal class BikeController
    {
        public List<Bike> bikes = new List<Bike>();
        public void CreateBike()
        {
            Clear();
            WriteLine("\n\nHier kannst du eine neues Fahrrad eintragen.\nGib bitte nachfolgend deine gewünschten Werte ein.\n");

            Write("Hersteller: ");
            string manufacturer = Utilities.ReadString();

            Write("Modell: ");
            string model = Utilities.ReadString();

            Write("Leistung (W): ");
            byte power = Utilities.ReadByte();

            Bike newBike = new Bike();
            newBike.Manufacturer = manufacturer;
            newBike.Model = model;
            newBike.Power = power;

            bikes.Add(newBike);
            Utilities.Save(bikes);
        }
        public void Load()
        {
            bikes = Utilities.LoadList(new Bike()); // Leeres Objekt für den XMLSerializer
        }

        public void Delete()
        {
            int index = Utilities.ReadNumberWithMaxValue(ReadLine(), bikes.Count);
            bikes.RemoveAt(index); // Exceptions werden durch ReadNumberWithMaxValue bereits abgefangen
            Utilities.Save(bikes);
        }
        public void Edit(int index = -1)
        {
            if (index == -1)
            {
                index = Utilities.ReadNumberWithMaxValue(ReadLine(), bikes.Count);
            }

            Menu.DisplayOptions(bikes[index].ToString() + "\nWas möchtest du ändern?", new string[] { "Hersteller", "Modell", "Leistung (W)" });


            Write("\n");
            switch (Menu.GetPressedKey())
            {
                case 1:
                    Write("Hersteller: ");
                    bikes[index].Manufacturer = Utilities.ReadString();
                    break;
                case 2:
                    Write("Modell: ");
                    bikes[index].Model = Utilities.ReadString();
                    break;
                case 3:
                    Write("Leistung (W): ");
                    bikes[index].Power = Utilities.ReadByte();
                    break;
            }

            Utilities.Save(bikes);
            WriteLine("\n >> " + bikes[index].ToString());

            if (Menu.GetChoice("Änderung wurde vorgenommen. Möchtest du noch etwas ändern?"))
            {
                Edit(index); // Wiederholt das Bearbeiten, überspringt aber das Abfragen des Index
            }
            else
            {
                new Menu().BikeListMenu();
            }

        }

    }
}
