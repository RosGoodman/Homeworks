using System;

namespace Task_3
{
    class Reverse
    {
        public static void Main()
        {
            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            Console.WriteLine(new string(array));
            Console.Read();
        }
    }
}
