using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public class MarsRoverModel
    {
        private Point range;

        private Point startPoint;

        private string currentDirection;

        private Point currentPosition;

        private List<char> roverMovements;

        public Point Range
        {
            get { return range; }
        }

        public Point StartPoint
        {
            get { return startPoint; }
        }

        public Point CurrentPosition
        {
            get { return currentPosition; }
        }

        public string CurrentDirection
        {
            get { return currentDirection; }
        }

        public List<char> RoverMovements
        {
            get { return roverMovements; }
        }

        public static MarsRoverModel New(Point range, Point startPoint, string currentDirection,string movements)
        {
            return new MarsRoverModel(range, startPoint, currentDirection,movements);
        }

        public MarsRoverModel(Point range, Point startPoint, string curretDirection,string movements)
        {
            if (!(range.X > startPoint.X))
                throw new Exception("StartPoint X must be in Range");
            if (!(range.Y > startPoint.Y))
                throw new Exception("StartPoint X must be in Range");

            if (movements.Any(x => Char.IsWhiteSpace(x)))
                throw new Exception("MovementList Include Empty Spaces");

            this.roverMovements=movements.ToCharArray().ToList();
            this.range = range;
            this.startPoint = startPoint;
            this.currentDirection = curretDirection;
            this.currentPosition = startPoint;
        }

        public void ChangePosition(RoverPosition position)
        {
            this.currentDirection = position.RoverDirection;
            this.currentPosition = position.CurrentPosition;
        }
    }
}
