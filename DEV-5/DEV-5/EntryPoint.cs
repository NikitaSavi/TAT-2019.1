using System;
using System.Collections.Generic;

namespace DEV_5
{
    class EntryPoint
    {
        static int Main(string[] args)
        {
            try
            {
                var flyables = new List<IFlyable>() {new Bird(), new Plane(), new SpaceShip()};
                foreach (var flyable in flyables)
                {
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
        //TODO too many decimals
        private static void GetFlyTime(IFlyable obj, double distance)
        {
            var time = obj.GetFlyTime(distance);
            Console.Write($"{obj.GetType().Name}'s time is ");
            Console.WriteLine(obj is SpaceShip ? $"{time} seconds" : $"{time} hours");
        }
    }
}

