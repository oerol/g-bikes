﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace GreenBikes.Controller
{
    internal class Utilities
    {
        private static string errorMessage = "Bitte versuche es erneut: ";
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
    }
}