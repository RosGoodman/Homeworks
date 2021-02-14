using System;

namespace Task_1
{
    class Diagonal
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива:");
            int lenght = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Diagonal program = new Diagonal();
            int[,] rndArr = program.RandomArray(lenght);

            program.PrintDiagonal(rndArr);
            Console.ReadLine();
        }

        /// <summary>Печать диагонали массива.</summary>
        /// <param name="rndArr">Массив значений.</param>
        private void PrintDiagonal(int[,] rndArr)
        {
            Console.WriteLine();
            for (int i=0; i < rndArr.GetLength(0); i++)
            {
                Console.Write(rndArr[i,i] + " ");
                if (rndArr[i, i] < 10) Console.Write(" ");
            }
        }

        /// <summary>Получение двумерного массива установленного размера и с рандомными значениями.</summary>
        /// <param name="lenght">Длина массива.</param>
        /// <param name="width">Ширина массива.</param>
        /// <returns>Двумерный массив.</returns>
        private int[,] RandomArray(int lenght)
        {
            Random random = new Random();
            int[,] rndArr = new int[lenght, lenght];
            for(int i = 0; i<lenght; i++)
            {
                for(int j = 0; j< lenght; j++)
                {
                    rndArr[i, j] = random.Next(0, 100);
                    if (i == j) Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{rndArr[i,j]} ");    //вывод для наглядности
                    Console.ResetColor();
                    if (rndArr[i, j] < 10) Console.Write(" ");
                }
                Console.WriteLine();
            }
            return rndArr;
        }
    }
}
