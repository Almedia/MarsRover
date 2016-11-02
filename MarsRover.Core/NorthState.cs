using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public class NorthState : IState
    {
        public NorthState()
        {
        }

        public void MoveForward(RoverPosition position)
        {
            position.CurrentPosition.Y++;
        }

        public void TurnLeft(RoverPosition position)
        {
            position.RoverDirection = RoverDirection.West;
        }

        public void TurnRight(RoverPosition position)
        {
            position.RoverDirection = RoverDirection.East;
        }
    }
}
