
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

        #region Свойства

        /// <summary>Путь к файлу с настройками.</summary>
        internal string PathSettingsFile
        {
            get { return _pathSettingsFile; }
        }

        /// <summary>Имя.</summary>
        internal string Name
        {
            get { return _name; }
        }

        /// <summary>Возраст.</summary>
        internal int Age
        {
            get { return _age; }
        }

        /// <summary>Профессия.</summary>
        internal string Prof
        {
            get { return _prof; }
        }

        #endregion

        #region Методы

        /// <summary>Получить сохраненные сведения.</summary>
        /// <returns>Строка со сведениями.</returns>
        internal string GetGreetingText()
        {
            string greeting = _greetingText;
            if(_name != string.Empty)
            {
                greeting += ($"\nТекущие сохраненные данные: Имя - {_name}, Возраст - {_age}, Специальность - {_prof}");
            }
            return greeting;
        }

        #endregion

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
