using System;
using System.Runtime.Serialization;

namespace Task_5
{
    /// <summary>Модель задачи.</summary>
    [DataContract] internal class ToDo
    {
        [DataMember] private string _title = string.Empty;
        [DataMember] private bool _isDone = false;

        /// <summary>Задача.</summary>
        internal string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>Состояние задачи.</summary>
        internal bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }

        internal ToDo(string title)
        {
            Title = title;
        }
    }
}
