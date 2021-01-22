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
            SeaBattle seaBattle = new SeaBattle();
            string[,] gameField = seaBattle.LoadField();

            int rndDirection;    //случайное направление
            int[] dotSpawn;

            Dictionary<int, int> ships = new Dictionary<int, int>();
            ships.Add(4, 1);    //key - ships count, value deck count
            ships.Add(3, 2);
            ships.Add(2, 3);
            ships.Add(1, 4);

            //Random random = new Random();
            
            foreach (KeyValuePair<int,int> ship in ships)
            {
                for(int i = 0; i<ship.Key; i++) //цикл по количеству определенных кораблей
                {
                    dotSpawn = seaBattle.DotSpawnShips();
                    

                }
            }
        }

        private string[,] LoadField()
        {
            string[,] gameField = new string[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gameField[i, j] == null || gameField[i, j] == ".")
                        gameField[i, j] = "O";
                }
            }
            return gameField;
        }

        private int[] DotSpawnShips()
        {
            Random random = new Random();
            int[] dot = new int[2];

            dot[0] = random.Next(0, 9);
            Thread.Sleep(20);
            dot[1] = random.Next(0, 9);

            return dot;
        }
    }
}
