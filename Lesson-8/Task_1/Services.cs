using System;
using System.Configuration;

namespace Task_1
{
    internal static class Services
    {
        #region Save

        /// <summary>Сохранить настройки.</summary>
        /// <param name="greetingSettings">Экземпляр класса настроек.</param>
        internal static void SaveSettings(GreetingSettings greetingSettings)
        {
            AddUpdateAppSettings("Name", greetingSettings.Name);
            AddUpdateAppSettings("Age", greetingSettings.Age.ToString());
            AddUpdateAppSettings("Prof", greetingSettings.Prof);
        }

        /// <summary>Сохранение/Добавление настроек.</summary>
        /// <param name="key">Имя параметра.</param>
        /// <param name="value">Значение.</param>
        private static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        #endregion

        #region Read

        /// <summary>Загрузить настройки.</summary>
        /// <returns>Экземпляр класса настроек.</returns>
        internal static GreetingSettings ReadSettings()
        {
            string name = Reader("Name");
            string prof = Reader("Prof");

            string ageStr = Reader("Age");
            int age = 0;
            if (ageStr != string.Empty && ageStr != "Not Found")
            {
                age = Int32.Parse(Reader("Age"));
            }

            GreetingSettings greetingSettings = new GreetingSettings(name, age, prof);
            return greetingSettings;
        }

        /// <summary>Чтение настроек из файла.</summary>
        /// <param name="key">Наименование настройки.</param>
        /// <returns>Полученное значение.</returns>
        private static string Reader(string key)
        {
            string result = string.Empty;
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
            }
            catch(ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
            }
            return result;
        }

        #endregion
    }
}
