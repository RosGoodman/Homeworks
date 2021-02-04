using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Task_4
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            string directory = UserInput();

            Cycle(directory);
            StartRecursiveMethod(directory);

            Console.WriteLine("Список файлов, полученный циклом записан в файл cycleTree.txt");
            Console.WriteLine("Список файлов, полученный рекурсией записан в файл recurcive.txt");
            Console.ReadLine();
        }

        #region Запрос пути к стартовой директории

        /// <summary>Получить путь к стартовой папке.</summary>
        /// <returns>Путь к папке.</returns>
        private static string UserInput()
        {
            Console.WriteLine("Введите путь к необходимой директории, для открытия диалога выбора директории просто нажмите enter.");

            string directory = Console.ReadLine();
            if (directory == "")
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                    directory = FBD.SelectedPath;
            }
            return directory;
        }

        #endregion

        #region Цикл

        /// <summary>Получить дерево каталогов с помощью цикла.</summary>
        /// <param name="entries">Путь к выбранной директории.</param>
        private static void Cycle(string directory)
        {
            string[] entries = Directory.GetFileSystemEntries(directory, "*", SearchOption.AllDirectories); //массив всех файлов и папок
            string[] files = new string[entries.Length * 2];        //массив для записи
            int directoryDepth = entries[0].Split('\\').Length;     //"глубина" выбранного каталога
            string space = "";                                      //отступы
            var parentPath = Directory.GetParent(entries[0]);
            int k = 0;      //счетчик для массива files

            for (int i = 0; i < entries.Length; i++)
            {
                var thisParent = Directory.GetParent(entries[i]);
                if (thisParent.Name != parentPath.Name)
                {
                    space = string.Empty;
                    for (int j = 0; j < (thisParent.FullName).Split('\\').Length - directoryDepth; j++)
                    {
                        space += "    ";
                    }
                    
                    files[++k] = space + Path.GetFileName(thisParent.FullName);
                    parentPath = thisParent;

                    space += "    ";
                }

                string[] dir = new string[0];
                string[] file = new string[0];
                if (Path.GetExtension(entries[i]) == "")
                {
                    dir = Directory.GetDirectories(entries[i]);
                    file = Directory.GetFiles(entries[i]);
                }

                if ((dir.Length == 0 && file.Length == 0) || Path.GetExtension(entries[i]) != "")    //проверка папки на наличие содержимого
                {
                    files[++k] = space + Path.GetFileName(entries[i]);
                }
            }
            File.WriteAllLines("cycleTree.txt", files);
        }

        #endregion

        #region Рекурсия

        /// <summary>Установка параметров для рекурсивного способа.</summary>
        /// <param name="directory">Начальная директория.</param>
        private static void StartRecursiveMethod(string directory)
        {
            List<string> allFiles = new List<string>();
            string spaces = "";
            Recursive(directory, ref allFiles, spaces);
            File.WriteAllLines("recursive.txt", allFiles);
        }

        /// <summary>Получить дерево каталогов и файлов с помощью рекурсии.</summary>
        /// <param name="directory">Путь к начальной директории.</param>
        /// <param name="allFiles">Список для записи.</param>
        /// <param name="spaces">Отступ от края.</param>
        private static void Recursive(string directory, ref List<string> allFiles, string spaces)
        {
            string[] dir = Directory.GetDirectories(directory);
            spaces += "   ";
            if (dir.Length > 0)
            {
                for (int i = 0; i < dir.Length; i++)    //проход по папкам
                {
                    allFiles.Add(spaces + Path.GetFileName(dir[i]));
                    string newDirectory = dir[i];
                    Recursive(newDirectory, ref allFiles, spaces);
                }
            }
            string[] files = Directory.GetFiles(directory);
            for (int j = 0; j < files.Length; j++)  //проход по файлам в текущей папке
            {
                allFiles.Add(spaces + Path.GetFileName(files[j]));
            }
        }

        #endregion
    }
}