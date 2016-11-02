using MarsRover.Core;
using NUnit.Framework;
using Rover.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Test
{
    [TestFixture]
    public class MarsRoverTests
    {
        private RoverCommand command;

        [SetUp]
        public void Setup()
        {
            command=new RoverCommand();
        }

        [TestCase(1, 1, 2, 2, "L")]
        public void When_Start_Point_Out_Of_Range_Then_Throw_An_Exception(int rangeX, int rangeY, int pointX, int pointY,
            string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            Assert.Throws<Exception>(() => command.Execute(range, point, RoverDirection.North, movementList));

        }

        [TestCase(5, 5, 1, 2, "B")]
        [Test]
        public void When_Rover_Input_Is_Not_Correct_Then_Throw_Exception(int rangeX, int rangeY, int pointX, int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);

            Assert.Throws<Exception>(() => command.Execute(range, point, RoverDirection.North, movementList));
        }



        [TestCase(5, 5, 1, 2, "L M")]
        [Test]
        public void When_Roven_Inputs_Include_Empty_Space_Then_Throw_An_Exception(int rangeX, int rangeY, int pointX, int pointY, string movementList)
        {
            Range range = new Range(rangeX, rangeY);
            Point point = new Point(pointX, pointY);            
            Assert.Throws<Exception>(() => command.Execute(range, point, RoverDirection.North, movementList));
        }

    }
}
