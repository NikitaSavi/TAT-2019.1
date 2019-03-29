namespace DEV_5
{
    /// <summary>
    /// Delegate for calling methods for flight time calculate
    /// </summary>
    /// <param name="obj">Object that flew to a new point</param>
    /// <param name="distance">Distance traversed</param>
    public delegate void ObjectFlies(IFlyable obj, double distance);

    /// <summary>
    /// Interface for objects that can fly
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// Event that notifies it's subscribers that an object changed it's location
        /// </summary>
        event ObjectFlies ObjectFlewAway;

        /// <summary>
        /// Changes current coordinates of the object
        /// </summary>
        /// <param name="newPoint">New point to fly to</param>
        void FlyTo(Point newPoint);

        /// <summary>
        /// Calculates time that took the object to fly
        /// </summary>
        /// <param name="distance">Distance traversed</param>
        /// <returns>Time of the flight</returns>
        double GetFlyTime(double distance); //TODO parameters in reqs were not specified. Deliberately?

        /// <summary>
        /// Returns a reference to the current object
        /// </summary>
        /// <returns>Reference to the current object</returns>
        IFlyable WhoAmI();
    }
}