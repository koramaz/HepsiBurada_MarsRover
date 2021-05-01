using HepsiBuradaRover.ConsoleApp.Enum;
using HepsiBuradaRover.ConsoleApp.Model.Concrete;
using System;
using System.Collections.Generic;

namespace HepsiBuradaRover.ConsoleApp.Helper
{
    public static class ParserHelper
    {
        public static Coordinates ParseCoordinates(List<string> coordinates)
        {
            int x, y;
            try
            {
                x = int.Parse(coordinates[0]);
                y = int.Parse(coordinates[1]);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error during parsing ParseCoordinates", e);
            }

            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Coordinates must be positive");
            }

            return new Coordinates(x, y);
        }

        public static Direction ParseDirection(string direction)
        {
            return direction switch
            {
                "S" => Direction.South,
                "N" => Direction.North,
                "E" => Direction.East,
                "W" => Direction.West,
                _ => throw new ArgumentException($"Unknown direction: '{direction}'")
            };
        }

        public static List<Instruction> ParseInstructions(string l)
        {
            var instruction = new List<Instruction>();
            if (l == null)
            {
                return instruction;
            }

            foreach (var i in l)
            {
                instruction.Add(ParseInstruction(i));
            }

            return instruction;
        }

        public static Instruction ParseInstruction(char i)
        {
            return i switch
            {
                'M' => Instruction.Forward,
                'L' => Instruction.Left,
                'R' => Instruction.Right,
                _ => throw new ArgumentException($"Occuring when call ParseInstruction: '{i}'")
            };
        }

        public static Rover ParseRover(string directions, string instruction, List<string> coordinate)
        {
            Coordinates coordinates = ParseCoordinates(coordinate);
            Direction direction = ParseDirection(directions);
            List<Instruction> instructions = ParseInstructions(instruction);

            return new Rover(coordinates, direction, instructions);
        }

    }
}
