using System;

namespace DEV_5
{
    public class ObjectFlewAwayEventArgs : EventArgs
    {
        public double Time { get; set; }
        public double Speed { get; set; }

        public ObjectFlewAwayEventArgs(double time, int speed)
        {
            Time = time;
            Speed = speed;
        }
    }
}
