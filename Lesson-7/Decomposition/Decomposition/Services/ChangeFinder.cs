using System;
using System.Collections.Generic;
using System.IO;

namespace Decomposition.Services
{
    internal class ChangeFinder
    {
        private DateTime _lastChanges;
        private string[] _changes;

        /// <summary>Установка параметров для рекурсивного способа.</summary>
        /// <param name="directory">Начальная директория.</param>
        internal List<string> StartRecursiveMethod(string directory, DateTime lastChanges, string[] changes)
        {
            List<string> allFiles = new List<string>();
            _lastChanges = lastChanges;
            _changes = changes;

            Recursive(directory, ref allFiles);

            return allFiles;
        }

        /// <summary>Получить изменявшиеся файлы.</summary>
        /// <param name="directory">Путь к начальной директории.</param>
        /// <param name="allFiles">Список для записи.</param>
        private void Recursive(string directory, ref List<string> allFiles)
        {
            DateTime thisLastChanges = File.GetLastWriteTime(directory);
            DateTime childFolderChange;
            string[] dir = Directory.GetDirectories(directory);

            if (dir.Length > 0)
            {
                for (int i = 0; i < dir.Length; i++)    //проход по папкам
                {
                    childFolderChange = File.GetLastWriteTime(dir[i]);
                    if(childFolderChange > _lastChanges)
                    {
                        allFiles.Add(dir[i]);
                    }
                    
                    string newDirectory = dir[i];
                    Recursive(newDirectory, ref allFiles);
                }
            }

            if(thisLastChanges > _lastChanges)  //если последние изменения директории были после сохранения даты в настройках
            {
                string[] files = Directory.GetFiles(directory);
                string oldFile = string.Empty;
                for (int j = 0; j < files.Length; j++)  //проход по файлам в текущей папке
                {
                    //сравниваем сроки изменений, если файл старый, то, возможно скопирован => ищем в списке прошлых изменений
                    if(File.GetLastWriteTime(files[j]) > _lastChanges)
                    {
                        allFiles.Add(files[j]);
                    }
                    else
                    {
                        foreach(string file in _changes)
                        {
                            oldFile = file.Split(' ')[0];
                            if (oldFile == files[j])
                                continue;
                            else
                            {
                                allFiles.Add(files[j]);
                            }

                        }
                    }
                    
                }
            }
        }
    }
}
