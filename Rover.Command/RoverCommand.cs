﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Core;

namespace Rover.Command
{
    public class RoverCommand
    {
        private readonly Dictionary<string, IState> ravorState;

        public RoverCommand()
        {
            ravorState = new Dictionary<string, IState>();
            ravorState.Add(RoverDirection.North, new NorthState());
            ravorState.Add(RoverDirection.East, new EastState());
            ravorState.Add(RoverDirection.South, new SouthState());
            ravorState.Add(RoverDirection.West, new WestState());
        }

        public MarsRoverModel Execute(Range range, Point startPoint, string direction, string movementList)
        {

            var rover = MarsRoverModel.New(range, startPoint, direction, movementList);
            var roverPosition = new RoverPosition()
            {
                CurrentPosition = new Point(startPoint.X,startPoint.Y),
                RoverDirection = direction
            };
            try
            {
                if (rover.RoverMovements.Count > 0)
                {
                    foreach (var movement in rover.RoverMovements)
                    {
                        Context context = new Context(ravorState[rover.CurrentDirection], roverPosition);
                        context.Execute(movement.ToString());
                        rover.ChangePosition(roverPosition);
                    }
                }
            }
            catch { };
            return rover;
        }
    }
}
