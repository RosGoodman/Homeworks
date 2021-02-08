using Decomposition.Services;
using Decomposition.Settings;

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

        internal string[] CommadSterter(string command)
        {
            command = command.ToLower();
            string[] lines = new string[0];     //результат работы команд в текстовом виде.
            switch (command)
            {
                case "startText":
                    return GetStartText();
                case "com":
                    return GetListAllCommands();
                case "sett":
                    return GetListSettings();
                case "ndir":
                    return ChangeDirectory();
                default:
                    return lines;
            }
        }

        #region Commands

        /// <summary>Получить стартовый текст.</summary>
        /// <returns>Текст построчно.</returns>
        internal string[] GetStartText()
        {
            string[] lines = new string[0];
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
            string[] commands = new string[3];
            commands[0] = "com      - вывести список всех команд;";
            commands[1] = "sett     - вывести текущие нестройки;";
            commands[2] = "ndir     - изменить отслеживаемую директорию.";
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
        internal string[] ChangeDirectory()
        {
            string[] path = new string[1];
            FolderBrowDialog fbd = new FolderBrowDialog();
            path[0] = fbd.GetFolderPath();

            if(path[0] != string.Empty)
            {
                _settings.FolderPath = path[0];
                _settings.SaveSettings();
                return path;
            }
            else
            {
                path[0] = "Не выбран путь к папке.";
                return path;
            }
        }

        #endregion
    }
}
