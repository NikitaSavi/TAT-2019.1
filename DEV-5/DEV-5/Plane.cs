namespace DEV_5
{
    /// <summary>
    /// Object Plane - 200 km/h starting speed; +10km/h each 10 km of flight
    /// </summary>
    class Plane : IFlyable
    {
        public const int StartingSpeed = 200; // km/h
        public Point CurrentPoint { get; set; }
        public double Mileage { get; set; }
        public event ObjectChangesLocation ObjectFlewAway;

        /// <summary>
        /// Constructor for the class, initializes starting position
        /// </summary>
        /// <param name="x">Starting X coordinate</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="z">Starting Z coordinate</param>
        public Plane(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
        }

        /// <inheritdoc />
        public void FlyTo(Point newPoint)
        {
            Mileage += CurrentPoint.GetDistanceToPoint(newPoint);
            ObjectFlewAway?.Invoke(WhoAmI(), GetFlyTime());
            CurrentPoint = newPoint;
        }

        /// <inheritdoc />
        public double GetFlyTime()
        {
            //speed goes +10kmh for every 10 km : finalspeed = 10[km/h] * (int) (distance / 10[km])
            var finalSpeed = StartingSpeed + (int) Mileage;
            return 2 * Mileage / (finalSpeed + StartingSpeed);
        }

        /// <inheritdoc />
        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}