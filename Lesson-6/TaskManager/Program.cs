using System;
using System.Diagnostics;

namespace TaskManager
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            WriteAllProcess();
            WriteAllCommands();
            CommandsStarter();
        }

        /// <summary>Вывод списка всех процессов.</summary>
        private static void WriteAllProcess()
        {
            Process[] processes = Process.GetProcesses();

            Console.WriteLine("          ID  Process Name");
            Console.WriteLine("============  ================================");

            foreach (Process p in processes)
            {
                if (Console.ForegroundColor == ConsoleColor.White)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  {0,10}  {1,0}", p.Id, p.ProcessName);
            }
        }

        /// <summary>Вывод списка всех команд.</summary>
        private static void WriteAllCommands()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("\\res           - обновить; \n" +
                "\\ki 1111       - остановить процесс по ID; \n" +
                "\\kn FireFox    - остановить процесс по имени; \n" +
                "\\c             - вывести список команд; \n" +
                "\\q             - выход.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>Запуск введенной команды.</summary>
        private static void CommandsStarter()
        {
            string commandStr = string.Empty;
            do
            {
                commandStr = Console.ReadLine();
            } while (commandStr == "");
            
            string[] command = commandStr.Split(' ');
            switch (command[0])
            {
                case "\\res":
                    Main();
                    break;
                case "\\ki":
                    KillProcByID(command[1]);
                    CommandsStarter();
                    break;
                case "\\kn":
                    KillProcByName(command[1]);
                    CommandsStarter();
                    break;
                case "\\c":
                    WriteAllCommands();
                    CommandsStarter();
                    break;
                case "\\q":
                    break;
                default:
                    CommandsStarter();
                    break;
            }
        }

        /// <summary>Завершить процесс по ID.</summary>
        /// <param name="processID">ID процесса.</param>
        private static void KillProcByID(string processID)
        {
            bool procKilled = false;
            int intPocessID = 0;
            int.TryParse(processID, out intPocessID);
            if (!int.TryParse(processID, out intPocessID)) intPocessID = -1;    //если не удалось парсить

            foreach (Process process in Process.GetProcesses())
            {
                if (process.Id == intPocessID)
                {
                    procKilled = true;
                    if (Question(process))
                    {
                        process.Kill();
                        Console.WriteLine("Готово!");
                    }
                }
            }
            if (!procKilled) NotFound(processID);
        }

        /// <summary>Завершить процесс по имени.</summary>
        /// <param name="processID">Имя процесса.</param>
        private static void KillProcByName(string processName)
        {
            bool procKilled = false;
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == processName)
                {
                    procKilled = true;
                    if (Question(process))
                    {
                        process.Kill();
                        Console.WriteLine("Готово!");
                    }
                }
            }
            if (!procKilled) NotFound(processName);
        }

        /// <summary>Вывод сообщения об отсутствии искомого процесса.</summary>
        /// <param name="proc">Имя или ID процесса.</param>
        private static void NotFound(string proc)
        {
            Console.WriteLine("Процесс {0} не найден.", proc);
        }

        /// <summary>Запрос подтверждения.</summary>
        /// <param name="process">Выбранный процесс.</param>
        /// <returns>Ответ пользователя.</returns>
        private static bool Question(Process process)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вы действительно желаете завершить процесс {0} - {1}? y/n", process.ProcessName, process.Id);
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "n":
                    return false;
                case "y":
                    return true;
                default:
                    return Question(process);
            }
        }
    }
}
