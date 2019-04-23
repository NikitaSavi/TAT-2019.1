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
            Console.WriteLine(
                "Input a chain of commands in the following format:\n<action> <vehicle_type>"
                + "\nActions:\n  1) count_types\n  2) count_all\n  3) average_price truck\n  4) average_price truck <brand>"
                + "\nVehicle types:\n  1) car\n  2) truck"
                + "\nFinish with <execute> command.\n");

            while (true)
            {
                var command = Console.ReadLine().ToLower();
                if (command == string.Empty)
                {
                    continue;
                }

                if (command == "execute")
                {
                    break;
                }

                var commandKeyWords = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                const int CommandActionKeyIndex = 0;
                const int CommandVehicleKeyIndex = 1;
                const int CommandBrandKeyStartIndex = 2;
                const int MinimumAmountOfArgs = 2;
                var commandActionKey = commandKeyWords[CommandActionKeyIndex];
                
                if (commandKeyWords.Length < MinimumAmountOfArgs)
                {
                    Console.WriteLine("A command must contain at least two arguments: type of command, type of vehicle, (optional for average_price) brand of vehicle");
                    continue;
                }

                // Determine the type of vehicle to process
                var commandVehicleKey = commandKeyWords[CommandVehicleKeyIndex];
                List<VehicleInfoStruct> listToProcess;
                switch (commandVehicleKey)
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
                switch (commandActionKey)
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
                            var commandBrandKey = commandKeyWords.Length > MinimumAmountOfArgs + 1
                                                   ? string.Join(" ", commandKeyWords, CommandBrandKeyStartIndex, commandKeyWords.Length - MinimumAmountOfArgs)
                                                   : commandKeyWords[CommandBrandKeyStartIndex];

                            // Check if the brand exists in the database 
                            if (listToProcess.Any(vehicle => vehicle.Brand == commandBrandKey))
                            {
                                commandsQueue.Add(
                                    new CommandCountAveragePriceOfBrand(
                                        new CounterAveragePriceOfBrand(),
                                        listToProcess, commandBrandKey));
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