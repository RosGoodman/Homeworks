using Decomposition.ReadAndWrite;

namespace Decomposition.Settings
{
    class ProgSettings
    {
        private string _folderPath = string.Empty;
        private string _settFileName = "settings.txt";  //путь к файлу с настройками.

        /// <summary>Путь к папке, в которой прог. будет осуществлять работу.</summary>
        internal string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; }
        }

        public ProgSettings()
        {

        }

        public ProgSettings(string folderPath)
        {
            FolderPath = folderPath;
        }

        /// <summary>Загрузить настройки.</summary>
        internal void LoadSettings()
        {
            ReadAndWriteFiles rw = new ReadAndWriteFiles();
            string[] settings = rw.ReadTxt(_settFileName);

            if(settings.Length == 1)
            {
                _folderPath = settings[0];
            }
        }

        /// <summary>Сохранить настройки.</summary>
        /// <param name="path"></param>
        internal void SaveSettings()
        {
            string[] settings = new string[1];
            settings[0] = FolderPath;
            ReadAndWriteFiles rw = new ReadAndWriteFiles();
            rw.WriteTxt(settings, _settFileName);
        }

        /// <summary>Получить список настроек.</summary>
        /// <returns>Массив строк с настройками.</returns>
        internal string[] GetSettings()
        {
            string[] sett = new string[2];
            sett[0] = "Файл с настройками: " + _settFileName + " (не изменяемо).";
            sett[0] = "Путь к отлеживаемой директории: " + _folderPath;
            return sett;
        }
    }
}
