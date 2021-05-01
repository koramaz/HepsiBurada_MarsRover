using HepsiBuradaRover.ConsoleApp.Services.Abstract;
using System;

namespace HepsiBuradaRover.ConsoleApp
{
    public class HepsiBuradaControlStation : IHepsiBuradaControlStation
    {
        private readonly IRover rover;
        private readonly IPlateau plateau;

        public HepsiBuradaControlStation(IPlateau plateau, IRover rover)
        {
            this.plateau = plateau;
            this.rover = rover;
        }

        public string Control()
        {
            try
            {
                rover.PreMove(plateau);
                rover.Move(plateau);
                Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Direction}");
                return $"{rover.Position.X} {rover.Position.Y} {rover.Direction}";
            }
            catch (Exception)
            {
                Console.WriteLine("Error While Processing Control");
                return "Error While Processing Control";
            }
        }
    }
}
