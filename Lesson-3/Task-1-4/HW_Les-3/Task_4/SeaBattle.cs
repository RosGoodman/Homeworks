using System;
using System.Collections.Generic;

namespace Task_4
{
    class SeaBattle
    {
        static void Main()
        {
            SeaBattle seaBattle = new SeaBattle();
            FreeCells freeCells = new FreeCells();

            string[,] gameField = new string[10,10];
            seaBattle.LoadField(ref gameField);
            
            Dictionary<int, int> ships = seaBattle.CreateDictShips();
            
            foreach (KeyValuePair<int,int> ship in ships)
            {
                for(int i = 0; i<ship.Value; i++) //цикл по количеству определенных кораблей
                {
                    seaBattle.DotSpawnShips(ref gameField, ship);
                }
            }

            seaBattle.LoadField(ref gameField);
            seaBattle.PrintGame(gameField);
            Console.Read();
        }

        #region Словарь кораблей
        /// <summary>Создание словаря кораблей.</summary>
        /// <returns>Словарь кораблей(тип/кол-во)</returns>
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

        #region Заполняем пустое "водой"
        /// <summary>Заполнить массив "водой".</summary>
        /// <returns>Массив строк.</returns>
        private void LoadField(ref string[,] gameField)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gameField[i, j] != "X")
                    {
                        gameField[i, j] = "O";
                    }
                }
            }
        }
        #endregion

        #region Рандом точки спавна
        /// <summary>Выбор точки спавна по словарю свободных ячеек.</summary>
        /// <param name="gameField">Игровое поле (массив).</param>
        /// <param name="ship">Текущая пара (корабль/кол-во) словаря.</param>
        private void DotSpawnShips(ref string[,] gameField, KeyValuePair<int, int> ship)
        {
            Random random = new Random();
            int[] dot = new int[3];     //ox,oy,direction

            do
            {
                dot[0] = random.Next(0, FreeCells.FreeCellsDict.Count);     //ox
                dot[1] = random.Next(0, 99);     //0-horisontal, 1-vertical
                
            } while (!ChekFieldRecField(ref gameField, dot, ship));

            ChekFieldRecField(ref gameField, dot, ship, true);
        }
        #endregion

        #region Генерация кораблей
        /// <summary>Генерация кораблей.</summary>
        /// <param name="gameField">Игровое поле.</param>
        /// <param name="dot">Точка спавна и направление.</param>
        /// <param name="ship">Текущая пара (корабль/кол-во).</param>
        /// <param name="recording">Спавн или проверка свободного места на поле. True - спавн.</param>
        /// <returns>Результат проверки. Подошла ли точка спавна.</returns>
        private bool ChekFieldRecField(ref string[,] gameField, int[] dot, KeyValuePair<int, int> ship, bool recording = false)
        {
            int axis1 = (dot[0] % 10) - 1;  //ox
            int axis2 = (dot[0] / 10) - 1;  //oy
            if (axis1 < 0 || axis1 > 9 || axis2 < 0 || axis2 > 9) return false;

            for (int i = axis1; i < ship.Key + axis1; i++)  //вдоль корабля
            {
                int[] axis;

                if (i > 9) return false;                //выход за границу поля
                for (int j = i - 1; j < i + 2; j++)     //ячейки вокруг корабля
                {
                    if (j < 0 || j > 9) continue;       //выход за границу - след. итерация
                    for (int k = axis2 - 1; k < axis2 + 2; k++)
                    {
                        if (k < 0 || k > 9) continue;   //если выход за границы

                        axis = RotationAxis(j, k, dot[1]);

                        #region проверка перед записью
                        if (gameField[axis[0], axis[1]] != "X" && !recording)   //если не запись, то проверяем место на поле
                            continue;
                        else if (gameField[axis[0], axis[1]] == "X" && !recording)
                            return false;
                        #endregion

                        if (gameField[axis[0], axis[1]] != "X") gameField[axis[0], axis[1]] = ".";
                        FreeCells.FreeCellsDict.Remove(dot[0]);
                    }
                }
                axis = RotationAxis(i, axis2, dot[1]);

                if (recording) gameField[axis[0], axis[1]] = "X";
                FreeCells.FreeCellsDict.Remove(dot[0]);
            }
            return true;
        }
        #endregion

        #region Перестановка переменных
        /// <summary>Перестановка переменных в зависимости от напраления.</summary>
        /// <param name="ox">Координата 1.</param>
        /// <param name="oy">Координата 2.</param>
        /// <param name="direct">Значение направления (0-99).</param>
        /// <returns>Координаты по осям.</returns>
        private int[] RotationAxis(int ox, int oy, int direct)
        {
            int[] axis = new int[2];
            int z;
            if (direct > 49)
            {
                z = ox;
                axis[0] = oy;
                axis[1] = z;
            }
            else
            {
                axis[0] = ox;
                axis[1] = oy;
            }
            return axis;
        }
        #endregion

        #region Вывод массива
        /// <summary>Вывод масива в консоль.</summary>
        /// <param name="gameField">Массив игрового поля.</param>
        private void PrintGame(string[,] gameField)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gameField[i, j] == "O")
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    else
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(gameField[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion
    }

    #region Класс учета свободных ячеек
    /// <summary>Класс учета свободных ячеек.</summary>
    public class FreeCells
    {
        /// <summary>Словарь свободных ячеек.</summary>
        public static Dictionary<int, int> FreeCellsDict { get; set; }

        public FreeCells()
        {
            FreeCellsDict = CreateDictFreeCells();
        }

        /// <summary>Метод генерации словаря.</summary>
        /// <returns>Словарь свободных ячеек.</returns>
        private Dictionary<int, int> CreateDictFreeCells()
        {
            Dictionary<int, int> freeCells = new Dictionary<int, int>();
            for (int i = 0; i < 100; i++)
            {
                freeCells.Add(i, i);
            }
            return freeCells;
        }

        /// <summary>Удаление использованной ячейки.</summary>
        /// <param name="cellKey">Ключ ячейки в словаре.</param>
        public void DelCell(int cellKey)
        {
            FreeCellsDict.Remove(cellKey);
        }
    }
    #endregion
}
