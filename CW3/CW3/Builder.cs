namespace CW3
{
    /// <summary>
    /// Abstract class for builders
    /// </summary>
    public abstract class Builder
    {
        /// <summary>
        /// Tolerance for float numbers comparison
        /// </summary>
        public const double Tolerance = 0.000001;

        /// <summary>
        /// The successor for chain of responsibility
        /// </summary>
        public Builder Successor { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Builder"/> class.
        /// </summary>
        /// <param name="successor">
        /// The successor for chain of responsibility
        /// </param>
        protected Builder(Builder successor)
        {
            this.Successor = successor;
        }

        /// <summary>
        /// Determines type of a triangle and creates it by provided points
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
        /// <returns>
        /// The <see cref="Triangle"/>.
        /// </returns>
        public abstract Triangle Build(Point a, Point b, Point c);
    }
}