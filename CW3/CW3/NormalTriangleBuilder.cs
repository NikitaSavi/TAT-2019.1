using System;

namespace CW3
{
    /// <summary>
    /// The normal triangle builder.
    /// </summary>
    public class NormalTriangleBuilder : Builder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalTriangleBuilder"/> class.
        /// </summary>
        /// <param name="successor">
        /// The successor for chain of responsibility
        /// </param>
        public NormalTriangleBuilder(Builder successor = null) : base(successor)
        {
        }

        /// <inheritdoc />
        /// <exception cref="Exception">
        /// If a triangle cannot be made, an exception is thrown
        /// </exception>
        public override Triangle Build(Point a, Point b, Point c)
        {
            return (Math.Abs(a.X - b.X) < Tolerance && Math.Abs(b.X - c.X) < Tolerance)
                   || (Math.Abs(a.Y - b.Y) < Tolerance && Math.Abs(b.Y - c.Y) < Tolerance)
                       ? throw new ArgumentException("Not a triangle")
                       : new NormalTriangle(a, b, c);
        }
    }
}