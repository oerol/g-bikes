﻿using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace GreenBikes.Controller
{
    internal class BikeCategoryController
    {
        private List<BikeCategory> bikeCategories = new List<BikeCategory>();
        public void CreateBikeCategory()
        {
            Clear();
            Write("Name: ");
            string name = ReadLine();

            Write("Tägliche Gebühr: ");
            float dailyFee = Utilities.ReadFloat();

            Write("Wöchentliche Gebühr: ");
            float weeklyFee = Utilities.ReadFloat();

            Write("Maximale Geschwindigkeit: ");
            byte maximumSpeed = Utilities.ReadByte();

            BikeCategory newBike = new BikeCategory(name, dailyFee, weeklyFee, maximumSpeed);
            bikeCategories.Add(newBike);
            ListItems(bikeCategories);
        }
        public void ListItems<T>(List<T> list)
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
    }
}
