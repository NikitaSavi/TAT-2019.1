using System;

namespace DEV_5
{
    /// <summary>
    /// Object Bird - random speed up to 20 km/h
    /// </summary>
    public class Bird : IFlyable
    {
        /// <summary>
        /// The min speed.
        /// </summary>
        public const int MinSpeed = 1;

        /// <summary>
        /// The max speed.
        /// </summary>
        public const int MaxSpeed = 20;

        /// <summary>
        /// The speed of the object.
        /// </summary>
        public int Speed { get; set; } // km/h

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
        public Bird(int x = 0, int y = 0, int z = 0)
        {
            this.Speed = new Random().Next(MinSpeed, MaxSpeed); // km/h
            this.CurrentPoint = new Point(x, y, z);
        }

        /// <inheritdoc />
        public void FlyTo(Point newPoint)
        {
            this.Mileage += this.CurrentPoint.GetDistanceToPoint(newPoint);
            this.ObjectFlewAway?.Invoke(this.WhoAmI(), new ObjectFlewAwayEventArgs(this.GetFlyTime(), this.Speed));
            this.CurrentPoint = newPoint;
        }

        /// <inheritdoc />
        public double GetFlyTime() => this.Mileage / this.Speed;

        /// <inheritdoc />
        public IFlyable WhoAmI() => this;
    }
}