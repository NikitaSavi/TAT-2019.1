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
                var commandKeyWords = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                const int commandTypeIndex = 0;
                const int commandVehicleIndex = 1;
                const int commandBrandStartIndex = 2;
                const int minimumAmountOfArgs = 2;
                var commandType = commandKeyWords[commandTypeIndex];

                if (commandType == "execute")
                {
                    break;
                }

                if (commandKeyWords.Length < minimumAmountOfArgs)
                {
                    Console.WriteLine(
                        "A command must contain at least two arguments: type of command, type of vehicle, (optional for average_price) brand of vehicle");
                    continue;
                }

                // Determine the type of vehicle to process
                var commandVehicle = commandKeyWords[commandVehicleIndex];
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
                        if (commandKeyWords.Length > minimumAmountOfArgs)
                        {
                            // Create a joined string in case of brand having multiple words
                            var commandBrand = commandKeyWords.Length > minimumAmountOfArgs + 1
                                ? string.Join(" ", commandKeyWords, commandBrandStartIndex, commandKeyWords.Length-minimumAmountOfArgs)
                                : commandKeyWords[commandBrandStartIndex];
                            Console.Write(commandBrand);
                            Console.Write(commandBrand);
                            Console.WriteLine(commandBrand);
                            //Check if the brand exists in the database 
                            if (listToProcess.Any(vehicle => vehicle.Brand == commandBrand))
                            {
                                commandsQueue.Add(new CommandCountAveragePriceOfBrand(new CounterAveragePriceOfBrand(),
                                    listToProcess, commandBrand));
                            }
                            else
                            {
                                Console.WriteLine("Unknown brand");
                            }
                        }

                        // If no brand is entered, run the usual command
                        else
                        {
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