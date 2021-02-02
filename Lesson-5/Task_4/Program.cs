using System;
using System.IO;
using System.Windows.Forms;

namespace Task_4
{
    class Program
    {
        //static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

        [STAThread]
        static void Main()
        {
            string directory = string.Empty;
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
                directory = FBD.SelectedPath;

            // Перечень всех файлов и папок, вложенных в workDir
            string[] entries = Directory.GetFileSystemEntries(directory, "*", SearchOption.AllDirectories);

            string v = string.Empty;
            string space = string.Empty;
            for (int i = 0; i < entries.Length; i++)
            {
                v = Path.GetExtension(entries[i]);
            }
        }
    }
}
