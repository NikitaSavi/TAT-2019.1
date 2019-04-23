using System;
using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{
    /// <summary>
    /// The commands invoker.
    /// </summary>
    internal class CommandsInvoker
    {
        /// <summary>
        /// Invokes the commands, based on user's input.
        /// </summary>
        /// <param name="listOfCars">
        /// The list of cars with their info.
        /// </param>
        public void InvokeCommands(List<CarInfoStruct> listOfCars)
        {
            while (true)
            {
                Console.WriteLine("Input a command:");
                var command = Console.ReadLine();
                switch (command)
                {
                    case "exit":
                        break;
                    case "count types":
                        Console.WriteLine(
                            $"The amount of marks is {new CommandCountMarks(new CounterMarks(), listOfCars).Execute()}\n");
                        continue;
                    case "count all":
                        Console.WriteLine(
                            $"The amount of cars is {new CommandCountAllCars(new CounterAllCars(), listOfCars).Execute()}\n");
                        continue;
                    case "average price":
                        Console.WriteLine(
                            $"The average price is {new CommandCountAveragePrice(new CounterAveragePrice(), listOfCars).Execute()}\n");
                        continue;
                    default:
                        if (command.Contains("average price")
                            && listOfCars.Any(car => car.Mark == command.Split(' ')[2]))
                        {
                            Console.WriteLine(
                                $"The average price of {command.Split(' ')[2]} is "
                                + $"{new CommandCountAveragePriceOfMark(new CounterAveragePriceOfMark(), listOfCars, command.Split(' ')[2]).Execute()}\n");
                        }
                        else
                        {
                            Console.WriteLine("Unknown input.\n");
                        }

                        continue;
                }
            }
        }
    }
}