using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetingSettings greetingSettings = new GreetingSettings();
            greetingSettings = Services.ReadSettings();

            Console.WriteLine("Версия продукта: {0}", typeof(Program).Assembly.GetName().Version);
            Console.WriteLine(greetingSettings.GetGreetingText());

            greetingSettings = UserInput();
            Services.SaveSettings(greetingSettings);

            Console.ReadLine();
        }

        /// <summary>Чтение ввода в консоль.</summary>
        /// <returns>Экземпляр класса настроек.</returns>
        private static GreetingSettings UserInput()
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            bool isNumeric = false;
            int age;
            do
            {
                Console.WriteLine("Введите возраст:");
                isNumeric = int.TryParse(Console.ReadLine(), out age);
                if (!isNumeric) Console.WriteLine("Неверное значение");
            } while (!isNumeric);

            Console.WriteLine("Введите профессию:");
            string prof = Console.ReadLine();

            GreetingSettings greetingSettings = new GreetingSettings(name, age, prof);
            return greetingSettings;
        }
    }
}
