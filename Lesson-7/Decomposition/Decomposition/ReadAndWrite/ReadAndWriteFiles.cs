using System.IO;

namespace Decomposition.ReadAndWrite
{
    internal class ReadAndWriteFiles
    {

        internal string[] ReadTxt(string fullFileName)
        {
            string[] lines = new string[0]; ;
            if (!(File.Exists(fullFileName)))
            {
                return lines;
            }

            return File.ReadAllLines(fullFileName);
        }
    }
}
