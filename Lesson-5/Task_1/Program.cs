using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = UserInput();
            WriteTextInFile(str);
            Console.WriteLine("Готово!");
            Console.ReadLine();
        }

        /// <summary>Ввод в консоль.</summary>
        /// <returns>Полученная строка.</returns>
        private static string UserInput()
        {
            Console.WriteLine("Введите строку, которая будет записана в файл.");
            return Console.ReadLine();
        }

        /// <summary>Запись в txt файл.</summary>
        /// <param name="str">Записываемая строка.</param>
        private static void WriteTextInFile(string str)
        {
            string filename = "taxt.txt";
            File.WriteAllText(filename, str);
        }
    }
}
