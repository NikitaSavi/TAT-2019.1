using System;

namespace DEV_5
{
    /// <summary>
    /// Object Bird - random speed up to 20 km/h
    /// </summary>
    public class Bird : IFlyable
    {
        public int Speed = new Random().Next(1, 20); // km/h
        public Point CurrentPoint { get; set; }
        public double Mileage { get; set; }

        /// <inheritdoc />
        public event EventHandler<ObjectFlewAwayEventArgs> ObjectFlewAway;

        /// <summary>
        /// Constructor for the class, initializes starting position
        /// </summary>
        /// <param name="x">Starting X coordinate</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="z">Starting Z coordinate</param>
        public Bird(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
        }

        /// <inheritdoc />
        public void FlyTo(Point newPoint)
        {
            Mileage += CurrentPoint.GetDistanceToPoint(newPoint);
            ObjectFlewAway?.Invoke(WhoAmI(), new ObjectFlewAwayEventArgs(GetFlyTime(), Speed));
            CurrentPoint = newPoint;
        }

        /// <inheritdoc />
        public double GetFlyTime()
        {
            return Mileage / Speed;
        }

        /// <inheritdoc />
        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}