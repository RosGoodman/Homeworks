using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process p in processes)
            {
                Console.WriteLine("     {0}      {1}",p.Id ,p.ProcessName);
            }
            Console.ReadLine();
        }
    }
}
