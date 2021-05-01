using HepsiBuradaRover.ConsoleApp.Enum;
using HepsiBuradaRover.ConsoleApp.Services.Abstract;
using System;
using System.Collections.Generic;

namespace HepsiBuradaRover.ConsoleApp.Model.Concrete
{
    public class Rover : IRover
    {
        public Coordinates Position { get; set; }
        public Direction Direction { get; set; }
        public List<Instruction> Instructions;

        public Rover(Coordinates landing, Direction direction, List<Instruction> instruction)
        {
            Position = landing;
            Direction = direction;
            Instructions = instruction;
        }

        public void PreMove(IPlateau plateau)
        {
            plateau.PreMove(this);
        }

        public void Move(IPlateau plateau)
        {
            foreach (var instruction in Instructions)
            {
                switch (instruction)
                {
                    case Instruction.Right:
                        Direction = Right(Direction);
                        break;
                    case Instruction.Left:
                        Direction = Left(Direction);
                        break;
                    case Instruction.Forward:
                        var next = Move();
                        try
                        {
                            plateau.Move(this, next);
                        }
                        finally
                        {
                            Position = next;
                        }

                        break;
                    default:
                        throw new Exception();
                }
            }
        }


        private Coordinates Move()
        {
            var x = Position.X;
            var y = Position.Y;
            return Direction switch
            {
                Direction.North => new Coordinates(x, y + 1),
                Direction.East => new Coordinates(x + 1, y),
                Direction.South => new Coordinates(x, y - 1),
                Direction.West => new Coordinates(x - 1, y),
                _ => throw new Exception()
            };
        }

        private static Direction Right(Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => throw new Exception()
            };
        }

        private static Direction Left(Direction direction)
        {
            return direction switch
            {
                Direction.North => Direction.West,
                Direction.East => Direction.North,
                Direction.South => Direction.East,
                Direction.West => Direction.South,
                _ => throw new Exception()
            };
        }
    }
}
