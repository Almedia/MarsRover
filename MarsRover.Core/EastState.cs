using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
   public class EastState : IState
    {
        public void MoveForward(RoverPosition position)
        {
            position.CurrentPosition.X++;
        }

        public void TurnLeft(RoverPosition position)
        {
            position.RoverDirection = RoverDirection.North;
        }

        public void TurnRight(RoverPosition position)
        {
            position.RoverDirection = RoverDirection.South;
        }
    }

}
