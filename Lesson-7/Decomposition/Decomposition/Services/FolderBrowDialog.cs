using System.Windows.Forms;

namespace Decomposition.Services
{
    internal class FolderBrowDialog
    {
        /// <summary>Диалог выбора папки.</summary>
        /// <returns>Путь квыбранной папке.</returns>
        internal string GetFolderPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            return string.Empty;
        }
    }
}
