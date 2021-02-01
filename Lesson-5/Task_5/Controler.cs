using System;

namespace Task_5
{
    class Controler
    {
        Tasks tasks = new Tasks();

        internal Controler()
        {
            SaveAndLoadData saveAndLoadData = new SaveAndLoadData();
            Tasks loadTasks = new Tasks();
            loadTasks = saveAndLoadData.LoadTasksXml();
            if (loadTasks.ToDos != null)
                tasks = loadTasks;

            StartMethod();
            
        }

        private void StartMethod()      //выведен в отдельный метод из-за рекурсии
        {
            string command = String.Empty;
            do
            {
                Console.WriteLine("Введите необходимую команду. Для просмотра списка команд введите \"команды\".");
                command = Console.ReadLine();
            } while (command == "");

            CallingCommand(command);

            if (command != "выход") StartMethod();
        }

        /// <summary>Запуск введенной команды.</summary>
        /// <param name="command">Команда.</param>
        internal void CallingCommand(string command)
        {
            command = command.ToLower();
            string[] splitStr = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);   //разбита на массив для выделения команды
            command = splitStr[0];

            int number=0;
            bool isNumber = int.TryParse(splitStr[0], out number);
            if (isNumber)
                command = "выполнена";

            switch (command)
            {
                case "команды":
                    PrintAllCommand();
                    break;
                case "задачи":
                    PrintTasks();
                    break;
                case "сохранить":
                    SaveTasks();
                    break;
                case "новая":
                    NewTask(splitStr);
                    break;
                case "выполнена":
                    TaskDone(number);
                    break;
                case "выход":
                    break;
                default:
                    break;
            }
        }

        /// <summary>Пометить задачу выполненной.</summary>
        /// <param name="numberTask">Номер выполненной задачи.</param>
        internal void TaskDone(int numberTask)
        {
            tasks.ToDos[numberTask].IsDone = true;
        }

        internal void SaveTasks()
        {
            SaveAndLoadData saveAndLoadData = new SaveAndLoadData();
            saveAndLoadData.SaveTasksXml(tasks);
        }

        /// <summary>Добавить новую задачу.</summary>
        /// <param name="taskStr">Введенная строка.</param>
        internal void NewTask(string[] taskStr)
        {
            string task = String.Empty;
            for (int i = 1; i < taskStr.Length; i++)
            {
                task += taskStr[i] + " ";
            }

            ToDo toDo = new ToDo(task);
            tasks.AddTask(toDo);
        }

        /// <summary>Вывести список всех команд.</summary>
        internal void PrintAllCommand()
        {
            Console.WriteLine($"\nкоманды      вывести все команды;\n" +
                $"задачи       показать список задач;\n" +
                $"сохранить    сохранить список задач в файл tasks.json\n" +
                $"новая        добавить задачу. Паосле команды через пробел введите описание задачи;\n" +
                $"1            номер выполненной задачи: \n" +
                $"выход        выход из программы.\n");
        }

        /// <summary>Вывести список задач.</summary>
        internal void PrintTasks()
        {
            string taskStatus = String.Empty;
            if (tasks.ToDos == null || tasks.ToDos.Count == 0)
                Console.WriteLine("Нет сохраненных задач.");
            else
            {
                Console.WriteLine();
                for (int i = 0; i < tasks.ToDos.Count; i++)
                {
                    if (tasks.ToDos[i].IsDone)
                        taskStatus = "[X]";
                    else
                        taskStatus = "";

                    Console.WriteLine("{0}. {1} {2}",i+1 ,taskStatus , tasks.ToDos[i].Title);
                }
                Console.WriteLine();
            }
        }
    }
}
