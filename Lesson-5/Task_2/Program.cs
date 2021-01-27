using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string time = GetTime();
            Messages(true, time);
            WriteTextInFile(time);
            Messages(false);
            Console.ReadLine();
        }

        /// <summary>Получить текущее время.</summary>
        /// <returns>Текущее время, строка.</returns>
        private static string GetTime()
        {
            string time = DateTime.Now.ToString("HH.mm.ss");
            return time;
        }

        /// <summary>Добавление текста в txt файл.</summary>
        /// <param name="str">Записываемая строка.</param>
        private static void WriteTextInFile(string str)
        {
            string filename = "Time.txt";
            File.AppendAllText(filename, Environment.NewLine);
            File.AppendAllText(filename, str);
        }

        /// <summary>Вывод сообщения в начале и конце программы.</summary>
        /// <param name="startProg">Текущее состояние (старт/конец).</param>
        /// <param name="time">Время.</param>
        private static void Messages(bool startProg, string time = "")
        {
            if(startProg)
                Console.WriteLine("Текущее время {0}, будет записано в файл Time.txt.", time);
            else
                Console.WriteLine("Готово!");
        }
    }
}
