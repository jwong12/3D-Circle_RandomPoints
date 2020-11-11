using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomPoints
{
    class RandomPoint
    {
        const float RADIUS = 2;
        static Random random = new Random(); // uses current time as its seed value
        public Point currPoint = new Point();
        public Point prevPoint = new Point();
        public float distance;
        public DateTime date;

        /* 
            Get the last random point as the function argument and save the previous X,Y,Z coordinates in the prevPoint object.
            Calculate the new X,Y,Z coordinates using random inclination and azimuth degrees, and save them in the currPoint object.
            Calculate the distance between the current and previous points and save it in the distance field.
         */
        public void GetNextRandomPoint(Point lastPointInList)
        {
            date = DateTime.Now;
            prevPoint.X = lastPointInList.X;
            prevPoint.Y = lastPointInList.Y;
            prevPoint.Z = lastPointInList.Z;
            int inclination = random.Next(360);
            int azimuth= random.Next(360);

            currPoint.X = (float)(prevPoint.X + RADIUS * Math.Sin(azimuth) * Math.Cos(inclination));
            currPoint.Y = (float)(prevPoint.Y + RADIUS * Math.Sin(azimuth) * Math.Sin(inclination));
            currPoint.Z = (float)(prevPoint.Z + RADIUS * Math.Cos(azimuth));
            distance = (float)(Math.Sqrt((prevPoint.X - currPoint.X) * (prevPoint.X - currPoint.X) + (prevPoint.Y - currPoint.Y) * (prevPoint.Y - currPoint.Y) + (prevPoint.Z - currPoint.Z) * (prevPoint.Z - currPoint.Z)));
        }

        public string GetLogInfo()
        {
            return String.Format("currPoint: ({0}, {1}, {2}), prevPoint: ({3}, {4}, {5}), distance: {6}, date: {7}\n",
                                        currPoint.X,
                                        currPoint.Y,
                                        currPoint.Z,
                                        prevPoint.X,
                                        prevPoint.Y,
                                        prevPoint.Z,
                                        distance,
                                        date);
        }
    }    
}
