using System;
using System.IO;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = UserInput();
            byte[] numbersInt = ConvertToByte(numbers);
            WriteNumbInFile(numbersInt);

            Console.WriteLine("Готово!");
            Console.ReadLine();
        }

        /// <summary>Ввод в консоль.</summary>
        /// <returns>Полученная строка.</returns>
        private static string[] UserInput()
        {
            Console.WriteLine("Введите числа через пробел (0..255).");
            string[] numbers = Console.ReadLine().Split(' ');
            return numbers;
        }

        /// <summary>Конвертируем строку в байты.</summary>
        /// <param name="numbers">Массив чисел.</param>
        /// <returns>Массив чисел в byte.</returns>
        private static byte[] ConvertToByte(string[] numbers)
        {
            int numb;
            byte[] numbByte = new byte[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numb = Convert.ToInt32(numbers[i]);
                if (numb < 0 || numb > 255)
                {
                    Console.WriteLine("Число {0} не будет записано т.к. не соответствует требованиям.", numb);
                    continue;
                }
                numbByte[i] = Convert.ToByte(numb);
            }
            return numbByte;
        }

        /// <summary>Запись в файл .bin</summary>
        /// <param name="numbersInt">Записываемый массив байт.</param>
        private static void WriteNumbInFile(byte[] numbersInt)
        {
            File.WriteAllBytes("bytes.bin", numbersInt);
        }
    }
}
