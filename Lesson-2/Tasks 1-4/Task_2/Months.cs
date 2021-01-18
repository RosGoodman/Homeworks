using System;

namespace Task_2
{
    class Months
    {
        static void Main()
        {
            byte monthNumb = 0;
            string monthName = "";

            do
            {
                Console.WriteLine("Введите номер месяца (1-12):");
                monthNumb = Convert.ToByte(Console.ReadLine());
            } while (monthNumb < 1 || monthNumb > 12);

            switch (monthNumb)
            {
                case 1:
                    monthName = "Январь";
                    break;
                case 2:
                    monthName = "Февраль";
                    break;
                case 3:
                    monthName = "Март";
                    break;
                case 4:
                    monthName = "Апрель";
                    break;
                case 5:
                    monthName = "Май";
                    break;
                case 6:
                    monthName = "Июнь";
                    break;
                case 7:
                    monthName = "Июль";
                    break;
                case 8:
                    monthName = "Август";
                    break;
                case 9:
                    monthName = "Сентябрь";
                    break;
                case 10:
                    monthName = "Октябрь";
                    break;
                case 11:
                    monthName = "Ноябрь";
                    break;
                case 12:
                    monthName = "Декабрь";
                    break;
            }
            Console.WriteLine("Месяц под номером {0} - {1}", monthNumb, monthName);
            Console.Read();
        }
    }
}
