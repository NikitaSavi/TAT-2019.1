using System;

namespace CW3
{
    /// <summary>
    /// The right triangle.
    /// </summary>
    public class RightTriangle : Triangle
    {
        /// <inheritdoc />
        public RightTriangle(Point a, Point b, Point c) : base(a, b, c)
        {
        }

        /// <inheritdoc />
        public override double GetSquare()
        {
            return 0.5 * LengthAB * LengthAC * LengthBC / Math.Max(LengthAB, Math.Max(LengthAC, LengthBC));
        }
    }
}