using System;
using System.Collections.Generic;
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
    class TaskInformationViewModel : ViewModel
    {
        public IMainWindowsCodeBehind codeBehind;
        private LambdaCommand backToMainPageCommand;
        private LambdaCommand changeInformationCommand;
        private LambdaCommand saveChangesCommand;
        private LambdaCommand deleteTaskCommand;
        private LambdaCommand checkTagsForValidCommand;
        private Task task;
        private string firstTaskTitle;
        private string taskTitle;
        private string taskDescription;
        private DateTime deadline;
        private DegreeOfImportance taskImportance;
        private string taskTags;
        private string changeButtonVisibility = "Visible";
        private string saveButtonVisibility = "Hidden";
        private string isEnableTitle = "false";
        private string isEnableDescription = "false";
        private string isEnableTags = "false";
        private string isEnableDeadline = "false";
        private string isEnableImportance = "false";
        private string isCheckedImmediate = "false";
        private string isCheckedImportant = "true";
        private string isCheckedNonUrgent = "false";
        private string isCheckedPerformAgain = "false";
        private string isEnablePerformAgain = "false";
        private string tagsTextBoxColor = "Gray";

        public string TaskTitle { get => taskTitle; set => Set(ref taskTitle, value); }
        public string TaskDescription { get => taskDescription; set => Set(ref taskDescription, value); }
        public DateTime Deadline { get => deadline; set => Set(ref deadline, value); }
        public string TaskTags { get => taskTags; set => Set(ref taskTags, value); }
        public string ChangeButtonVisibility { get => changeButtonVisibility; set => Set(ref changeButtonVisibility, value); }
        public string SaveButtonVisibility { get => saveButtonVisibility; set => Set(ref saveButtonVisibility, value); }
        public string IsEnableTitle { get => isEnableTitle; set => Set(ref isEnableTitle, value); }
        public string IsEnableDescription { get => isEnableDescription; set => Set(ref isEnableDescription, value); }
        public string IsEnableTags { get => isEnableTags; set => Set(ref isEnableTags, value); }
        public string IsEnableDeadline { get => isEnableDeadline; set => Set(ref isEnableDeadline, value); }
        public string IsEnableImportance { get => isEnableImportance; set => Set(ref isEnableImportance, value); }
        public LambdaCommand BackToMainPageCommand { get => backToMainPageCommand = new LambdaCommand(OnBackToMainPageCommandExecuted, CanBackToMainPageCommandExecute); }
        public LambdaCommand ChangeInformationCommand { get => changeInformationCommand = new LambdaCommand(OnChangeInformationCommandExecuted, CanChangeInformationCommandExecute); }
        public LambdaCommand SaveChangesCommand { get => saveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted, CanSaveChangesCommandExecute); }
        public LambdaCommand DeleteTaskCommand { get => deleteTaskCommand = new LambdaCommand(OnDeleteTaskCommandExecuted, CanDeleteTaskCommandExecute); }
        public LambdaCommand CheckTagsForValidCommand { get => checkTagsForValidCommand = new LambdaCommand(OnCheckTagsForValidCommandExecuted, CanCheckTagsForValidCommandExecute); }

        public DegreeOfImportance TaskImportance { get => taskImportance; 
            set
            {
                Set(ref taskImportance, value);
                switch (taskImportance)
                {
                    case DegreeOfImportance.Immediate:
                        IsCheckedImmediate = "true";
                        IsCheckedImportant = "false";
                        IsCheckedNonUrgent = "false";
                        break;
                    case DegreeOfImportance.Important:
                        IsCheckedImmediate = "false";
                        IsCheckedImportant = "true";
                        IsCheckedNonUrgent = "false";
                        break;
                    case DegreeOfImportance.NonUrgent:
                        IsCheckedImmediate = "false";
                        IsCheckedImportant = "false";
                        IsCheckedNonUrgent = "true";
                        break;
                }
            }
        }
        public string IsCheckedImmediate { get => isCheckedImmediate; set => Set(ref isCheckedImmediate, value); }
        public string IsCheckedImportant { get => isCheckedImportant; set => Set(ref isCheckedImportant, value); }
        public string IsCheckedNonUrgent { get => isCheckedNonUrgent; set => Set(ref isCheckedNonUrgent, value); }
        public string TagsTextBoxColor { get => tagsTextBoxColor; set => Set(ref tagsTextBoxColor, value); }
        public string IsCheckedPerformAgain { get => isCheckedPerformAgain; set => Set(ref isCheckedPerformAgain, value); }
        public string IsEnablePerformAgain { get => isEnablePerformAgain; set => Set(ref isEnablePerformAgain, value); }

        public TaskInformationViewModel(IMainWindowsCodeBehind codeBehind, Task aim)
        {
            this.codeBehind = codeBehind;
            this.task = aim;
            firstTaskTitle = aim.Title;
            TaskTitle = aim.Title;
            TaskDescription = aim.Description;
            Deadline = aim.Deadline;
            TaskImportance = aim.Importance;
            foreach(string temp in aim.Tags)
            {
                TaskTags += temp + " ";
            }
        }

        #region BackToMainPageCommand
        private bool CanBackToMainPageCommandExecute(object p) => true;

        private void OnBackToMainPageCommandExecuted(object p)
        {
            codeBehind.LoadView(ViewType.Main);
        }
        #endregion
        #region ChangeInformationCommand
        private bool CanChangeInformationCommandExecute(object p) => true;

        private void OnChangeInformationCommandExecuted(object p)
        {
            IsEnableDeadline = "True";
            IsEnableTitle = "True";
            IsEnableDescription = "True";
            IsEnableTags = "True";
            IsEnableImportance = "True";
            if (task.IsPerfomed)
            {
                IsEnablePerformAgain = "True";
            }
            ChangeButtonVisibility = "Hidden";
            SaveButtonVisibility = "Visible";
        }
        #endregion
        #region SaveChangesCommand
        private bool CanSaveChangesCommandExecute(object p)
        {
            if (tagsTextBoxColor == "Red") return false;
            return true;
        }

        private void OnSaveChangesCommandExecuted(object p)
        {
            if(isCheckedImmediate == "True")
            {
                taskImportance = DegreeOfImportance.Immediate;
            }
            else if(isCheckedImportant == "True")
            {
                taskImportance = DegreeOfImportance.Important;
            }
            else
            {
                taskImportance = DegreeOfImportance.NonUrgent;
            }
            if(isCheckedPerformAgain == "True")
            {
                task.IsPerfomed = false;
            }
            DataBase dataBase = codeBehind.GetDataBase();
            if (!dataBase.IsThereSuchName(taskTitle) || firstTaskTitle == taskTitle)
            {
                foreach(Task aim in dataBase.Tasks)
                {
                    if(aim.Title == firstTaskTitle)
                    {
                        aim.Title = taskTitle;
                        aim.Deadline = deadline;
                        aim.Description = taskDescription;
                        aim.Importance = taskImportance;
                        aim.IsPerfomed = task.IsPerfomed;
                        aim.Tags = aim.ParseTags(taskTags);
                        break;
                    }
                }
                DataBaseBuilder.loadToFile(dataBase);
                IsEnableDeadline = "False";
                IsEnableTitle = "False";
                IsEnableDescription = "False";
                IsEnableTags = "False";
                IsEnableImportance = "False";
                IsEnablePerformAgain = "False";
                ChangeButtonVisibility = "Visible";
                SaveButtonVisibility = "Hidden";
            }
            else
            {
                MessageBox.Show("Такое задание уже существует", "Ошибка при вводе имени",
                        MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
        #region DeleteTaskCommand
        private bool CanDeleteTaskCommandExecute(object p) => true;

        private void OnDeleteTaskCommandExecuted(object p)
        {
            DataBase dataBase = codeBehind.GetDataBase();
            dataBase.Tasks.Remove(dataBase.Tasks.Single(s => s.Title == taskTitle));
            DataBaseBuilder.loadToFile(dataBase);
            codeBehind.LoadView(ViewType.Main);
        }
        #endregion
        private bool CanCheckTagsForValidCommandExecute(object p) => true;
        private void OnCheckTagsForValidCommandExecuted(object p)
        {
            Regex regex = new Regex(@"(#(\w)+,? *)+");
            MatchCollection matches = regex.Matches(TaskTags);
            string temp = String.Empty;
            foreach (Match tag in matches)
            {
                temp += tag;
            }
            if (temp != taskTags)
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
