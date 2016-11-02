using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public class Range
    {
        public Range(int x, int y)
        {
            this.minX = 0;
            this.minY = 0;
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int minX { get; set; }

        public int minY { get; set; }
    }
}

