using System;

namespace Task_1
{
    class AverageT
    {
        static void Main()
        {
            string str = "", str2="";
            float minT;
            float maxT;
            float aveT;

            do
            {
                if(str == "")
                {
                    Console.WriteLine("Введите минимальную суточную температуру C:");
                    str = Console.ReadLine();
                }
                if(str2 == "")
                {
                    Console.WriteLine("Введите максимальную суточную температуру C:");
                    str2 = Console.ReadLine();
                }
            }
            while (str == "" || str2 == "");

            minT = float.Parse(str);
            maxT = float.Parse(str2);

            if (maxT < minT)
            {
                Console.WriteLine("Максимальная температура не может быть меньше минимальной!");
                Main();
            }

            aveT = (minT + maxT) / 2;
            Console.WriteLine("Среднесуточная температура равна: {0:f1}C", aveT);
            Console.Read();
        }
    }
}
