using System;
using System.Collections.Generic;

namespace DEV_5
{
    /// <summary>
    /// DEV-5: Calculate time of flight of different objects
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
                var flyables = new List<IFlyable>() {new Bird(), new Plane(), new SpaceShip()};
                foreach (var flyable in flyables)
                {
                    //Subscribe to the event - object changes coordinates -> get distance and call GetFlyTime
                    flyable.ObjectFlewAway += GetFlyTime;
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

        /// <summary>
        /// Subscriber to the ObjectFlewAway Event. Calls GetFlyTime of an appropriate object and displays time of the flight
        /// </summary>
        /// <param name="obj">Object that flew to a new point</param>
        /// <param name="distance">Distance traversed</param>
        private static void GetFlyTime(IFlyable obj, double distance)
        {
            Console.Write($"{obj.GetType().Name}'s time is ");
            Console.WriteLine(obj is SpaceShip
                ? $"{Math.Round(obj.GetFlyTime(distance) * 3600, 3)} seconds"
                : $"{Math.Round(obj.GetFlyTime(distance), 3)} hours");
        }
    }
}