namespace DEV_5
{
    /// <summary>
    /// Delegate for calling methods when an object flies to a new point
    /// </summary>
    /// <param name="obj">Object that flew to a new point</param>
    /// <param name="time">Time of the flight</param>
    public delegate void ObjectChangesLocation(IFlyable obj, double time);

    /// <summary>
    /// Interface for objects that can fly
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// Event that notifies it's subscribers that an object changed it's location
        /// </summary>
        event ObjectChangesLocation ObjectFlewAway;

        /// <summary>
        /// Changes current coordinates of the object
        /// </summary>
        /// <param name="newPoint">New point to fly to</param>
        void FlyTo(Point newPoint);

        /// <summary>
        /// Calculates time that took the object to fly
        /// </summary>
        /// <returns>Time of the flight</returns>
        double GetFlyTime(); //TODO parameters in reqs were not specified. Deliberately? Is it allowed to send distance as a parameter?

        /// <summary>
        /// Returns a reference to the current object
        /// </summary>
        /// <returns>Reference to the current object</returns>
        IFlyable WhoAmI();
    }
}