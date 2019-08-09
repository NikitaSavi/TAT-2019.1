using System;

namespace DEV_5
{
    /// <summary>
    /// Object Plane - 200 km/h starting speed; +10km/h each 10 km of flight
    /// </summary>
    public class Plane : IFlyable
    {
        /// <summary>
        /// The starting speed.
        /// </summary>
        public const int StartingSpeed = 200; // km/h

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
        public Plane(int x = 0, int y = 0, int z = 0)
        {
            this.CurrentPoint = new Point(x, y, z);
        }

        /// <inheritdoc />
        public void FlyTo(Point newPoint)
        {
            this.Mileage += this.CurrentPoint.GetDistanceToPoint(newPoint);
            this.ObjectFlewAway?.Invoke(
                this.WhoAmI(),
                new ObjectFlewAwayEventArgs(this.GetFlyTime(), StartingSpeed + (int)this.Mileage));
            this.CurrentPoint = newPoint;
        }

        /// <inheritdoc />
        public double GetFlyTime()
        {
            // speed goes +10kmh for every 10 km : finalspeed = 10[km/h] * (int) (distance / 10[km])
            var finalSpeed = StartingSpeed + (int)this.Mileage;
            return 2 * this.Mileage / (finalSpeed + StartingSpeed);
        }

        /// <inheritdoc />
        public IFlyable WhoAmI() => this;
    }
}