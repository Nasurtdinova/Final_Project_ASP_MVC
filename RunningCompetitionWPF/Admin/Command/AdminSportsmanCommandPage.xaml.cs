using CoreFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RunningCompetitionWPF
{
    public partial class AdminSportsmanCommandPage : Page
    {
        public static List<Sportsman> infoSportsmansCommand { get; set; }
        public int IdCommand { get; set; }
        public AdminSportsmanCommandPage(int idCommand)
        {
            InitializeComponent();
            IdCommand = idCommand;
            infoSportsmansCommand = ConnectionCommands.GetSporCom(IdCommand);
            this.DataContext = this;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSportsmanInCommandPage(null,IdCommand));
        }

        private void lvCommands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ListView).SelectedItem as Sportsman;
            Manager.MainFrame.Navigate(new AddEditSportsmanInCommandPage(a,IdCommand));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}
