namespace DEV_5
{
    /// <summary>
    /// Object Plane - 200 km/h starting speed; +10km/h each 10 km of flight
    /// </summary>
    class Plane : IFlyable
    {
        public readonly int Speed = 200; // km/h
        public Point CurrentPoint { get; set; }
        public event ObjectFlies ObjectFlewAway;

        /// <summary>
        /// Constructor for the class, initializes starting position
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Plane(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
        }

        /// <inheritdoc />
        public void FlyTo(Point newPoint)
        {
            ObjectFlewAway?.Invoke(WhoAmI(), CurrentPoint.GetDistanceToPoint(newPoint));
            CurrentPoint = newPoint;
        }

        /// <inheritdoc />
        public double GetFlyTime(double distance)
        {
            var finalSpeed =
                Speed + (int) distance; //speed goes +10kmh for every 10 km : 10[km/h] * (int) (distance / 10[km])
            return 2 * distance / (finalSpeed + Speed);
        }

        /// <inheritdoc />
        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}