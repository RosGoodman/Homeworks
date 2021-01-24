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
            string[,] gameField = seaBattle.LoadField();

            Dictionary<int, int> ships = new Dictionary<int, int>();
            ships.Add(4, 1);    //key - ships count, value deck count
            ships.Add(3, 2);
            ships.Add(2, 3);
            ships.Add(1, 4);
            
            foreach (KeyValuePair<int,int> ship in ships)
            {
                for(int i = 0; i<ship.Key; i++) //цикл по количеству определенных кораблей
                {
                    seaBattle.DotSpawnShips(ref gameField, ship);
                }
            }

            for(int i = 0; i<10; i++)
            {
                for(int j = 0; j<10; j++)
                {
                    Console.Write(gameField[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
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

        private void DotSpawnShips(ref string[,] gameField, KeyValuePair<int, int> ship)
        {
            Random random = new Random();
            int[] dot = new int[3];     //ox,oy,direction

            do
            {
                dot[2] = random.Next(0, 1);     //0-horisontal, 1-vertical
                Thread.Sleep(20);
                dot[0] = random.Next(0, 9);     //ox
                Thread.Sleep(20);
                dot[1] = random.Next(0, 9);     //oy
            } while (!ChekFieldRecField(ref gameField, dot, ship));

            ChekFieldRecField(ref gameField, dot, ship, true);
        }

        private bool ChekFieldRecField(ref string[,] gameField, int[] dot, KeyValuePair<int, int> ship, bool recording=false)
        {
            if (gameField[dot[0], dot[1]] != "O") return false;

            int axis1=dot[0];
            int axis2=dot[1];

            if (dot[2] == 1)    //если вертикальное направление - меняем оси, чтоб не дублировать код
            {
                axis1 = dot[1];
                axis2 = dot[0];
            }

            for (int i = axis1; i < ship.Key; i++)  //вдоль корабля
            {
                if (i > 9) return false;    //выход за границу поля
                for (int j = 0; j < 3; j++)    //ячейки вокруг корабля
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (gameField[j, k] != gameField[i, axis2] && gameField[j, k] != "X")  //если в своем окружении нет корабля
                        {
                            if (recording) gameField[j,k] = ".";
                            break;
                        }
                        else if (gameField[j, k] == gameField[i, axis2] && gameField[j, k] != ".")   //если не попадает в окружение другого корабля
                        {
                            if (recording) gameField[j, k] = "X";
                            break;
                        }
                        else
                            return false;
                    }
                }
            }
            return true;
        }

        //private bool ThereIsPlace(string[,] gameField, int[] dot, KeyValuePair<int, int> ship)
        //{
        //    if (gameField[dot[0], dot[1]] != "O") return false;

        //    if (dot[2] == 0) //горизонталь
        //    {
        //        for(int i = dot[0]; i < ship.Key; i++)  //вдоль корабля
        //        {
        //            if (i > 9) return false;    //выход за границу поля
        //            for(int j = 0; j<3; j++)    //ячейки вокруг корабля
        //            {
        //                for(int k = 0; k<3; k++)
        //                {
        //                    if (gameField[j, k] != gameField[i, dot[1]] && gameField[j, k] != "X")  //если в своем окружении нет корабля
        //                        break;
        //                    else if (gameField[j, k] == gameField[i, dot[1]] && gameField[j, k] != ".")   //если не попадает в окружение другого корабля
        //                        break;
        //                    else
        //                        return false;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = dot[1]; i < ship.Key; i++)  //вдоль корабля
        //        {
        //            if (i > 9) return false;    //выход за границу поля
        //            for (int j = 0; j < 3; j++)    //ячейки вокруг корабля
        //            {
        //                for (int k = 0; k < 3; k++)
        //                {
        //                    if (gameField[j, k] != gameField[i, dot[0]] && gameField[j, k] != "X")  //если в своем окружении нет корабля
        //                        break;
        //                    else if (gameField[j, k] == gameField[i, dot[0]] && gameField[j, k] != ".")   //если не попадает в окружение другого корабля
        //                        break;
        //                    else
        //                        return false;
        //                }
        //            }
        //        }
        //    }
        //    return true; //todo d't remamber
        //}
    }
}
