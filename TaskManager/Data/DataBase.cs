using System;
using System.Collections.ObjectModel;
using TaskManager.Model;

namespace TaskManager.Data
{
    public class DataBase
    {
        private ObservableCollection<Task> tasks = new ObservableCollection<Task>();

        public ObservableCollection<Task> Tasks { get => tasks; set { if (value != null) tasks = value; } }

        public DataBase() { }
        public DataBase(ObservableCollection<Task> tasks)
        {
            this.tasks = tasks;
        }
        public DataBase(DataBase data)
        {
            Tasks = data.Tasks;
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }
        public bool RemoveTask(Task task)
        {
            foreach(Task tempTask in tasks)
            {
                if(tempTask.Title == task.Title)
                {
                    tasks.Remove(tempTask);
                    return true;
                }
            }
            return false;
        }
        public bool IsThereSuchName(string name)
        {
            foreach(Task task in tasks)
            {
                if (task.Title == name) return true;
            }
            return false;
        }
        public ObservableCollection<Task> GetPerfomedTasks()
        {
            ObservableCollection<Task> perfomedTasks = new ObservableCollection<Task>();
            foreach(Task task in tasks)
            {
                if (task.IsPerfomed) perfomedTasks.Add(task);
            }
            return perfomedTasks;
        }
        public ObservableCollection<Task> GetNonPerfomedTasks()
        {
            ObservableCollection<Task> perfomedTasks = new ObservableCollection<Task>();
            foreach (Task task in tasks)
            {
                if (!task.IsPerfomed) perfomedTasks.Add(task);
            }
            return perfomedTasks;
        }
        public override string ToString()
        {
            string result = String.Empty;
            if(tasks != null)
            {
                foreach (Task task in tasks)
                {
                    result += task.Title;
                }
            }
            return result;
        }
    }
}
