namespace DEV_5
{
    public class SpaceShip : IFlyable
    {
        public const int Speed = 8000 * 3600; // 8000 km/s
        public Point CurrentPoint { get; set; }
        public event ObjectFlies ObjectFlewAway;

        /// <summary>
        /// Constructor for the class, initializes starting position
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public SpaceShip(int x = 0, int y = 0, int z = 0)
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
            return distance / Speed;
        }

        /// <inheritdoc />
        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}