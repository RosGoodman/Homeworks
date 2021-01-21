using System;

namespace Task_2
{
    class PhoneBook
    {
        static void Main()
        {
            Console.WriteLine("Введите \"com\", что-бы увидеть возможные команды.");
            string command = Console.ReadLine();
        }

        /// <summary></summary>
        /// <param name="command"></param>
        private void Commands(string command)
        {
            switch (command)
            {
                case "com":
                    PrintAllCommand();
                    break;
                case "list":
                    PrintAllCommand();
                    break;
                case "add":
                    PrintAllCommand();
                    break;
                case "del(1)":
                    PrintAllCommand();
                    break;
                case "change(1)":
                    PrintAllCommand();
                    break;
            }
        }

        private void PrintAllCommand()
        {
            Console.WriteLine($"com - вывести все команды" +
                $"list - вывести весь список контактов" +
                $"add - добавить контакт (через пробел \"имя телефон/email\")" +
                $"del(1) - удалить контакт под указанным номером" +
                $"change(1) - изменить контакт под указанным номером");
        }
    }
}
