using System;

namespace DEV_5
{
    /// <summary>
    /// Struct for a 3D point
    /// </summary>
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

        /// <summary>
        /// Calculates distance between this point and another
        /// </summary>
        /// <param name="anotherPoint">Another point to get distance to</param>
        /// <returns>Distance between points</returns>
        public double GetDistanceToPoint(Point anotherPoint) =>
            Math.Sqrt(Math.Pow(anotherPoint.CoordinateX - CoordinateX, 2) +
                      Math.Pow(anotherPoint.CoordinateY - CoordinateY, 2) +
                      Math.Pow(anotherPoint.CoordinateZ - CoordinateZ, 2));
    }
}