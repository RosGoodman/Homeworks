using System;
using System.IO;
using System.Windows.Forms;

namespace Task_4
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Введите путь к необходимой директории, для открытия диалога выбора директории просто нажмите enter.");

            string directory = Console.ReadLine();
            if(directory == "")
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                    directory = FBD.SelectedPath;
            }

            string[] entries = Directory.GetFileSystemEntries(directory, "*", SearchOption.AllDirectories);
            //Cycle(entries);
            Recursive(directory);

            Console.WriteLine("Список файлов, полученный циклом записан в файл CycleTree.txt");
            Console.ReadLine();
        }

        #region Цикл

        /// <summary>Получить дерево каталогов с помощью цикла.</summary>
        /// <param name="entries">Список всех путей к вложенным файлам.</param>
        private static void Cycle(string[] entries)
        {
            string[] files = new string[entries.Length * 2];
            int directoryDepth = entries[0].Split('\\').Length;
            string space = "";
            var parentPath = Directory.GetParent(entries[0]);
            files[0] = Path.GetFileName(parentPath.Name);

            for (int i = 1; i < entries.Length; i++)
            {
                var thisParent = Directory.GetParent(entries[i]);
                if (thisParent.Name != parentPath.Name)
                {
                    space = string.Empty;
                    for (int j = 0; j < (thisParent.FullName).Split('\\').Length - directoryDepth; j++)
                    {
                        space += "    ";
                    }

                    files[i] = space + Path.GetFileName(thisParent.FullName);
                    parentPath = thisParent;

                    space += "    ";
                }

                files[i] = space + Path.GetFileName(entries[i]);
            }

            File.WriteAllLines("CycleTree.txt", files);
        }

        #endregion

        #region Рекурсия

        private static void Recursive(string directory)
        {
            string[] dir = Directory.GetDirectories(directory);
        }

        #endregion
    }
}