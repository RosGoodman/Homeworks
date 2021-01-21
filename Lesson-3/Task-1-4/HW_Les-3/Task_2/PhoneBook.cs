using System;

namespace Task_2
{
    class PhoneBook
    {
        static void Main()
        {
            PhoneBook phoneBook = new PhoneBook();
            string[,] contacts = phoneBook.GetArrayContacts();

            string command;
            do
            {
                Console.WriteLine("Введите \"com\", что-бы увидеть возможные команды.");
                command = (Console.ReadLine().ToLower());
                phoneBook.Commands(command, contacts);
            } while (command != "q");
            
        }

        /// <summary>Получить массив контактов.</summary>
        /// <returns>Массив контактов (имя, тел.\email)</returns>
        private string[,] GetArrayContacts()
        {
            string[,] contacts = new string[5,2];

            contacts[0, 0] = "Иван";
            contacts[0, 1] = "278-32-66";
            contacts[1, 0] = "Елена";
            contacts[1, 1] = "elena22@gmail.com";
            contacts[2, 0] = "Анатолий";
            contacts[2, 1] = "(911) 256 77 77";

            return contacts;
        }

        /// <summary>Определение и запуск команды.</summary>
        /// <param name="command">Команда.</param>
        /// <param name="contacts">Массив конактов.</param>
        private void Commands(string command, string[,] contacts)
        {
            string[] comParts = command.Split(' ');
            int contactNumb = 0;
            if (comParts.Length == 2)
            {
                contactNumb = Convert.ToInt32(comParts[1]);
                if (contactNumb > contacts.GetLength(0) || contactNumb < 0) PrintErrore("wrongContNumb");
            }

            switch (comParts[0])
            {
                case "com":
                    PrintAllCommand();
                    Console.WriteLine("1");
                    break;
                case "list":
                    Console.WriteLine("2");
                    ShowContactList(contacts, contactNumb);
                    break;
                case "add":
                    Console.WriteLine("3");
                    break;
                case "del":
                    Console.WriteLine("4");
                    break;
                case "change":
                    Console.WriteLine("5");
                    break;
            }
        }

        /// <summary>Вывод контактов в консоль.</summary>
        /// <param name="contacts">Массив контактов.</param>
        /// <param name="contactNumb">Номер выводимого контакта.</param>
        private void ShowContactList(string[,] contacts, int contactNumb)
        {
            int x = contacts.GetLength(0);
            if (contactNumb == contacts.GetLength(0))
            {
                for(int i = 0; i<contacts.GetLength(0); i++)
                {
                    if(contacts[i,0] != "" && contacts[i,0] != null)
                        Console.WriteLine("{0}  - {1}", contacts[i,0], contacts[i,1]);
                }
            }
            else Console.WriteLine("{0}  - {1}", contacts[contactNumb,0], contacts[contactNumb,1]);
        }

        /// <summary>Вывод списка команд.</summary>
        private void PrintAllCommand()
        {
            Console.WriteLine($"\ncom       - вывести все команды\n" +
                $"show  1   - вывести весь список контактов\n" +
                $"add       - добавить контакт (через пробел \"имя телефон/email\")\n" +
                $"del  1    - удалить контакт под указанным номером\n" +
                $"change  1 - изменить контакт под указанным номером\n" +
                $"q         - выход\n" +
                $"Номер контакта не оьязателен, без них команда воздействует на все контакты.\n");
        }

        private void PrintErrore(string errName)
        {
            switch (errName)
            {
                case "wrongContNumb":
                    Console.WriteLine("Неверное значение номера контакта.");
                    break;
            }
        }
    }
}
