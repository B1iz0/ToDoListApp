using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskManager.Model;
using TaskManager.ViewModels.Base;

namespace TaskManager.ViewModels
{
    internal class NotificationWindowViewModel : ViewModel
    {
        private ObservableCollection<Task> choosenTasks = new ObservableCollection<Task>();
        public IMainWindowsCodeBehind codeBehind;

        public ObservableCollection<Task> ChoosenTasks { get => choosenTasks; set => Set(ref choosenTasks, value); }

        public NotificationWindowViewModel() { }
        public NotificationWindowViewModel(IMainWindowsCodeBehind codeBehind)
        {
            this.codeBehind = codeBehind;
            foreach(Task task in this.codeBehind.GetNonPerfomedTasks())
            {
                if (task.Deadline.Date == DateTime.Now.Date) ChoosenTasks.Add(task);
            }
        }
    }
}
