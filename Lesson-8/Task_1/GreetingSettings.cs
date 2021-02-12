namespace Task_1
{
    /// <summary>Настройки приветствия.</summary>
    internal class GreetingSettings
    {
        private string _pathSettingsFile = "settings.json";
        private string _greetingText = string.Empty;
        private string _name = string.Empty;
        private int _age;
        private string _prof = string.Empty;

        /// <summary>Путь к файлу с настройками.</summary>
        internal string PathSettingsFile
        {
            get { return _pathSettingsFile; }
        }

        /// <summary>Получить сохраненные сведения.</summary>
        /// <returns>Строка со сведениями.</returns>
        internal string GetGreetingText()
        {
            string greeting = _greetingText;
            if(_name != string.Empty)
            {
                greeting += ("\nСохраненные данные: {0}, {1}, {2}", _name, _age, _prof);
            }
            return greeting;
        }

        #region ctors

        /// <summary>Настройки приветствия.</summary>
        /// <param name="name">Имя.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="prof">Профессия.</param>
        public GreetingSettings(string name, int age, string prof)
        {
            _name = name;
            _age = age;
            _prof = prof;
        }

        /// <summary>Настройки приветствия.</summary>
        public GreetingSettings()
        {

        }

        #endregion
    }
}
