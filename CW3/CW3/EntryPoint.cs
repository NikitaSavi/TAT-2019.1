using System;

namespace CW3
{
    /// <summary>
    /// CW3: Create a triangle by 3 point, get it's square
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point
        /// </summary>
        /// <returns>
        /// Operation codes: 0 - OK; 1 - Error.
        /// </returns>
        static int Main()
        {
            try
            {
                Builder mainBuilder = new RightTriangleBuilder(new EquilateralTriangleBuilder(new NormalTriangleBuilder()));

                // right
                var triangleA = mainBuilder.Build(new Point(), new Point(0, 10), new Point(10, 10));

                // equilateral
                var triangleB = mainBuilder.Build(new Point(-3, 0), new Point(3, 0), new Point(0, 3 * Math.Sqrt(3)));

                // any
                var triangleC = mainBuilder.Build(new Point(), new Point(0, 17), new Point(5, 6));

                Console.WriteLine(triangleA.GetSquare());
                Console.WriteLine(triangleB.GetSquare());
                Console.WriteLine(triangleC.GetSquare());

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 1;
            }
        }
    }
}