using Decomposition.ReadAndWrite;

namespace Decomposition.Settings
{
    class Settings
    {
        private string _folderPath;
        private string _settFileName = "settings.txt";

        internal string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; }
        }

        public Settings()
        {

        }

        public Settings(string folderPath)
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
            else
            {
                //запись новых

            }
        }

        /// <summary>Сохранить настройки.</summary>
        /// <param name="path"></param>
        internal void SaveSettings(string path)
        {
            string[] settings = new string[0];
            ReadAndWriteFiles rw = new ReadAndWriteFiles();

        }
    }
}
