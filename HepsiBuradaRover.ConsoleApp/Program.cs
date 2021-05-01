using HepsiBuradaRover.ConsoleApp.Helper;
using HepsiBuradaRover.ConsoleApp.Model.Concrete;
using System;
using System.Collections.Generic;

namespace HepsiBuradaRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var plateau = new Plateau(new Coordinates(5, 5));
                var rover = ParserHelper.ParseRover("N", "LMLMLMLMM", new List<string>() { "1","2" });
                var hBControlStation = new HepsiBuradaControlStation(plateau, rover);
                hBControlStation.Control();
            }
            catch (Exception)
            {
                Console.Error.WriteLine($"Error Occured");
            }
        }
    }
}
