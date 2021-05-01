using HepsiBuradaRover.ConsoleApp;
using HepsiBuradaRover.ConsoleApp.Enum;
using HepsiBuradaRover.ConsoleApp.Model.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HepsiBuradaRover.UnitTests
{
    [TestClass]
    public class HepsiBuradaRoverTests
    {
        [TestMethod]
        public void RoverCheckOutput()
        {
            Plateau plateauOne = new Plateau(new Coordinates(5, 5));
            Rover firstRover = new Rover(new Coordinates(1, 2), Direction.North, new List<Instruction> { Instruction.Left, Instruction.Forward, Instruction.Left, Instruction.Forward, Instruction.Left, Instruction.Forward, Instruction.Left, Instruction.Forward, Instruction.Forward });
            HepsiBuradaControlStation st = new HepsiBuradaControlStation(plateauOne, firstRover);
            Assert.AreEqual(st.Control(), "1 3 North");
        }

        [TestMethod]
        public void IncorrectInput()
        {
            Plateau plateauOne = new Plateau(new Coordinates(5, 5));
            Rover firstRover = new Rover(new Coordinates(1, 2), Direction.North, new List<Instruction> { Instruction.Left, Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward, Instruction.Forward });
            HepsiBuradaControlStation st = new HepsiBuradaControlStation(plateauOne, firstRover);
            Assert.AreEqual(st.Control(), "Error While Processing Control");
        }

        [TestMethod]
        public void InstructionLeftCalculatedCorrectly()
        {
            Plateau plateauOne = new Plateau(new Coordinates(5, 5));
            Rover firstRover = new Rover(new Coordinates(1, 2), Direction.North, new List<Instruction> { Instruction.Left});
            firstRover.Move(plateauOne);
            Assert.AreNotEqual(firstRover.Direction, Direction.East);
        }

        [TestMethod]
        public void InstructionRightCalculatedCorrectly()
        {
            Plateau plateauOne = new Plateau(new Coordinates(5, 5));
            Rover firstRover = new Rover(new Coordinates(1, 2), Direction.North, new List<Instruction> { Instruction.Right });
            firstRover.Move(plateauOne);
            Assert.AreNotEqual(firstRover.Direction, Direction.West);
        }
    }
}
