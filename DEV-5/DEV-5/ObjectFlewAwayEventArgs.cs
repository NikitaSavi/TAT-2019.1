using System;

namespace DEV_5
{
    /// <inheritdoc />
    ///  <summary>
    ///  Class contains arguments for the ObjectFlewAway event: time and speed
    ///  </summary>
    public class ObjectFlewAwayEventArgs : EventArgs
    {
        public double Time { get; set; }
        public double Speed { get; set; }

        /// <inheritdoc />
        /// <param name="time">Time of the flight</param>
        /// <param name="speed">Speed of the flight</param>
        public ObjectFlewAwayEventArgs(double time, int speed)
        {
            Time = time;
            Speed = speed;
        }
    }
}
