using System;

namespace DEV_5
{
    public class Bird : IFlyable
    {
        public int Speed; // km/h
        public Point CurrentPoint { get; set; }
        public event ObjectFlies ObjectFlewAway;

        /// <summary>
        /// Constructor for the class, initializes starting position
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Bird(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
        }

        /// <inheritdoc />
        public void FlyTo(Point newPoint)
        {
            Speed = new Random().Next(1, 20);
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