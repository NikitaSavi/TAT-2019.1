using System;

namespace DEV_5
{
    public struct Point
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int CoordinateZ { get; set; }

        public Point(int x, int y, int z)
        {
            CoordinateX = x;
            CoordinateY = y;
            CoordinateZ = z;
        }

        public double GetDistanceToPoint(Point anotherPoint)
        {
            return Math.Sqrt(Math.Pow((anotherPoint.CoordinateX - CoordinateX), 2) +
                             Math.Pow((anotherPoint.CoordinateY - CoordinateY), 2) +
                             Math.Pow((anotherPoint.CoordinateZ - CoordinateZ), 2));
        }
    }
}