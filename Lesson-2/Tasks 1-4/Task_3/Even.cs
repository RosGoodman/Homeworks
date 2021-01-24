using System;

namespace Task_3
{
    class Even
    {
        static void Main()
        {
            string numbOfUser = "";

            do
            {
                Console.WriteLine("Введите ваше число:");
                numbOfUser = Console.ReadLine();
            } while (numbOfUser == "");

            if(Convert.ToInt32(numbOfUser)%2 == 0)
                Console.WriteLine("Число {0} является четным", numbOfUser);
            else
                Console.WriteLine("Число {0} является нечетным", numbOfUser);

            Console.Read();
        }
    }
}
