using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = UserInput();
            ulong[] fibNumbers = new ulong[length];

            fibNumbers[0] = 0;
            fibNumbers[1] = 1;
            if (length > 2) GetFibonacciNumb(ref fibNumbers, 2);

            PrintNumbers(fibNumbers);

            Console.Read();
        }

        /// <summary>Вычисление последовательности Фибоначчи.</summary>
        /// <param name="fibNumbers">Массив чисел.</param>
        /// <param name="i">Текущее кол-во чисел.</param>
        static void GetFibonacciNumb(ref ulong[] fibNumbers, int i)
        {
            fibNumbers[i] = fibNumbers[i-2] + fibNumbers[i - 1];
            if (++i != fibNumbers.Length) GetFibonacciNumb(ref fibNumbers, i);
        }

        /// <summary>Ввод с консоли.</summary>
        /// <returns>Длина последовательности.</returns>
        static private int UserInput()
        {
            int length = 0;
            do
            {
                if (length < 2) Console.WriteLine("Последовательность не может быть меньше 2.");
                Console.WriteLine("Введите желаемую длину последовательности Фибоначчи:");
                length = Convert.ToInt32(Console.ReadLine());
            } while (length < 2);

            return length;
        }

        /// <summary>Вывод в консоль.</summary>
        /// <param name="fibNumbers">Массив чисел.</param>
        static private void PrintNumbers(ulong[] fibNumbers)
        {
            for (int i = 0; i < fibNumbers.Length; i++)
            {
                Console.Write(fibNumbers[i] + " ");
            }
        }
    }
}
