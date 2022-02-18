using GreenBikes.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
namespace GreenBikes.Controller
{
    internal class BikeCategoryController
    {
        public List<BikeCategory> bikeCategories = new List<BikeCategory>();
        public void CreateBikeCategory()
        {
            Clear();
            Write("Name: ");
            string name = Utilities.ReadString();

            Write("Tägliche Gebühr: ");
            float dailyFee = Utilities.ReadFloat();

            Write("Wöchentliche Gebühr: ");
            float weeklyFee = Utilities.ReadFloat();

            Write("Maximale Geschwindigkeit: ");
            byte maximumSpeed = Utilities.ReadByte();

            BikeCategory newBike = new BikeCategory();
            newBike.Name = name;
            newBike.DailyFee = dailyFee;
            newBike.WeeklyFee = weeklyFee;
            newBike.MaximumSpeed = maximumSpeed;

            bikeCategories.Add(newBike);


            Utilities.ListItems(bikeCategories);
            Utilities.Save(bikeCategories);
        }
        public void Load()
        {
            bikeCategories = Utilities.LoadList(new BikeCategory()); // Leeres Objekt für den XMLSerializer
        }

        public void Delete(string input)
        {
            int index = Utilities.ReadNumberWithMaxValue(input, bikeCategories.Count);
            bikeCategories.RemoveAt(index); // Exceptions werden durch ReadNumberWithMaxValue bereits abgefangen
            Utilities.Save(bikeCategories);
        }
        public void Edit(string input)
        {

        }

    }
}
