using System;

namespace CW3
{
    /// <summary>
    /// Class for normal triangles
    /// </summary>
    public class NormalTriangle : Triangle
    {
        /// <inheritdoc />
        public NormalTriangle(Point a, Point b, Point c)
            : base(a, b, c)
        {
        }

        /// <inheritdoc />
        public override double GetSquare() =>
            Math.Sqrt(
                0.5 * this.Perimeter * (0.5 * this.Perimeter - this.LengthAB) * (0.5 * this.Perimeter - this.LengthAC)
                * (0.5 * this.Perimeter - this.LengthBC));
    }
}