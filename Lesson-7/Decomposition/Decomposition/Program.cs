using System;
using Decomposition.Controllers;

namespace Decomposition
{
    class Program
    {
        static void Main()
        {
            Controller controller = new Controller();
            Writer(controller.CommadSterter("startText"));
            //Writer(controller.CommadSterter("change"));
            Writer(controller.CommadSterter("com"));

            string command = string.Empty;
            do
            {
                command = CommandReader();
                string[] commandAnswer = controller.CommadSterter(command);
                Writer(commandAnswer);
            } while (command != "q");
        }

        /// <summary>Прочитать команду в консли.</summary>
        internal static string CommandReader()
        {
            string command = string.Empty;
            do
            {
                command = Console.ReadLine();
            } while (command == string.Empty);
            return command;
        }

        /// <summary>Вывести на консоль.</summary>
        /// <param name="lines">Массив строк.</param>
        internal static void Writer(string[] lines)
        {
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
