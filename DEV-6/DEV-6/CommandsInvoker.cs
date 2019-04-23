using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
        /// <param name="carsXDoc">
        /// XML doc with cars information.
        /// </param>
        /// <param name="trucksXDoc">
        /// XML doc with trucks information.
        /// </param>
        public static void InvokeCommands(XDocument carsXDoc, XDocument trucksXDoc)
        {
            var commandsQueue = new List<ICommand>();
            Console.WriteLine("Input a chain of commands, then enter \"execute\"");

            while (true)
            {
                var commandKeyWords = Console.ReadLine().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                const int CommandTypeIndex = 0;
                const int CommandVehicleIndex = 1;
                const int CommandBrandStartIndex = 2;
                const int MinimumAmountOfArgs = 2;
                var commandType = commandKeyWords[CommandTypeIndex];

                if (commandType == "execute")
                {
                    break;
                }

                if (commandKeyWords.Length < MinimumAmountOfArgs)
                {
                    Console.WriteLine(
                        "A command must contain at least two arguments: type of command, type of vehicle, (optional for average_price) brand of vehicle");
                    continue;
                }

                // Determine the type of vehicle to process
                var commandVehicle = commandKeyWords[CommandVehicleIndex];
                List<VehicleInfoStruct> listToProcess;
                switch (commandVehicle)
                {
                    case "car":
                        listToProcess = DatabaseCars.GetDatabaseCars(carsXDoc).ListOfCars;
                        break;
                    case "truck":
                        listToProcess = DatabaseTrucks.GetDatabaseTrucks(trucksXDoc).ListOfTrucks;
                        break;
                    default:
                        Console.WriteLine("Unknown vehicle type");
                        continue;
                }

                // Determine the action to perform
                switch (commandType)
                {
                    case "count_types":
                        commandsQueue.Add(new CommandCountBrands(new CounterBrands(), listToProcess));
                        break;
                    case "count_all":
                        commandsQueue.Add(new CommandCountAllVehicles(new CounterAllVehicles(), listToProcess));
                        break;
                    case "average_price":

                        // If a brand is entered, run the necessary command
                        if (commandKeyWords.Length > MinimumAmountOfArgs)
                        {
                            // Create a joined string in case of brand having multiple words
                            var commandBrand = commandKeyWords.Length > MinimumAmountOfArgs + 1
                                                   ? string.Join(" ", commandKeyWords, CommandBrandStartIndex, commandKeyWords.Length - MinimumAmountOfArgs)
                                                   : commandKeyWords[CommandBrandStartIndex];

                            // Check if the brand exists in the database 
                            if (listToProcess.Any(vehicle => vehicle.Brand == commandBrand))
                            {
                                commandsQueue.Add(
                                    new CommandCountAveragePriceOfBrand(
                                        new CounterAveragePriceOfBrand(),
                                        listToProcess,
                                        commandBrand));
                            }
                            else
                            {
                                Console.WriteLine("Unknown brand");
                            }
                        }
                        else
                        {
                            // If no brand is entered, run the usual command
                            commandsQueue.Add(new CommandCountAveragePrice(new CounterAveragePrice(), listToProcess));
                        }

                        break;

                    default:
                        Console.WriteLine("Unknown command");
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