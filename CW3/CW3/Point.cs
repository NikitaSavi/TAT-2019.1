using System;

namespace CW3
{
    /// <summary>
    /// 2D point
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
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
            this.X = x;
            this.Y = y;
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
        public double GetDistance(Point anotherPoint) =>
            Math.Sqrt(Math.Pow(this.X - anotherPoint.X, 2) + Math.Pow(this.Y - anotherPoint.Y, 2));
    }
}