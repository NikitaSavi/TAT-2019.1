using System;

namespace DEV_5
{
    class Plane : IFlyable
    {
        public readonly int Speed = 200; // km/h
        public Point CurrentPoint { get; set; }
        public int FlyTime { get; set; }
        public event ObjectFlies ObjectFlewAway;

        public Plane(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
        }

        public void FlyTo(Point newPoint)
        {
            ObjectFlewAway?.Invoke(WhoAmI(), CurrentPoint.GetDistanceToPoint(newPoint));
            CurrentPoint = newPoint;
        }

        public double GetFlyTime(double distance)
        {
            var finalSpeed = Speed + (int) distance; //speed goes +10kmh for every 10 km : 10[km/h] * (int) (distance / 10[km])
            return 2 * distance / (finalSpeed + Speed);
        }

        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}