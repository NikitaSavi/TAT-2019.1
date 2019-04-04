﻿namespace CW3
{
    /// <summary>
    /// Abstract class for triangles
    /// </summary>
    public abstract class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public double LengthAB => A.GetDistance(B);
        public double LengthBC => B.GetDistance(C);
        public double LengthAC => A.GetDistance(C);
        public double Perimeter => LengthAB + LengthBC + LengthAC;

        /// <summary>
        /// Tolerance for float numbers comparison
        /// </summary>
        public const double Tolerance = 0.000001;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="a">
        /// Point a
        /// </param>
        /// <param name="b">
        /// Point b
        /// </param>
        /// <param name="c">
        /// Point c
        /// </param>
        protected Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Get square of the triangle
        /// </summary>
        /// <returns>
        /// Square of the triangle
        /// </returns>
        public abstract double GetSquare();
    }
}