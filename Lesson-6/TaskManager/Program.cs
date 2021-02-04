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

            Console.ReadLine();
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
                    break;
                case "\\kn":
                    KillProcByName(command[1]);
                    break;
                case "\\c":
                    WriteAllCommands();
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
            foreach(Process process in Process.GetProcesses())
            {
                if (process.Id == Convert.ToInt32(processID)) process.Kill();
            }
        }

        /// <summary>Завершить процесс по имени.</summary>
        /// <param name="processID">Имя процесса.</param>
        private static void KillProcByName(string processName)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == processName) process.Kill();
            }
        }
    }
}
