using System;

namespace Task_6
{
    class BitMask
    {
        [Flags]
        public enum week
        {
            Monday      = 0b_1000000,
            Tuesday     = 0b_0100000,
            Wednesday   = 0b_0010000,
            Thursday    = 0b_0001000,
            Friday      = 0b_0000100,
            Saturday    = 0b_0000010,
            Sunday      = 0b_0000001
        }

        static void Main()
        {
            string wdFirm1 = "пн,вт,ср,чт,пт";
            string wdFirm2 = "ср,чт,сб,вс";
            string dayWeek = "пн";

            BitMask bitMask = new BitMask();
            Console.WriteLine("Введите через запятую рабочие дни недели для фирмы №1. Для ввода дефолтного значения просто нажмите enter. (пн,вт,ср,чт,пт)");
            wdFirm1 = bitMask.UserInput();
            Console.WriteLine("Введите через запятую рабочие дни недели для фирмы №2. Для ввода дефолтного значения просто нажмите enter. (ср,чт,сб,вс)");
            wdFirm2 = bitMask.UserInput();
            Console.WriteLine("Введите день недели. Для ввода дефолтного значения просто нажмите enter. (пн)");
            dayWeek = bitMask.UserInput();

            week maskFirm1 = bitMask.GetMask(wdFirm1);
            week maskFirm2 = bitMask.GetMask(wdFirm2);
            week maskDay = bitMask.GetMask(dayWeek);

            if (bitMask.Compare(maskFirm1, maskDay))
                Console.WriteLine("Фирма №1 в этот день работает.");
            else
                Console.WriteLine("Фирма №1 в этот день не работает.");

            if (bitMask.Compare(maskFirm2, maskDay))
                Console.WriteLine("Фирма №2 в этот день работает.");
            else
                Console.WriteLine("Фирма №2 в этот день не работает.");

            Console.ReadLine();
        }

        #region UserInput

        /// <summary>Ввод с консоли.</summary>
        /// <returns>Строка с днями недели.</returns>
        private string UserInput()
        {
            string str = Console.ReadLine();
            if (str != "")
                return str;
            return "";
        }

        #endregion

        #region Compare

        /// <summary>Определения равенства масок.</summary>
        /// <param name="maskFirm">Маска фирмы.</param>
        /// <param name="maskDay">Маска дня недели.</param>
        /// <returns></returns>
        private bool Compare(week maskFirm, week maskDay)
        {
            week d = maskDay & maskFirm;
            if (d == maskDay)
                return true;
            else
                return false;
        }

        #endregion

        #region GetMask

        /// <summary>Получение bitMask дня недели.</summary>
        /// <returns>Маска дня.</returns>
        private week GetMask(string daysStr)
        {
            daysStr = daysStr.ToLower();
            string[] days = daysStr.Split(',');

            week bitMask = 0;
            week bitMaskDay;
            foreach (string day in days)
            {
                switch (day)
                {
                    case "пн":
                        bitMaskDay = week.Monday;
                        break;
                    case "вт":
                        bitMaskDay = week.Tuesday;
                        break;
                    case "ср":
                        bitMaskDay = week.Wednesday;
                        break;
                    case "чт":
                        bitMaskDay = week.Thursday;
                        break;
                    case "пт":
                        bitMaskDay = week.Friday;
                        break;
                    case "сб":
                        bitMaskDay = week.Saturday;
                        break;
                    case "вс":
                        bitMaskDay = week.Sunday;
                        break;
                    default:
                        bitMaskDay = 0;
                        break;
                }
                bitMask = bitMask | bitMaskDay;

            }
            
            return bitMask;
        }

        #endregion
    }
}
