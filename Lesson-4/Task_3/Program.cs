using System;

namespace Task_3
{
    class Program
    {
        enum seasons
        {
            Winter = 1,
            Spring = 2,
            Summer = 3,
            Autumn = 4
        }

        static void Main()
        {
            byte monthNumb = UserInput();
            seasons season = NumbToSeason(monthNumb);
            string seasonRuLang = TranslateName(season);

            Console.WriteLine("Месяц {0} воходит в сеозон: {1}", monthNumb, seasonRuLang);

            Console.Read();
        }

        #region Translate name season
        static string TranslateName(seasons season)
        {
            string seasonRuLang="";
            string kj = season.ToString();
            switch (kj)
            {
                case "Winter":
                    seasonRuLang = "Зима";
                    break;
                case "Spring":
                    seasonRuLang = "Весна";
                    break;
                case "Summer":
                    seasonRuLang = "Лето";
                    break;
                case "Autumn":
                    seasonRuLang = "Осень";
                    break;
            }

            return seasonRuLang;
        }
        #endregion

        #region Значение из перечисления.

        /// <summary>Метод с получением значения из перечисления.</summary>
        /// <param name="monthNumb">Номер месяца.</param>
        /// <returns>Значение перечисления seasons.</returns>
        static private seasons NumbToSeason(byte monthNumb)
        {
            seasons season = seasons.Autumn;
            switch (monthNumb)
            {
                case 1:
                case 2:
                case 12:
                    season = seasons.Winter;
                    break;
                case 3:
                case 4:
                case 5:
                    season = seasons.Spring;
                    break;
                case 6:
                case 7:
                case 8:
                    season = seasons.Summer;
                    break;
                case 9:
                case 10:
                case 11:
                    season = seasons.Autumn;
                    break;
            }
            return season;
        }

        #endregion

        #region UserInput

        /// <summary>Ввод данных пользователем в консоль.</summary>
        /// <returns>Номер месяца.</returns>
        static private byte UserInput()
        {
            byte monthNumb = 0;

            while (true)
            {
                monthNumb = Convert.ToByte(Console.ReadLine());
                if (monthNumb < 1 || monthNumb > 12)
                    Console.WriteLine("Ошибка: введите число от 1 до 12.");
                else break;
            }
            
            return monthNumb;
        }

        #endregion
    }
}
