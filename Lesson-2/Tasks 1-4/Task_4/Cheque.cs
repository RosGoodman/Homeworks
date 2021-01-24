using System;
using System.Collections.Generic;

namespace Task_4
{
    class Cheque
    {
        static void Main()
        {
            string shopName = "\"ООО Лента\"";
            string shopAddres = "С-Пб, Лиговский пр., д. 283, лит. А";

            Dictionary<string, float> purchases = new Dictionary<string, float>();
            purchases.Add("Молоко    ", 56.99f);
            purchases.Add("Хлеб      ", 42.35f);
            purchases.Add("Носки муж.", 75.97f);
            purchases.Add("Краска    ", 199.99f);

            Cheque cheque = new Cheque();
            float summPurch = cheque.Summ(purchases);

            cheque.PrintCheque(shopName, shopAddres, purchases, summPurch);
        }

        /// <summary>Печать чека в консоль.</summary>
        /// <param name="shopName">Название магазина.</param>
        /// <param name="shopAddres">Адрес магазина.</param>
        /// <param name="purchases">Список покупок (название/цена)</param>
        /// <param name="summPurch">Сумма покупок.</param>
        private void PrintCheque(string shopName, string shopAddres, Dictionary<string, float> purchases, float summPurch)
        {
            Console.WriteLine("\t    {0}\n{1}", shopName, shopAddres);
            Console.WriteLine("-----------------------------------");
            
            foreach (KeyValuePair<string, float> keyValue in purchases)
            {
                Console.WriteLine("{0:f2}        {1:f2}", keyValue.Key, keyValue.Value);
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Итого к оплате:      {0:f2}",summPurch);

            Console.Read();
        }

        /// <summary>Подсчет суммы покупок.</summary>
        /// <param name="purchases">Список покупок.</param>
        /// <returns>Итоговая сумма.</returns>
        private float Summ(Dictionary<string, float> purchases)
        {
            float summ=0;
            foreach (float buy in purchases.Values)
            {
                summ += buy;
            }
            return summ;
        }
    }
}
