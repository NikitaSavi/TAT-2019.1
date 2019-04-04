using System;

namespace CW3
{
    /// <summary>
    /// The right triangle builder.
    /// </summary>
    public class RightTriangleBuilder : Builder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RightTriangleBuilder"/> class.
        /// </summary>
        /// <param name="successor">
        /// The successor for chain of responsibility
        /// </param>
        public RightTriangleBuilder(Builder successor = null) : base(successor)
        {
        }

        /// <inheritdoc />
        public override Triangle Build(Point a, Point b, Point c)
        {
            // While vectors are not exactly "points", they can be identified by coordinates just like points
            //TODO Fix math here
            var vectorAB = new Point(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));
            var vectorBC = new Point(Math.Abs(b.X - c.X), Math.Abs(b.Y - c.Y));
            var vectorAC = new Point(Math.Abs(a.X - c.X), Math.Abs(a.Y - c.Y));
            if (Math.Abs(vectorAB.X * vectorBC.X + vectorAB.Y * vectorBC.Y) < Tolerance ||
                Math.Abs(vectorAB.X * vectorAC.X + vectorAB.Y * vectorAC.Y) < Tolerance ||
                Math.Abs(vectorAC.X * vectorBC.X + vectorAC.Y * vectorBC.Y) < Tolerance) 
            {
                return new RightTriangle(a, b, c);
            }

            return Successor?.Build(a, b, c);
        }
    }
}