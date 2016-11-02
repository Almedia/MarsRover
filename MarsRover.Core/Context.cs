using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public class Context
    {
        private IState state;
        private readonly Dictionary<string, Action> stateActions;

        public Context(IState state,RoverPosition position) {
            this.state = state;

            stateActions = new Dictionary<string, Action>();
            stateActions.Add(RoverAction.Left, () => state.TurnLeft(position));
            stateActions.Add(RoverAction.Right, () => state.TurnRight(position));
            stateActions.Add(RoverAction.MoveForward, () => state.MoveForward(position));
        }

        public void SetState(IState state)
        {
            this.state = state;

        }

        public void Execute(string movement) {
            try
            {
                this.stateActions[movement].Invoke();
            }
            catch (Exception ex)
            {
                    throw  new Exception("Action is not defined");
            }
            
        }
    }
}
