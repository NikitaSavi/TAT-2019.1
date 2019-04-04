using System;

namespace CW3
{
    /// <summary>
    /// 2D point
    /// </summary>
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">
        /// x coordinate
        /// </param>
        /// <param name="y">
        /// y coordinate
        /// </param>
        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets distance to another point
        /// </summary>
        /// <param name="anotherPoint">
        /// Another point
        /// </param>
        /// <returns>
        /// Distance to another point
        /// </returns>
        public double GetDistance(Point anotherPoint)
        {
            return Math.Sqrt(Math.Pow(X - anotherPoint.X, 2) + Math.Pow(Y - anotherPoint.Y, 2));
        }
    }
}