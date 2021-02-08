using Decomposition.Controllers;
using System;

namespace Decomposition
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.CommadSterter("startText");
            string command = CommandReader();
            string[] commandAnswer = controller.CommadSterter(command);
            Writer(commandAnswer);
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
