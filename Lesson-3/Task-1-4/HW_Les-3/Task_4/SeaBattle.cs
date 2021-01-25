using System;
using System.Collections.Generic;
using System.Threading;

namespace Task_4
{
    class SeaBattle
    {
        static void Main()
        {
            SeaBattle seaBattle = new SeaBattle();
            object[] gameField = seaBattle.LoadField();
            Dictionary<int, int> freeCells = seaBattle.CreateDictFreeCells();
            Dictionary<int, int> ships = seaBattle.CreateDictShips();
            
            foreach (KeyValuePair<int,int> ship in ships)
            {
                for(int i = 0; i<ship.Value; i++) //цикл по количеству определенных кораблей
                {
                    seaBattle.DotSpawnShips(ref gameField, ship, freeCells);
                }
            }

            for(int i = 0; i<10; i++)
            {
                for(int j = 0; j<10; j++)
                {
                    //Console.Write(gameField[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.Read();
        }

        #region Словарь кораблей
        private Dictionary<int,int> CreateDictShips()
        {
            Dictionary<int, int> ships = new Dictionary<int, int>();
            ships.Add(4, 1);    //key - deck count, value - ships count
            ships.Add(3, 2);
            ships.Add(2, 3);
            ships.Add(1, 4);
            return ships;
        }
        #endregion

        #region Заполняем пустое поле "водой"
        /// <summary>Получаем массив горизонталей с ключами.</summary>
        /// <returns>Массив строк.</returns>
        private object[] LoadField()
        {
            object[] gameField = new object[10];
            for (int i = 0; i < 10; i++)
            {
                List<int> str = new List<int>();
                for (int j = 0; j < 10; j++)
                {
                    str.Add(j);
                }
                gameField[i] = str;
            }
            return gameField;
        }
        #endregion

        #region словарь свободных ячеек поля
        private Dictionary<int,int> CreateDictFreeCells()
        {
            Dictionary<int, int> freeCells = new Dictionary<int, int>();
            for (int i = 0; i < 100; i++)
            {
                freeCells.Add(i, i);
            }
            return freeCells;
        }
        #endregion

        private void DotSpawnShips(ref object[] gameField, KeyValuePair<int, int> ship, Dictionary<int,int> freeCells)
        {
            Random random = new Random();
            int[] dot = new int[3];     //ox,oy,direction

            do
            {
                dot[0] = random.Next(0, freeCells.Count);     //ox
                //Thread.Sleep(20);
                dot[1] = random.Next(0, 1);     //0-horisontal, 1-vertical
                
            } while (!ChekFieldRecField(ref gameField, dot, ship));

            ChekFieldRecField(ref gameField, dot, ship, true);
            PasteValInArr(gameField);
        }

        private bool ChekFieldRecField(ref object[] gameField, int[] dot, KeyValuePair<int, int> ship, bool recording=false)
        {
            int axis1 = (dot[0] % 10) - 1 + ship.Key;   //ox
            int axis2 = (dot[0] - (dot[0] % 10)) - 1;
            //int axis1=dot[0];
            //int axis2=dot[1];

            //for (int i = axis1; i < ship.Key+axis1; i++)  //вдоль корабля
            //{
            //    int ox = 0;
            //    int oy = 0;

            //    if (i > 9) return false;    //выход за границу поля
            //    for (int j = i-1; j < i+2; j++)    //ячейки вокруг корабля
            //    {
            //        if (j < 0 || j > 9) continue;
            //        for (int k = axis2-1; k < axis2+2; k++)
            //        {
            //            if (k < 0 || k > 9) continue;   //если выход за границы

            //            ox = j;
            //            oy = k;

            //            if (dot[2] == 0)
            //            {
            //                ox = k;
            //                oy = j;
            //            }

            //            #region проверка перед записью
            //            if (gameField[ox, oy] != "X" && !recording)   //если не запись, то проверяем место на поле
            //                continue; 
            //            else if(gameField[ox, oy] == "X" && !recording)
            //                return false;
            //            #endregion

            //            //PasteValInArr(ref gameField, j, k, dot[2], ".");
            //            if (gameField[ox, oy] != "X") gameField[ox, oy] = ".";
            //        }
            //    }
            //    //if (recording) PasteValInArr(ref gameField, i, axis2, dot[2], "X");
            //    ox = i;
            //    oy = axis2;
            //    if (dot[2] == 0)
            //    {
            //        ox = axis2;
            //        oy = i;
            //    }

            //    if (recording) gameField[ox, oy] = "X";
            //}
            return true;
        }

        private void PasteValInArr(object[] gameField)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //Console.Write(gameField[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
