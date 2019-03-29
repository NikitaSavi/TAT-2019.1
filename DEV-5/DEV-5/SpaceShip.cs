using System;

namespace DEV_5
{
    public class SpaceShip : IFlyable
    {
        //TODO set all speed to the same units?
        public const int Speed = 8000; // 8000 km/s
        public Point CurrentPoint { get; set; }
        public event ObjectFlies ObjectFlewAway;

        public SpaceShip(int x = 0, int y = 0, int z = 0)
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
             return distance / Speed; //returns seconds
        }

        public IFlyable WhoAmI()
        {
            return this;
        }
    }
}