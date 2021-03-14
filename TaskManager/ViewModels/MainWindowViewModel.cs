using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.ViewModels.Base;
using TaskManager.Data;
using System.Collections.ObjectModel;
using TaskManager.Model;
using System.Windows.Input;
using TaskManager.Infastructure.Commands;

namespace TaskManager.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        public IMainWindowsCodeBehind codeBehind;

        private DataBase database;

        #region Task list
        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks { get => tasks; set => Set(ref tasks, value); }
        #endregion

        #region Window title
        private string title = "Task Manager";
        public string Title { get => title; set => Set(ref title, value); }
        #endregion

        #region Commands



        #endregion

        public MainWindowViewModel(IMainWindowsCodeBehind codeBehind) 
        {
            //Исправить создание базы данных
            DataBase data = new DataBase(DataBaseBuilder.loadFromFile());
            this.database = data;
            Tasks = this.database.Tasks;
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));
            this.codeBehind = codeBehind;
            database = codeBehind.GetDataBase();
        }
    }
}
