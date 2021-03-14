using System;
using System.Collections.Generic;
using System.Linq;
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
using TaskManager.Model;
using TaskManager.ViewModels;

namespace TaskManager.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        public IMainWindowsCodeBehind codeBehind;
        public MainPage() { }
        public MainPage(IMainWindowsCodeBehind codeBehind)
        {
            InitializeComponent();
            this.codeBehind = codeBehind;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Tasks.SelectedValue != null) codeBehind.LoadViewWithSelectedItem(ViewType.TaskInformation, Tasks.SelectedItem);
        }

        private void PerfomedTasks_LostFocus(object sender, RoutedEventArgs e)
        {
            PerfomedTasks.SelectedItem = null;
        }

        private void PerfomedTasks_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (PerfomedTasks.SelectedValue != null) codeBehind.LoadViewWithSelectedItem(ViewType.TaskInformation, PerfomedTasks.SelectedItem);
        }
    }
}
