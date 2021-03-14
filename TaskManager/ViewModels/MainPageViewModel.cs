using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using TaskManager.Data;
using TaskManager.Infastructure.Commands;
using TaskManager.Model;
using TaskManager.ViewModels.Base;

namespace TaskManager.ViewModels
{
    internal class MainPageViewModel : ViewModel
    {
        public IMainWindowsCodeBehind codeBehind;
        private DataBase dataBase;
        public LambdaCommand toCreateTaskCommand;
        public LambdaCommand toPerformTaskCommand;
        private ObservableCollection<Task> tasks;
        private ObservableCollection<Task> perfomedTasks;
        private ObservableCollection<Task> nonPerfomedTasks;
        private CollectionViewSource tasksCollection;
        private string selectedSortFilter;
        private string filterText;
        private Task selectedTask;
        private Task selectedPerfomedTask;
        private string isVisiblePerform = "Hidden";
        private string isVisiblePerformAgain = "Hidden";

        public ObservableCollection<Task> Tasks { get => tasks; set => Set(ref tasks, value); }
        public ObservableCollection<Task> PerfomedTasks { get => perfomedTasks; set => Set(ref perfomedTasks, value); }
        public ObservableCollection<Task> NonPerfomedTasks { get => nonPerfomedTasks; set => Set(ref nonPerfomedTasks, value); }
        public Task SelectedTask { get => selectedTask; 
            set
            {
                Set(ref selectedTask, value);
                if (selectedTask != null)
                {
                    IsVisiblePerform = "Visible";
                }
            }
        }
        public Task SelectedPerfomedTask { get => selectedPerfomedTask;
            set
            {
                Set(ref selectedPerfomedTask, value);
                if (selectedPerfomedTask != null)
                {
                    IsVisiblePerformAgain = "Visible";
                }
            }
        }
        public LambdaCommand ToCreateTaskCommand { get => toCreateTaskCommand = new LambdaCommand(OnToCreateTaskCommandExecuted, CanToCreateTaskTaskCommandExecute); }
        public LambdaCommand ToPerformTaskCommand { get => toPerformTaskCommand = new LambdaCommand(OnToPerformTaskCommandExecuted, CanToPerformTaskCommandExecute); }
        public ICollectionView TasksCollection { get => this.tasksCollection.View; }
        public string SelectedSortFilter { get => selectedSortFilter; 
            set
            {
                Set(ref selectedSortFilter, value);
                if(tasksCollection != null && tasksCollection.SortDescriptions.Count == 1) tasksCollection.SortDescriptions.RemoveAt(0);
                switch (selectedSortFilter)
                {
                    case "0":
                        tasksCollection.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
                        break;
                    case "1":
                        tasksCollection.SortDescriptions.Add(new SortDescription("Deadline", ListSortDirection.Ascending));
                        break;
                    case "2":
                        tasksCollection.SortDescriptions.Add(new SortDescription("Importance", ListSortDirection.Ascending));
                        break;
                }
                tasksCollection.View.Refresh();
                codeBehind.SelectedIndexFilter = selectedSortFilter;
            }
        }
        public string FilterText { get => filterText; 
            set
            {
                Set(ref filterText, value);
                this.tasksCollection.View.Refresh();
            }
        }
        public string IsVisiblePerform { get => isVisiblePerform; set => Set(ref isVisiblePerform, value); }
        public string IsVisiblePerformAgain { get => isVisiblePerformAgain; set => Set(ref isVisiblePerformAgain, value); }

        public MainPageViewModel(IMainWindowsCodeBehind codeBehind, string selectedIndexFilter)
        {
            this.codeBehind = codeBehind;
            dataBase = codeBehind.GetDataBase();
            tasks = dataBase.Tasks;
            PerfomedTasks = codeBehind.GetPerfomedTasks();
            NonPerfomedTasks = codeBehind.GetNonPerfomedTasks();
            tasksCollection = new CollectionViewSource();
            tasksCollection.Source = nonPerfomedTasks;
            tasksCollection.Filter += tasksCollection_Filter;
            SelectedSortFilter = selectedIndexFilter;
        }

        #region ToCreateTaskCommand
        private bool CanToCreateTaskTaskCommandExecute(object p) => true;
        private void OnToCreateTaskCommandExecuted(object p)
        {
            codeBehind.LoadView(ViewType.TaskCreation);
        }
        #endregion
        #region ToPerformTaskCommand
        private bool CanToPerformTaskCommandExecute(object p) 
        {
            if (selectedTask == null) return false;
            return true;
        }
        private void OnToPerformTaskCommandExecuted(object p)
        {
            dataBase.Tasks.Single(s => s.Title == selectedTask.Title).IsPerfomed = true;
            IsVisiblePerform = "Hidden";
            for(int i = 0; i < NonPerfomedTasks.Count; i++)
            {
                if(selectedTask.Title == NonPerfomedTasks[i].Title)
                {
                    NonPerfomedTasks.RemoveAt(i);
                    break;
                }
            }
            PerfomedTasks = codeBehind.GetPerfomedTasks();
        }
        #endregion
        void tasksCollection_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            Task task = e.Item as Task;
            string tempTags = String.Empty;
            foreach(string temp in task.Tags)
            {
                tempTags += temp;
            }
            if (task.Title.ToUpper().Contains(FilterText.ToUpper()) || tempTags.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
    }
}
