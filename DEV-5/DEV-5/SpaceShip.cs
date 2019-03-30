﻿namespace DEV_5
{
    /// <summary>
    /// Object SpaceShip - speed 8000 km/s
    /// </summary>
    public class SpaceShip : IFlyable
    {
        public const int Speed = 8000 * 3600; // 8000 km/s in km/h
        public Point CurrentPoint { get; set; }
        public double Mileage { get; set; }
        public event ObjectChangesLocation ObjectFlewAway;

        /// <summary>
        /// Constructor for the class, initializes starting position
        /// </summary>
        /// <param name="x">Starting X coordinate</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="z">Starting Z coordinate</param>
        public SpaceShip(int x = 0, int y = 0, int z = 0)
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
            return Mileage / Speed;
        }

        /// <inheritdoc />
        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}