using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Data;
using TaskManager.Model;
using TaskManager.ViewModels;
using TaskManager.Views.Pages;
using TaskManager.Views.Windows;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
        public interface IMainWindowsCodeBehind
        {
            string SelectedIndexFilter { get; set; }
            DataBase GetDataBase();
            ObservableCollection<Task> GetPerfomedTasks();
            ObservableCollection<Task> GetNonPerfomedTasks();
            void LoadView(ViewType typeView);
            void LoadViewWithSelectedItem(ViewType typeView, object aim);
        }
        public enum ViewType
        {
            Main,
            TaskCreation,
            TaskInformation
        }
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        private DataBase dataBase;
        private string selectedIndexFilter = "2";

        public string SelectedIndexFilter { get => selectedIndexFilter; set => selectedIndexFilter = value; }

        public MainWindow()
        {
            InitializeComponent();
            dataBase = DataBaseBuilder.loadFromFile();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            MainWindowViewModel viewModel = new MainWindowViewModel(this);
            this.DataContext = viewModel;
            LoadView(ViewType.Main);
            LoadNotificationWindow();
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Main:
                    MainPage view = new MainPage(this);
                    MainPageViewModel viewModel = new MainPageViewModel(this, SelectedIndexFilter);
                    view.DataContext = viewModel;
                    this.Presenter.Content = view;
                    break;
                case ViewType.TaskCreation:
                    TaskCreationPage createTask = new TaskCreationPage();
                    TaskCreationViewModel createTaskViewModel = new TaskCreationViewModel(this);
                    createTask.DataContext = createTaskViewModel;
                    this.Presenter.Content = createTask;
                    break;
            }
        }
        public void LoadViewWithSelectedItem(ViewType typeView, object aim)
        {
            switch (typeView)
            {
                case ViewType.TaskInformation:
                    TaskInformationPage taskInform = new TaskInformationPage();
                    TaskInformationViewModel taskInformViewModel = new TaskInformationViewModel(this, (Task)aim);
                    taskInform.DataContext = taskInformViewModel;
                    this.Presenter.Content = taskInform;
                    break;
            }
        }
        public void LoadNotificationWindow()
        {
            Application.Current.Dispatcher.InvokeAsync(async () =>
            {
                NotificationWindow notifWindow = new NotificationWindow();
                NotificationWindowViewModel notifWindowViewModel = new NotificationWindowViewModel(this);
                notifWindow.DataContext = notifWindowViewModel;
                if(notifWindowViewModel.ChoosenTasks.Count != 0)
                {
                    var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
                    notifWindow.Left = desktopWorkingArea.Right - notifWindow.Width;
                    notifWindow.Top = desktopWorkingArea.Bottom - notifWindow.Height;
                    await System.Threading.Tasks.Task.Delay(1000);
                    notifWindow.Show();
                    MediaPlayer player = new MediaPlayer();
                    player.Open(new Uri("C:/Users/mashk/source/repos/TaskManager/Sound_11117.wav", UriKind.Relative));
                    player.Volume = 0.1;
                    player.Play();
                    await System.Threading.Tasks.Task.Delay(10000);
                    notifWindow.Close();
                }
            });
        }
        public DataBase GetDataBase()
        {
            return dataBase;
        }
        public ObservableCollection<Task> GetPerfomedTasks()
        {
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            foreach(Task t in dataBase.Tasks)
            {
                if (t.IsPerfomed) temp.Add(t);
            }
            return temp;
        }
        public ObservableCollection<Task> GetNonPerfomedTasks()
        {
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            foreach (Task t in dataBase.Tasks)
            {
                if (!t.IsPerfomed) temp.Add(t);
            }
            return temp;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataBaseBuilder.loadToFile(dataBase);
        }
    }
}
