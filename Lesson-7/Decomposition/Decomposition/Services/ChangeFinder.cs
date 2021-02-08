using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Decomposition.Services
{
    internal class ChangeFinder
    {
        /// <summary>Установка параметров для рекурсивного способа.</summary>
        /// <param name="directory">Начальная директория.</param>
        internal static List<string> StartRecursiveMethod(string directory)
        {
            List<string> allFiles = new List<string>();
            string spaces = "";
            Recursive(directory, ref allFiles, spaces);
            return allFiles;
            
            //File.WriteAllLines("recursive.txt", allFiles);
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
    }
}
