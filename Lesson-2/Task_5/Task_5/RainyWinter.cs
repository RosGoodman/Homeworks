using System;
using System.Collections.Generic;

namespace Task_5
{
    class RainyWinter
    {
        static void Main()
        {
            byte monthNumb = 0;
            string monthName;

            RainyWinter rainyWinter = new RainyWinter();
            Dictionary<string, string> userInputData = rainyWinter.UserInput();

            monthNumb = Convert.ToByte(userInputData["monthNumb"]);
            monthName = rainyWinter.Months(monthNumb);
            float aveT = rainyWinter.AverageT(userInputData["minT"], userInputData["maxT"]);

            Console.WriteLine("Среднесуточная температура равна: {0:f1}C", aveT);
            Console.WriteLine("Месяц под номером {0} - {1}", monthNumb, monthName);
            Console.Read();
        }

        #region UserInput

        /// <summary>Ввод данных пользователем в консоль.</summary>
        /// <returns>Введенные данные.</returns>
        private Dictionary<string, string> UserInput()
        {
            byte monthNumb = 0;
            string minT_str = "", maxT_str = "";
            Dictionary<string, string> userInputData = new Dictionary<string, string>();

            do
            {
                Console.WriteLine("Введите номер месяца (1-12):");
                monthNumb = Convert.ToByte(Console.ReadLine());
            } while (monthNumb < 1 || monthNumb > 12);
                        
            do
            {
                if (minT_str == "")
                {
                    Console.WriteLine("Введите минимальную суточную температуру C:");
                    minT_str = Console.ReadLine();
                }
                if (maxT_str == "")
                {
                    Console.WriteLine("Введите максимальную суточную температуру C:");
                    maxT_str = Console.ReadLine();
                }
            } while (minT_str == "" || maxT_str == "");

            userInputData.Add("minT", minT_str);
            userInputData.Add("maxT", maxT_str);
            userInputData.Add("monthNumb", monthNumb.ToString());
            return userInputData;
        }

        #endregion

        #region Months

        /// <summary>Определение месяца по номеру.</summary>
        /// <param name="monthNumb">Номер месяца.</param>
        /// <returns>Наименование месяца.</returns>
        private string Months(byte monthNumb)
        {
            string monthName="";
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
            return monthName;
        }

        #endregion

        #region AverageT

        /// <summary>Рассчет средней температуры.</summary>
        /// <param name="minT_str">Мин. температура.</param>
        /// <param name="maxT_str">Макс. Температура.</param>
        /// <returns>Средняя температура.</returns>
        private float AverageT(string minT_str,string maxT_str)
        {
            float aveT;
            float minT = float.Parse(minT_str);
            float maxT = float.Parse(maxT_str);

            if (maxT < minT)
            {
                Console.WriteLine("Максимальная температура не может быть меньше минимальной!");
                UserInput();
            }

            aveT = (minT + maxT) / 2;
            return aveT;
        }

        #endregion
    }
}
