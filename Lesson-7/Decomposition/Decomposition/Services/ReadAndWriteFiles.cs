using System.Collections.Generic;
using System.IO;

namespace Decomposition.ReadAndWrite
{
    /// <summary>Чтение и запись файлов.</summary>
    internal class ReadAndWriteFiles
    {
        /// <summary>Чтение txt файла.</summary>
        /// <param name="fullFileName">Путь к файлу.</param>
        /// <returns>Массив строк.</returns>
        internal string[] ReadTxt(string fullFileName)
        {
            string[] lines = new string[0]; ;
            if (!(File.Exists(fullFileName)))
            {
                return lines;
            }

            return File.ReadAllLines(fullFileName);
        }

        /// <summary>Запись строк в txt.</summary>
        /// <param name="lines">Массив строк.</param>
        /// <param name="path">Путь к файлу.</param>
        internal void WriteTxt(string[] lines, string path)
        {
            File.WriteAllLines(path, lines);
        }

        /// <summary>Дописать в файл сроки.</summary>
        /// <param name="lines">Список строк.</param>
        /// <param name="path">Путь к файлу.</param>
        internal void AppendTxt(List<string> lines, string path)
        {
            File.AppendAllLines(path, lines);
        }
    }
}
