using System;

namespace DEV_5
{
    /// <summary>
    /// Object SpaceShip - speed 8000 km/s
    /// </summary>
    public class SpaceShip : IFlyable
    {
        /// <summary>
        /// The speed.
        /// </summary>
        public const int Speed = 8000 * 3600; // 8000 km/s in km/h

        /// <summary>
        /// Gets or sets the current point.
        /// </summary>
        public Point CurrentPoint { get; set; }

        /// <summary>
        /// Gets or sets the mileage.
        /// </summary>
        public double Mileage { get; set; }

        /// <inheritdoc />
        public event EventHandler<ObjectFlewAwayEventArgs> ObjectFlewAway;

        /// <summary>
        /// Constructor for the class, initializes starting position
        /// </summary>
        /// <param name="x">Starting X coordinate</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="z">Starting Z coordinate</param>
        public SpaceShip(int x = 0, int y = 0, int z = 0)
        {
            this.CurrentPoint = new Point(x, y, z);
        }

        /// <inheritdoc />
        public void FlyTo(Point newPoint)
        {
            this.Mileage += this.CurrentPoint.GetDistanceToPoint(newPoint);
            this.ObjectFlewAway?.Invoke(this, new ObjectFlewAwayEventArgs(this.GetFlyTime(), Speed));
            this.CurrentPoint = newPoint;
        }

        /// <inheritdoc />
        public double GetFlyTime()
        {
            return this.Mileage / Speed;
        }
    }
}