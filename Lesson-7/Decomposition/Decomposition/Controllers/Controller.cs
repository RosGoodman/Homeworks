using Decomposition.Services;
using Decomposition.Settings;
using System.Collections.Generic;

namespace Decomposition.Controllers
{
    internal class Controller
    {
        private ProgSettings _settings;
        internal Controller()
        {
            _settings = new ProgSettings();
            _settings.LoadSettings();
        }

        /// <summary>Вызвать команду.</summary>
        /// <param name="command">Строка команды.</param>
        /// <returns>Ответ команды.</returns>
        internal string[] CommadSterter(string command)
        {
            command = command.ToLower();
            string[] comParam = command.Split(' ');
            string[] lines = new string[1];     //результат работы команд в текстовом виде.
            switch (comParam[0])
            {
                case "starttext":
                    return GetStartText();
                case "com":
                    return GetListAllCommands();
                case "sett":
                    return GetListSettings();
                case "ndir":
                    return ChangeDirectory(comParam[1]);
                case "changes":
                    return FindChanges();
                case "q":
                    lines[0] = "выход";
                    return lines;
                default:
                    return lines;
            }
        }

        #region Commands

        /// <summary>Найти изменения.</summary>
        /// <returns>Массив с найденными изменениями.</returns>
        internal string[] FindChanges()
        {
            List<string> ListAllChanges = new List<string>();
            string[] allChanges = new string[1];
            if (_settings.FolderPath != string.Empty)
            {
                ListAllChanges = ChangeFinder.StartRecursiveMethod(_settings.FolderPath);
                allChanges = new string[ListAllChanges.Count];

                int i = 0;
                foreach (string str in ListAllChanges)   //переписываем в массив для возврата.
                {
                    allChanges[i] = ListAllChanges[i];
                    i++;
                }
            }
            else
            {
                allChanges[1] = "Не задана отслеживаемая директория.";
            }
            
            return allChanges;
        }

        /// <summary>Получить стартовый текст.</summary>
        /// <returns>Текст построчно.</returns>
        internal string[] GetStartText()
        {
            string[] lines = new string[1];
            if (_settings.FolderPath == string.Empty)
                lines[0] = "Отслеживаемая дериктория не выбрана.";
            else
                lines[0] = _settings.FolderPath;

            return lines;
        }

        /// <summary>Получить список всех команд.</summary>
        /// <returns>Массив команд построчно.</returns>
        internal string[] GetListAllCommands()
        {
            string[] commands = new string[5];
            commands[0] = "com                  - вывести список всех команд;";
            commands[1] = "sett                 - вывести текущие нестройки;";
            commands[2] = "ndir C:\\Users\\       - изменить отслеживаемую директорию;";
            commands[3] = "changes              - поиск изменений;";
            commands[4] = "q                    - выход.";
            return commands;
        }

        /// <summary>Получить список настроек.</summary>
        /// <returns>Массив настроек построчно.</returns>
        internal string[] GetListSettings()
        {
            return _settings.GetSettings();
        }

        /// <summary>Изменить отслеживаемую директорию.</summary>
        /// <returns>Путь к отслеживаемой директории.</returns>
        internal string[] ChangeDirectory(string newPath)
        {
            string[] answer = new string[1];

            _settings.FolderPath = newPath;
            _settings.SaveSettings();
            answer[0] = "Установлена новая отслеживаемая директория.";
            //TODO  очистить файл с результатами
            return answer;
        }

        #endregion
    }
}
