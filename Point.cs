using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RandomPoints
{
    class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Point(float currX = 0, float currY = 0, float currZ = 0)
        {
            X = currX;
            Y = currY;
            Z = currZ;
        }
    }
}
