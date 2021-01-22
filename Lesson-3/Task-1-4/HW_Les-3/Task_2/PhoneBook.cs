using System;

namespace Task_2
{
    class PhoneBook
    {
        static void Main()
        {
            PhoneBook phoneBook = new PhoneBook();
            string command;

            do
            {
                Console.WriteLine("Введите \"com\", что-бы увидеть возможные команды.");
                command = Console.ReadLine().ToLower();
                Console.WriteLine();

                string[,] contacts = ArrayContacts.Contacts;
                phoneBook.Commands(command, contacts);
            } while (command != "q");
        }
        
        /// <summary>Определение и запуск команды.</summary>
        /// <param name="command">Команда.</param>
        /// <param name="contacts">Массив конактов.</param>
        private void Commands(string command, string[,] contacts)
        {
            string[] comParts = command.Split(' ');

            switch (comParts[0])
            {
                case "com":
                    PrintAllCommand();
                    break;
                case "list":
                    ShowContactList(contacts, comParts);
                    break;
                case "add":
                    AddContact(contacts, comParts);
                    break;
                case "rm":
                    RemoveContact(contacts, comParts);
                    break;
                case "change":
                    ChangeContact(contacts, comParts);
                    break;
                case "q":
                    break;
                case "":
                    break;
                default:
                    PrintErrors("wrongCommand");
                    break;
            }
        }

        #region GetContactCount
        /// <summary>Получение кол-ва контактов.</summary>
        /// <param name="contacts">Массив контактов.</param>
        /// <param name="comParts">Команда, разбитая на составные.</param>
        /// <returns>Кол-во контактов.</returns>
        private int GetContactCount(string[,] contacts, string[] comParts)
        {
            int contactNumb = 1;
            if (comParts.Length > 1)
            {
                contactNumb = Convert.ToInt32(comParts[1]);
                if (contactNumb > contacts.GetLength(0) || contactNumb < 1) PrintErrors("wrongContNumb");
            }
            return contactNumb;
        }
        #endregion

        #region AddContacts
        private void AddContact(string[,] contacts, string[] comParts)
        {
            int contactsCount = 0;
            for(int i=0; i < contacts.GetLength(0); i++)
            {
                if(contacts[i, 0] != null) contactsCount++;
            }
            int x = contacts.GetLength(0);

            if (contacts.GetLength(0) == contactsCount)
            {
                PrintErrors("outOfRange");
                return;
            }
            else
            {
                contacts[contactsCount, 0] = comParts[1];   //имя
                if (comParts.Length == 3) contacts[contactsCount, 1] = comParts[2];   //номер/email
            }
        }
        #endregion

        #region RemoveContacts
        private void RemoveContact(string[,] contacts, string[] comParts)
        {
            int contactNumb = GetContactCount(contacts, comParts)-1;
            if (contacts[contactNumb, 0] == null) return;

            for(int i = contactNumb; i < contacts.GetLength(0)-1; i++)
            {
                contacts[i, 0] = contacts[i + 1, 0];
                contacts[i, 1] = contacts[i + 1, 1];
            }
            contacts[4, 0] = null;
            contacts[4, 1] = null;
        }
        #endregion

        #region ChangeContact
        private void ChangeContact(string[,] contacts, string[] comParts)
        {
            int contactNumb = GetContactCount(contacts, comParts) - 1;

            contacts[contactNumb, 0] = comParts[2];
            contacts[contactNumb, 1] = comParts[3];
        }
        #endregion

        #region ShowContactList
        /// <summary>Вывод контактов в консоль.</summary>
        /// <param name="contacts">Массив контактов.</param>
        /// <param name="contactNumb">Номер выводимого контакта.</param>
        private void ShowContactList(string[,] contacts, string[] comParts)
        {
            int contactNumb = GetContactCount(contacts, comParts);
            if (comParts.Length < 2)
            {
                for(int i = 0; i<contacts.GetLength(0); i++)
                {
                    if(contacts[i,0] != "" && contacts[i,0] != null)
                        Console.WriteLine("{0}  - {1}", contacts[i,0], contacts[i,1]);
                }
            }
            else if (contacts[contactNumb-1, 0] != null)
                Console.WriteLine("{0}  - {1}", contacts[contactNumb-1,0], contacts[contactNumb-1,1]);
            else
                PrintErrors("wrongContNumb");
        }
        #endregion

        #region PrintCommands
        /// <summary>Вывод списка команд.</summary>
        private void PrintAllCommand()
        {
            Console.WriteLine($"com                - вывести все команды\n" +
                $"list 1             - вывести весь список контактов\n" +
                $"add name mail      - добавить контакт\n" +
                $"rm 1               - удалить контакт под указанным номером\n" +
                $"change 1 name mail - изменить контакт под указанным номером\n" +
                $"q                  - выход\n" +
                $"Номер контакта не обязателен, без них команда воздействует на все контакты.\n");
        }
        #endregion

        #region Errors
        /// <summary>Обработка ошибок.</summary>
        /// <param name="errName">Имя ошибки.</param>
        private void PrintErrors(string errName)
        {
            switch (errName)
            {
                case "wrongContNumb":
                    Console.WriteLine("ERR: Неверное значение номера контакта.");
                    break;
                case "wrongCommand":
                    Console.WriteLine("ERR: Нусуществующая команда.");
                    break;
                case "outOfRange":
                    Console.WriteLine("ERR: В книге нет места.");
                    break;
            }
            Main();
        }
        #endregion
    }

    #region Array
    /// <summary>Массив контактов.</summary>
    public static class ArrayContacts
    {
        private static string[,] _contacts;

        public static string[,] Contacts
        {
            get
            {
                if (_contacts == null)
                    _contacts = GetArrayContacts();

                return _contacts;
            }
            set
            {
                if (_contacts == null)
                    _contacts = GetArrayContacts();
                else
                    _contacts = value;
            }
        }

        /// <summary>Получить массив контактов.</summary>
        /// <returns>Массив контактов (имя, тел.\email)</returns>
        private static string[,] GetArrayContacts()
        {
            string[,] contacts = new string[5, 2];

            contacts[0, 0] = "Иван";
            contacts[0, 1] = "278-32-66";
            contacts[1, 0] = "Елена";
            contacts[1, 1] = "elena22@gmail.com";
            contacts[2, 0] = "Анатолий";
            contacts[2, 1] = "(911) 256 77 77";

            return contacts;
        }
    }
    #endregion
}
