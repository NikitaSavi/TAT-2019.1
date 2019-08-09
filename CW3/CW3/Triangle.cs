namespace CW3
{
    /// <summary>
    /// Abstract class for triangles
    /// </summary>
    public abstract class Triangle
    {
        /// <summary>
        /// Gets or sets the A point.
        /// </summary>
        public Point A { get; set; }

        /// <summary>
        /// Gets or sets the B point.
        /// </summary>
        public Point B { get; set; }

        /// <summary>
        /// Gets or sets the C point.
        /// </summary>
        public Point C { get; set; }

        /// <summary>
        /// The length of AB line
        /// </summary>
        public double LengthAB => this.A.GetDistance(B);

        /// <summary>
        /// The length of BC line
        /// </summary>
        public double LengthBC => B.GetDistance(C);

        /// <summary>
        /// The length of AC line
        /// </summary>
        public double LengthAC => A.GetDistance(C);

        /// <summary>
        /// The perimeter
        /// </summary>
        public double Perimeter => this.LengthAB + this.LengthBC + this.LengthAC;

        /// <summary>
        /// Tolerance for float numbers comparison
        /// </summary>
        public const double Tolerance = 1E-6;

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="a">
        /// Point a
        /// </param>
        /// <param name="b">
        /// Point b
        /// </param>
        /// <param name="c">
        /// Point c
        /// </param>
        protected Triangle(Point a, Point b, Point c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
        }

        /// <summary>
        /// Get square of the triangle
        /// </summary>
        /// <returns>
        /// Square of the triangle
        /// </returns>
        public abstract double GetSquare();
    }
}