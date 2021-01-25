using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            string firstName = "Петр";
            string lastName = "Иванов";
            string patronymic = "Васильевич";
            Console.WriteLine(program.GetFullName(firstName, lastName, patronymic));

            Console.WriteLine(program.GetFullName("Василий", "Петров", "Николаевич"));

            lastName = "Васильев";
            string fullName = program.GetFullName("Иван", lastName, "Федорович");
            Console.WriteLine(fullName);

            Console.ReadLine();
        }

        /// <summary>Получить ФИО строкой.</summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <returns>ФИО.</returns>
        private string GetFullName(string firstName, string lastName, string patronymic)
        {
            return lastName + " " + firstName + " " + patronymic;
        }
    }
}
