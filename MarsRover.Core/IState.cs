using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public interface IState
    {
        void TurnLeft(RoverPosition position);

        void TurnRight(RoverPosition position);

        void MoveForward(RoverPosition position);
    }
}

