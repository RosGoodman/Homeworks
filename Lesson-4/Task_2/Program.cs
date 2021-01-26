using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbersStr = Console.ReadLine().Split(' ');
            int[] numbers = new int[numbersStr.Length];
            numbers = ConvertStringToInt(numbersStr);
            PrintArray(numbers);

            Console.Read();
        }

        /// <summary>Конвертация массива строк в числа.</summary>
        /// <param name="numbersStr">Массив строк.</param>
        /// <returns>Массив чисел.</returns>
        static private int[] ConvertStringToInt(string[] numbersStr)
        {
            int[] numbers = new int[numbersStr.Length];
            for (int i = 0; i < numbersStr.Length; i++)
            {
                numbers[i] = Convert.ToInt32(numbersStr[i]);
            }
            return numbers;
        }

        /// <summary>Вывод на консоль массива.</summary>
        /// <param name="numbers">Массив чисел.</param>
        static private void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
