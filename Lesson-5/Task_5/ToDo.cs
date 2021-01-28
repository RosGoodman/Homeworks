
namespace Task_5
{
    internal class ToDo
    {
        private string _title = "задача";
        private bool _isDone = true;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
    }
}
