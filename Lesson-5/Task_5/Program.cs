using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;

namespace Task_5
{
    class Program
    {
        private string _addresFolder;
        static void Main(string[] args)
        {
            ToDo task = new ToDo();
            SaveTasksJson(task);

            SaveTasksXml(task);

            List<ToDo> tasks = new List<ToDo>();
            LoadTasksJson(tasks);
            LoadTasksXml(tasks);

            Console.ReadLine();
        }

        private static void LoadTasksJson(List<ToDo> tasks)
        {
            string json = File.ReadAllText("tasks.json");
            ToDo task = JsonSerializer.Deserialize<ToDo>(json);

            PrintTasks(task, "json");
        }

        private static void LoadTasksXml(List<ToDo> tasks)
        {
            string xml = File.ReadAllText("tasks.xml");

        }

        private static void LoadTasksBin(List<ToDo> tasks)
        {

        }

        private static void SaveTasksJson(ToDo task)
        {
            string json = JsonSerializer.Serialize(task);
            File.WriteAllText("tasks.json", json);
        }

        private static void SaveTasksXml(ToDo task)
        {
            StringWriter stringWriter = new StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo));
            xmlSerializer.Serialize(stringWriter, task);
            string xml = stringWriter.ToString();
            File.WriteAllText("tasks.xml", xml);
        }

        private static void SaveTasksBin()
        {

        }

        private static void PrintTasks(ToDo task, string fileName)
        {
            System.Console.WriteLine("{0} - {1}. Загружено из файла формата {3}", task.Title, task.IsDone, fileName);
        }
    }
}
