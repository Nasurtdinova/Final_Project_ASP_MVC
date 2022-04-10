using CoreFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RunningCompetitionWPF.Admin
{
    public partial class AdminCommandPage : Page
    {
        public static ObservableCollection<Command> infoCommands { get; set; }
        public AdminCommandPage()
        {
            InitializeComponent();
            infoCommands = ConnectionCommands.GetCommands();
            this.DataContext = this;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new AddEditCommandPage((sender as Button).DataContext as Command));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new AddEditCommandPage(null));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var command = (sender as Button).DataContext as Command;

            if (MessageBox.Show($"Вы точно хотите удалить {command.Name}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ConnectionCommands.RemoveCommand(command.idCommand);
                    lvCommands.ItemsSource = ConnectionCommands.GetCommands().ToList();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void lvCommands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ListView).SelectedItem as Command;
            Manager.MainFrame.NavigationService.Navigate(new AdminSportsmanCommandPage(a.idCommand));
        }
    }
}
