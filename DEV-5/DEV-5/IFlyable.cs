using System;

namespace DEV_5
{
    public delegate void ObjectFlies(IFlyable obj, double distance);

    public interface IFlyable
    {
        event ObjectFlies ObjectFlewAway;
        void FlyTo(Point newPoint);
        double GetFlyTime(double distance); //TODO parameters in reqs were not specified. Deliberately?
        IFlyable WhoAmI();
    }
}