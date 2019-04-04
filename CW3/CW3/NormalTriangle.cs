using System;

namespace CW3
{
    /// <summary>
    /// Class for normal triangles
    /// </summary>
    public class NormalTriangle : Triangle
    {
        /// <inheritdoc />
        public NormalTriangle(Point a, Point b, Point c) : base(a, b, c)
        {
        }

        /// <inheritdoc />
        public override double GetSquare()
        {
            return Math.Sqrt(0.5 * Perimeter * (0.5 * Perimeter - LengthAB) * (0.5 * Perimeter - LengthAC) * (0.5 * Perimeter - LengthBC));
        }
    }
}