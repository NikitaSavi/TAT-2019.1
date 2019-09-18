using System;

namespace DEV_5
{
    /// <summary>
    /// Contains a method for displaying flight time
    /// </summary>
    public class FlightTimeLog
    {
        /// <summary>
        /// The seconds to hours convertion.
        /// </summary>
        private static int secondsToHoursConvertTime = 3600;

        /// <summary>
        /// Subscriber to the ObjectFlewAway Event. Receives and displays time of the flight
        /// </summary>
        /// <param name="obj">Object that flew to a new point</param>
        /// <param name="args">Argument received from the event:
        /// Time - time of the flight
        /// Speed - (final, in case of a plane) speed of the flight
        /// </param>
        public static void GetFlyTime(object obj, ObjectFlewAwayEventArgs args)
        {
            if (obj is IFlyable)
            {
                Console.Write($"{obj.GetType().Name}'s time is ");
                Console.WriteLine(
                    obj is SpaceShip
                        ? $"{Math.Round(args.Time * secondsToHoursConvertTime, 3)} seconds, reaching {args.Speed / secondsToHoursConvertTime} km/s"
                        : $"{Math.Round(args.Time, 3)} hours, reaching {args.Speed} km/h");
            }
            else
            {
                throw new Exception("oh no");
            }
        }
    }
}