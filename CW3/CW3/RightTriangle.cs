using System;

namespace CW3
{
    /// <summary>
    /// The right triangle.
    /// </summary>
    public class RightTriangle : Triangle
    {
        /// <inheritdoc />
        public RightTriangle(Point a, Point b, Point c)
            : base(a, b, c)
        {
        }

        /// <inheritdoc />
        public override double GetSquare() =>
            0.5 * this.LengthAB * this.LengthAC * this.LengthBC / Math.Max(
                this.LengthAB,
                Math.Max(this.LengthAC, this.LengthBC));
    }
}