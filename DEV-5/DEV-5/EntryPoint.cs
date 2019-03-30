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
        /// Subscriber to the ObjectFlewAway Event. Receives and displays time of the flight
        /// </summary>
        /// <param name="obj">Object that flew to a new point</param>
        /// <param name="args">Argument received from the event:
        /// Time - time of the flight
        /// Speed - (final, in case of a plane) speed of the flight
        /// </param>
        private static void GetFlyTime(object obj, ObjectFlewAwayEventArgs args)
        {
            Console.Write($"{obj.GetType().Name}'s time is ");
            Console.WriteLine(obj is SpaceShip
                ? $"{Math.Round(args.Time * 3600, 3)} seconds, reaching {args.Speed / 3600} km/s"
                : $"{Math.Round(args.Time, 3)} hours, reaching {args.Speed} km/h");
        }
    }
}