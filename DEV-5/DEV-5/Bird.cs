using System;

namespace DEV_5
{
    public class Bird : IFlyable
    {
        public int Speed; // km/h
        public Point CurrentPoint { get; set; }
        public event ObjectFlies ObjectFlewAway;

        public Bird(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
        }


        public void FlyTo(Point newPoint)
        {
            Speed = new Random().Next(1, 20);
            ObjectFlewAway?.Invoke(WhoAmI(), CurrentPoint.GetDistanceToPoint(newPoint));
            CurrentPoint = newPoint;
        }

        public double GetFlyTime(double distance)
        {
            return distance / Speed;
        }

        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}