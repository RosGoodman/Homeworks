using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    class SeaBattle
    {
        static void Main()
        {
            Dictionary<string, int> ships = new Dictionary<string, int>();
            ships.Add("four", 1);
            ships.Add("three", 2);
            ships.Add("two", 3);
            ships.Add("one", 4);

            foreach(var ship in ships.Keys)
            {
                Random random = new Random(2);
                int dir = random.Next(0, 100);
                Console.WriteLine(dir);
                await Task.Delay()
            }
        }
    }
}
