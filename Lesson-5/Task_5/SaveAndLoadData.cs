using System.IO;
using System.Runtime.Serialization;

namespace Task_5
{
    internal class SaveAndLoadData
    {
        /// <summary>Загрузить задачи.</summary>
        /// <returns>Класс со списком задач.</returns>
        internal Tasks LoadTasksXml()
        {
            Tasks tasks = new Tasks();
            if (File.Exists("tasks.xml"))
            {
                var xmlSerializer = new DataContractSerializer(typeof(Tasks));
                using (Stream s = File.OpenRead("tasks.xml"))
                    tasks = (Tasks)xmlSerializer.ReadObject(s);
            }

            return tasks;
        }

        /// <summary>Сохранить список задач.</summary>
        /// <param name="tasks">Класс со списком задач.</param>
        internal void SaveTasksXml(Tasks tasks)
        {
            var xmlSerializer = new DataContractSerializer(typeof(Tasks));
            using (Stream s = File.Create("tasks.xml"))
                xmlSerializer.WriteObject(s, tasks);
        }

    }
}
