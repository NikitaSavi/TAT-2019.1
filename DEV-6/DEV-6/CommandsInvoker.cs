using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DEV_6.Commands;
using DEV_6.CommandsReceivers;
using DEV_6.Database;

namespace DEV_6
{
    /// <summary>
    /// The commands invoker.
    /// </summary>
    public class CommandsInvoker
    {
        /// <summary>
        /// XML doc with cars information.
        /// </summary>
        private XDocument CarsXDoc { get; set; }

        /// <summary>
        /// XML doc with trucks information.
        /// </summary>
        private XDocument TrucksXDoc { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandsInvoker"/> class.
        /// </summary>
        /// <param name="carsXDoc">
        /// The cars x doc.
        /// </param>
        /// <param name="trucksXDoc">
        /// The trucks x doc.
        /// </param>
        public CommandsInvoker(XDocument carsXDoc, XDocument trucksXDoc)
        {
            this.CarsXDoc = carsXDoc;
            this.TrucksXDoc = trucksXDoc;
        }

        /// <summary>
        /// Invokes the commands, based on user's input.
        /// </summary>
        public void InvokeCommands()
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
                const int commandActionKeyIndex = 0;
                const int commandVehicleKeyIndex = 1;
                const int commandBrandKeyStartIndex = 2;
                const int minimumAmountOfArgs = 2;
                var commandActionKey = commandKeyWords[commandActionKeyIndex];
                
                if (commandKeyWords.Length < minimumAmountOfArgs)
                {
                    Console.WriteLine("A command must contain at least two arguments: type of command, type of vehicle, (optional for average_price) brand of vehicle");
                    continue;
                }

                // Determine the type of vehicle to process
                var commandVehicleKey = commandKeyWords[commandVehicleKeyIndex];
                List<VehicleInfoStruct> listToProcess;
                switch (commandVehicleKey)
                {
                    case "car":
                        listToProcess = DatabaseCars.GetDatabaseCars(this.CarsXDoc).ListOfCars;
                        break;
                    case "truck":
                        listToProcess = DatabaseTrucks.GetDatabaseTrucks(this.TrucksXDoc).ListOfTrucks;
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
                        if (commandKeyWords.Length > minimumAmountOfArgs)
                        {
                            // Create a joined string in case of brand having multiple words
                            var commandBrandKey = commandKeyWords.Length > minimumAmountOfArgs + 1
                                                   ? string.Join(" ", commandKeyWords, commandBrandKeyStartIndex, commandKeyWords.Length - minimumAmountOfArgs)
                                                   : commandKeyWords[commandBrandKeyStartIndex];

                            // Check if the brand exists in the database 
                            if (listToProcess.Any(vehicle => vehicle.Brand == commandBrandKey))
                            {
                                commandsQueue.Add(
                                    new CommandCountAveragePriceOfBrand(
                                        new CounterAveragePriceOfBrand(),
                                        listToProcess,
                                        commandBrandKey));
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

                break;
            }

            foreach (var command in commandsQueue)
            {
                Console.WriteLine(command.Execute());
            }
        }
    }
}