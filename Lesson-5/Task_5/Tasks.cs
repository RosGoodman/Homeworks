using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Task_5
{
    /// <summary>Модель списка задач.</summary>
    [DataContract] public class Tasks
    {
        //[DataContract] и [DataMember] необходимы для сериализации через DataContractSerializer.
        [DataMember] private List<ToDo> _toDos = new List<ToDo>();

        internal List<ToDo> ToDos
        {
            get { return _toDos; }
            set { _toDos = value; }
        }

        internal Tasks()
        {
        }

        /// <summary>Добавить задачу.</summary>
        /// <param name="task">Задача.</param>
        internal void AddTask(ToDo task)
        {
            _toDos.Add(task);
        }
    }
}
