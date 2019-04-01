using System;
using System.Collections.Generic;

namespace DEV_5
{
    /// <summary>
    /// DEV-5: Calculate flight time of different objects
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// </summary>
        /// <returns>
        /// Error codes:
        /// 0 - OK
        /// 1 - Error
        /// </returns>
        static int Main(string[] args)
        {
            try
            {
                var flyables = new List<IFlyable> {new Bird(), new Plane(), new SpaceShip()};
                foreach (var flyable in flyables)
                {
                    //Subscribe to the event - object changes coordinates -> get time of the flight
                    flyable.ObjectFlewAway += FlightTimeLog.GetFlyTime;
                    flyable.FlyTo(new Point(100, 200, 800));
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}