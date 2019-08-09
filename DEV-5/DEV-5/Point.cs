using System;

namespace DEV_5
{
    /// <summary>
    /// Struct for a 3D point
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// Gets or sets the coordinate x.
        /// </summary>
        public int CoordinateX { get; set; }

        /// <summary>
        /// Gets or sets the coordinate y.
        /// </summary>
        public int CoordinateY { get; set; }

        /// <summary>
        /// Gets or sets the coordinate z.
        /// </summary>
        public int CoordinateZ { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        /// <param name="z">
        /// The z.
        /// </param>
        public Point(int x, int y, int z)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
            this.CoordinateZ = z;
        }

        /// <summary>
        /// Calculates distance between this point and another
        /// </summary>
        /// <param name="anotherPoint">Another point to get distance to</param>
        /// <returns>Distance between points</returns>
        public double GetDistanceToPoint(Point anotherPoint) =>
            Math.Sqrt(Math.Pow(anotherPoint.CoordinateX - this.CoordinateX, 2) +
                      Math.Pow(anotherPoint.CoordinateY - this.CoordinateY, 2) +
                      Math.Pow(anotherPoint.CoordinateZ - this.CoordinateZ, 2));
    }
}