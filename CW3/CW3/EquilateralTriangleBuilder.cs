using System;

namespace CW3
{
    /// <summary>
    /// The equilateral triangle builder.
    /// </summary>
    public class EquilateralTriangleBuilder : Builder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EquilateralTriangleBuilder"/> class.
        /// </summary>
        /// <param name="successor">
        /// The successor for chain of responsibility
        /// </param>
        public EquilateralTriangleBuilder(Builder successor = null) : base(successor)
        {
        }

        /// <inheritdoc />
        public override Triangle Build(Point a, Point b, Point c)
        {
            if (Math.Abs(a.GetDistance(b) - b.GetDistance(c)) < Tolerance && Math.Abs(a.GetDistance(b) - a.GetDistance(c)) < Tolerance)
            {
                return new EquilateralTriangle(a, b, c);
            }

            return Successor?.Build(a, b, c);
        }
    }
}