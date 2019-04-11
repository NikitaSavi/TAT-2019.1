using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{
    /// <summary>
    /// The commands invoker.
    /// </summary>
    public static class CommandsInvoker
    {
        /// <summary>
        /// Invokes the commands, based on user's input.
        /// </summary>
        /// <param name="carsDocName">
        /// Name of XML doc with cars information.
        /// </param>
        /// <param name="trucksDocName">
        /// Name of XML doc with trucks information.
        /// </param>
        public static void InvokeCommands(string carsDocName, string trucksDocName)
        {
            var commandsQueue = new List<ICommand>();
            Console.WriteLine("Input a chain of commands, then enter \"execute\"");
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "execute")
                {
                    break;
                }

                if (command.Split(' ').Length < 2)
                {
                    Console.WriteLine(
                        "A command must contain at least two arguments: type of command, type of vehicle, (optional for average_price) mark of vehicle");
                    continue;
                }

                List<VehicleInfoStruct> listToProcess;
                switch (command.Split(' ')[1])
                {
                    case "car":
                        listToProcess = DatabaseCars.GetDatabaseCars(carsDocName).ListOfCars;
                        break;

                    case "truck":
                        listToProcess = DatabaseTrucks.GetDatabaseTrucks(trucksDocName).ListOfTrucks;
                        break;

                    default:
                        Console.WriteLine("Unknown vehicle type");
                        continue;
                }

                switch (command.Split(' ')[0])
                {
                    case "count_types":
                        commandsQueue.Add(new CommandCountMarks(new CounterMarks(), listToProcess));
                        break;

                    case "count_all":
                        commandsQueue.Add(new CommandCountAllVehicles(new CounterAllVehicles(), listToProcess));
                        break;

                    case "average_price":
                        commandsQueue.Add(new CommandCountAveragePrice(new CounterAveragePrice(), listToProcess));
                        break;

                    default:
                        if (command.Contains("average_price") && command.Split(' ').Length > 2)
                        {
                            if (listToProcess.Any(vehicle => vehicle.Mark == command.Split(' ')[2]))
                            {
                                commandsQueue.Add(new CommandCountAveragePriceOfMark(new CounterAveragePriceOfMark(), listToProcess, command.Split(' ')[2]));
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unknown command");
                        }

                        break;
                }
            }

            foreach (var command in commandsQueue)
            {
                Console.WriteLine(command.Execute());
            }
        }
    }
}