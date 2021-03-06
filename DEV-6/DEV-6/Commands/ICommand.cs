﻿namespace DEV_6.Commands
{
    /// <summary>
    /// The Command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <returns>
        /// The necessary amount.
        /// </returns>
        double Execute();
    }
}