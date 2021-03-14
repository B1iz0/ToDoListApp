using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using TaskManager.Data;
using TaskManager.Infastructure.Commands;
using TaskManager.Model;
using TaskManager.ViewModels.Base;

namespace TaskManager.ViewModels
{
    class TaskCreationViewModel : ViewModel
    {
        public IMainWindowsCodeBehind codeBehind;
        private DataBase dataBase;
        private LambdaCommand backToMainPageCommand;
        private LambdaCommand createNewTaskCommand;
        private LambdaCommand radioButtonCheckedCommand;
        private LambdaCommand checkTagsForValidCommand;
        private DegreeOfImportance taskImportance;
        private string taskTitle = String.Empty;
        private DateTime taskDeadline = DateTime.Now;
        private string taskDescription = String.Empty;
        private string taskTags = String.Empty;
        private string tagsTextBoxColor = "Gray";

        public string TaskTitle { get => taskTitle; set => Set(ref taskTitle, value); }
        public DateTime TaskDeadline { get => taskDeadline; set => Set(ref taskDeadline, value); }
        public string TaskDescription { get => taskDescription; set => Set(ref taskDescription, value); }
        public LambdaCommand BackToMainPageCommand { get => backToMainPageCommand = new LambdaCommand(OnBackToMainPageCommandExecuted, CanBackToMainPageCommandExecute); }
        public LambdaCommand CreateNewTaskCommand { get => createNewTaskCommand = new LambdaCommand(OnCreateNewTaskCommandExecuted, CanCreateNewTaskCommandExecute); }
        public LambdaCommand RadioButtonCheckedCommand { get => radioButtonCheckedCommand = new LambdaCommand(OnRadioButtonCheckedCommandExecuted, CanRadioButtonCheckedCommandExecute); }
        public DegreeOfImportance TaskImportance { get => taskImportance; set => Set(ref taskImportance, value); }
        public string TaskTags { get => taskTags; set => Set(ref taskTags, value); }
        public LambdaCommand CheckTagsForValidCommand { get => checkTagsForValidCommand = new LambdaCommand(OnCheckTagsForValidCommandExecuted, CanCheckTagsForValidCommandExecute); }
        public string TagsTextBoxColor { get => tagsTextBoxColor; set => Set(ref tagsTextBoxColor, value); }

        public TaskCreationViewModel(IMainWindowsCodeBehind codeBehind)
        {
            this.codeBehind = codeBehind;
            dataBase = codeBehind.GetDataBase();
        }

        private bool CanBackToMainPageCommandExecute(object p) => true;

        private void OnBackToMainPageCommandExecuted(object p)
        {
            codeBehind.LoadView(ViewType.Main);
        }

        private bool CanCreateNewTaskCommandExecute(object p)
        {
            if (taskTitle == String.Empty || tagsTextBoxColor == "Red") return false;
            return true;
        }

        private void OnCreateNewTaskCommandExecuted(object p)
        {
            if (taskTitle != String.Empty && !dataBase.IsThereSuchName(taskTitle))
            {
                dataBase.Tasks.Add(new Task(taskTitle, taskDeadline, taskDescription, taskImportance, taskTags));
                DataBaseBuilder.loadToFile(dataBase);
                codeBehind.LoadView(ViewType.Main);
            } 
            else
            {
                if(taskTitle == String.Empty)
                {
                    MessageBox.Show("Имя задания не может быть пустым", "Ошибка при вводе имени",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Такое задание уже существует", "Ошибка при вводе имени",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private bool CanRadioButtonCheckedCommandExecute(object p) => true;

        private void OnRadioButtonCheckedCommandExecuted(object p)
        {
            switch (p.ToString())
            {
                case "Immediate":
                    taskImportance = DegreeOfImportance.Immediate;
                    break;
                case "Important":
                    taskImportance = DegreeOfImportance.Important;
                    break;
                case "NonUrgent":
                    taskImportance = DegreeOfImportance.NonUrgent;
                    break;
            }
        }

        private bool CanCheckTagsForValidCommandExecute(object p) => true;

        private void OnCheckTagsForValidCommandExecuted(object p)
        {
            Regex regex = new Regex(@"(#(\w)+,? *)+");
            MatchCollection matches = regex.Matches(TaskTags);
            string temp = String.Empty;
            foreach(Match tag in matches)
            {
                temp += tag;
            }
            if(temp != taskTags)
            {
                TagsTextBoxColor = "Red";
            }
            else
            {
                TagsTextBoxColor = "Gray";
            }
        }
    }
}
