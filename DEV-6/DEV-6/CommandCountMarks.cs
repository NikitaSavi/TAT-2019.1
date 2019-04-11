﻿using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// The command to count marks.
    /// </summary>
    public class CommandCountMarks : ICommand
    {
        /// <summary>
        /// The receiver.
        /// </summary>
        private CounterMarks counter;

        /// <summary>
        /// The list of vehicles with their info.
        /// </summary>
        private List<VehicleInfoStruct> listOfVehicles;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandCountMarks"/> class.
        /// </summary>
        /// <param name="receiver">
        /// The receiver.
        /// </param>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        public CommandCountMarks(CounterMarks receiver, List<VehicleInfoStruct> listOfVehicles)
        {
            this.counter = receiver;
            this.listOfVehicles = listOfVehicles;
        }

        /// <inheritdoc />
        public double Execute() => this.counter.CountMarks(this.listOfVehicles);
    }
}