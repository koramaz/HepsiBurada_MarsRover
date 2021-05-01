using HepsiBuradaRover.ConsoleApp.Services.Abstract;
using System;
using System.Collections.Generic;

namespace HepsiBuradaRover.ConsoleApp.Model.Concrete
{
    public class Plateau:IPlateau
    {
        public Coordinates Size { get; }
        private readonly IDictionary<Coordinates, IRover>  position = new Dictionary<Coordinates, IRover>();

        public Plateau(Coordinates c)
        {
            Size = c;
        }

        public void PreMove(IRover rover)
        {
            position.Add(rover.Position, rover);
        }

        public void Move(IRover rover, Coordinates destination)
        {

            if (!position.TryGetValue(rover.Position, out var self) || self != rover)
            {
                throw new Exception();
            }

            if (IsAccrossBorder(destination))
            {
                throw new Exception();
            }

            if (position.TryGetValue(destination, out _))
            {
                throw new Exception();
            }

            position.Remove(rover.Position);
            position.Add(destination, rover);
        }

        private bool IsAccrossBorder(Coordinates roverPosition)
        {
            return roverPosition.X > Size.X || roverPosition.Y > Size.Y || roverPosition.X < 0 || roverPosition.Y < 0;
        }
    }
}
