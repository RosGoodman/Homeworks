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
            string directory = string.Empty;
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
                directory = FBD.SelectedPath;

            // Перечень всех файлов и папок, вложенных в workDir
            string[] entries = Directory.GetFileSystemEntries(directory, "*", SearchOption.AllDirectories);

            int spaces = entries[0].Split('\\').Length;
            string space = "";
            var parentPath = Directory.GetParent(entries[0]);
            Console.WriteLine(Path.GetFileName(parentPath.Name));
            for (int i = 1; i < entries.Length; i++)
            {
                var thisParent = Directory.GetParent(entries[i]);
                if (thisParent.Name != parentPath.Name)
                {
                    space = string.Empty;
                    for (int j = 0; j < (parentPath.FullName).Split('\\').Length - spaces; j++)
                    {
                        space += "    ";
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(space + Path.GetFileName(thisParent.FullName));
                    Console.ResetColor();
                    parentPath = thisParent;

                    space += "    ";
                }

                Console.WriteLine(space + Path.GetFileName(entries[i]));
            }
            Console.ReadLine();
        }
    }
}