using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Core;
using NUnit.Framework;
using Rover.Command;

namespace MarsRover.Test
{
    [TestFixture]
    public class RoverMovementTests
    {
        private RoverCommand command;
        [SetUp]
        public void Setup()
        {
            command = new RoverCommand();
        }

        [TestCase(5, 5, 1, 2, "L")]
        [Test]
        public void When_Rover_First_State_is_North_Then_After_Turn_Left_Must_Be_West(int rangeX, int rangeY, int pointX,
            int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            var rover = command.Execute(range, point, RoverDirection.North, movementList);
            Assert.AreEqual(rover.CurrentDirection, RoverDirection.West);
        }

        [TestCase(5, 5, 1, 2, "L")]
        [Test]
        public void When_Rover_First_State_is_South_Then_After_Turn_Left_Must_Be_East(int rangeX, int rangeY, int pointX,
           int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            var rover = command.Execute(range, point, RoverDirection.South, movementList);
            Assert.AreEqual(rover.CurrentDirection, RoverDirection.East);
        }

        [TestCase(5, 5, 1, 2, "L")]
        [Test]
        public void When_Rover_First_State_is_East_Then_After_Turn_Left_Must_Be_North(int rangeX, int rangeY, int pointX,
           int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            var rover = command.Execute(range, point, RoverDirection.East, movementList);
            Assert.AreEqual(rover.CurrentDirection, RoverDirection.North);
        }

        [TestCase(5, 5, 1, 2, "L")]
        [Test]
        public void When_Rover_First_State_is_West_Then_After_Turn_Lest_Must_Be_South(int rangeX, int rangeY, int pointX,
           int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            var rover = command.Execute(range, point, RoverDirection.West, movementList);
            Assert.AreEqual(rover.CurrentDirection, RoverDirection.South);
        }

        [TestCase(5, 5, 1, 2, "LMLMLMLMM")]
        [Test]
        public void When_Rover_MovementList_Given_Then_Execute_Rules_(int rangeX, int rangeY, int pointX, int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            var rover=command.Execute(range, point, RoverDirection.North, movementList);
            Assert.AreEqual(rover.CurrentDirection, RoverDirection.North);
            Assert.AreEqual(rover.CurrentPosition.X, 1);
            Assert.AreEqual(rover.CurrentPosition.Y, 3);
        }

        [TestCase(5, 5, 3, 3, "MMRMMRMRRM")]
        [Test]
        public void When_Rover_MovementList_Given_Then_Execute_Rules(int rangeX, int rangeY, int pointX, int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            var rover=command.Execute(range, point, RoverDirection.East, movementList);
            Assert.AreEqual(rover.CurrentDirection, RoverDirection.East);
            Assert.AreEqual(rover.CurrentPosition.X, 5);
            Assert.AreEqual(rover.CurrentPosition.Y, 1);
        }

        [TestCase(5, 5, 3, 3, "MMMMM")]
        [Test]
        public void When_Rover_MovementList_Given_Out_Of_Range_Then_Return_Last_Status(int rangeX, int rangeY, int pointX, int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            var rover = command.Execute(range, point, RoverDirection.North, movementList);
            Assert.AreEqual(rover.CurrentDirection, RoverDirection.North);
            Assert.AreEqual(rover.CurrentPosition.X, 3);
            Assert.AreEqual(rover.CurrentPosition.Y, 5);
        }
    }
}
