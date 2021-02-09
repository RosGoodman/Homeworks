using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            int c = 2;
            decimal result = Calc(a, b, c);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        static decimal Calc(int a, int b, int c)
        {
            decimal result = a + b;
            result /= c;
            return result;
        }
    }
}
