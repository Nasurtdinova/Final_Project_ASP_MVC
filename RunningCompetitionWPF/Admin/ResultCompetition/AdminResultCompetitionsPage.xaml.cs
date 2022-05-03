using CoreFramework;
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

namespace RunningCompetitionWPF
{
    public partial class AdminResultCompetitionsPage : Page
    {
        public static List<ResultCompetition> infoCompet { get; set; }

        public AdminResultCompetitionsPage()
        {
            InitializeComponent();

            var city = ConnectionCommands.GetCommands();
            city.Insert(0, new Command { Name = "Все" });
            comboCommand.ItemsSource = city;
            comboCommand.SelectedIndex = 0;

            dgResultCompetitions.ItemsSource = ConnectionResults.GetResults();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditResulCompetPage((sender as Button).DataContext as ResultCompetition));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddResultCompetitionPage());
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var competsForRemoving = dgResultCompetitions.SelectedItems.Cast<ResultCompetition>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {competsForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var i in competsForRemoving)
                {
                    ConnectionResults.RemoveResult(Convert.ToInt32(i.idCommand), Convert.ToInt32(i.idCompetition));
                }
                dgResultCompetitions.ItemsSource = ConnectionResults.GetResults();
                MessageBox.Show("Данные удалены");
            }
        }
        private void UpdateResultCompetitions()
        {
            infoCompet = ConnectionResults.GetResults().ToList();

            if (checkMonth.IsChecked == true)
                infoCompet = infoCompet.Where(a => a.Competition.Date.Value.Month == DateTime.Today.Month).ToList();

            if (comboCommand.SelectedIndex > 0)
                infoCompet = infoCompet.Where(p => p.idCommand == (comboCommand.SelectedItem as Command).idCommand).ToList();

            dgResultCompetitions.ItemsSource = infoCompet;
        }

        private void comboCommand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateResultCompetitions();
        }

        private void checkMonth_Click(object sender, RoutedEventArgs e)
        {
            UpdateResultCompetitions();
        }
    }
}
