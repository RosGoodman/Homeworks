using Decomposition.ReadAndWrite;
using System;

namespace Decomposition.Settings
{
    class ProgSettings
    {
        private string _folderPath = string.Empty;
        private string _settFileName = "settings.txt";  //путь к файлу с настройками.
        private string _fileWithChanges = "changes.txt";    //путь к файлу с изменениями.
        private DateTime _lastCheck;

        /// <summary>Путь к файлу со списком изменений.</summary>
        internal string FileWithChanges
        {
            get { return _fileWithChanges; }
        }

        /// <summary>Дата последней проверки.</summary>
        internal DateTime LastCheck
        {
            get { return _lastCheck; }
            set { _lastCheck = value; }
        }

        /// <summary>Путь к папке, в которой прог. будет осуществлять работу.</summary>
        internal string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; }
        }

        internal ProgSettings()
        {

        }

        //TODO удалить, если будет не нужен.
        internal ProgSettings(string folderPath, DateTime lastCheck)
        {
            FolderPath = folderPath;
            LastCheck = lastCheck;
        }

        /// <summary>Загрузить настройки.</summary>
        internal void LoadSettings()
        {
            ReadAndWriteFiles rw = new ReadAndWriteFiles();
            string[] settings = rw.ReadTxt(_settFileName);

            if(settings.Length >= 1) FolderPath = settings[0];
            if(settings.Length >= 2) LastCheck = DateTime.Parse(settings[1]);
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
            string[] sett = new string[4];
            sett[0] = "Файл с настройками: " + _settFileName + " (не изменяемо).";
            sett[1] = "Файл с изменениями: " + _fileWithChanges + " (не изменяемо).";
            sett[2] = "Путь к отлеживаемой директории: " + FolderPath;
            sett[3] = "Дата последней проверки: " + LastCheck;

            return sett;
        }
    }
}
