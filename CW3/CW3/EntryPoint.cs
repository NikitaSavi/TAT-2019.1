using System;

namespace CW3
{
    /// <summary>
    /// CW3: Create a triangle by 3 point, get it's square
    /// </summary>
    internal static class EntryPoint
    {
        /// <summary>
        /// The entry point
        /// </summary>
        /// <returns>
        /// Operation codes: 0 - OK; 1 - Error.
        /// </returns>
        private static int Main()
        {
            try
            {
                Builder mainBuilder =
                    new RightTriangleBuilder(new EquilateralTriangleBuilder(new NormalTriangleBuilder()));

                // right
                var triangleA = mainBuilder.Build(new Point(), new Point(0, 10), new Point(10, 10));

                // equilateral
                var triangleB = mainBuilder.Build(new Point(-3), new Point(3), new Point(0, 3 * Math.Sqrt(3)));

                // any
                var triangleC = mainBuilder.Build(new Point(), new Point(0, 17), new Point(5, 6));

                // wrong
                var triangleD = mainBuilder.Build(new Point(0, 23), new Point(0, 34), new Point(0, 1));

                Console.WriteLine(triangleA.GetSquare());
                Console.WriteLine(triangleB.GetSquare());
                Console.WriteLine(triangleC.GetSquare());
                Console.WriteLine(triangleD.GetSquare());

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}