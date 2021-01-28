using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task_5
{
    class Program
    {
        private string _addresFolder;
        static void Main(string[] args)
        {
            ToDo task = new ToDo();
            SaveTasksJson(task);

            List<ToDo> tasks = new List<ToDo>();
            LoadTasksJson(tasks);
        }

        private static void LoadTasksJson(List<ToDo> tasks)
        {
            string json = File.ReadAllText("tasks.json");
            ToDo task = JsonSerializer.Deserialize<ToDo>(json);
        }

        private static void LoadTasksXml(List<ToDo> tasks)
        {

        }

        private static void LoadTasksBin(List<ToDo> tasks)
        {

        }

        private static void SaveTasksJson(ToDo task)
        {
            string json = JsonSerializer.Serialize(task);
            File.WriteAllText("tasks.json", json);
        }

        private static void SaveTasksXml()
        {

        }

        private static void SaveTasksBin()
        {

        }
    }
}
