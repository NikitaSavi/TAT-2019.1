using System;

namespace CW3
{
    /// <summary>
    /// The equilateral triangle.
    /// </summary>
    public class EquilateralTriangle : Triangle
    {
        /// <inheritdoc />
        public EquilateralTriangle(Point a, Point b, Point c) : base(a, b, c)
        {
        }

        /// <inheritdoc />
        public override double GetSquare() => Math.Sqrt(3) * this.LengthAB * this.LengthAB / 4;
    }
}