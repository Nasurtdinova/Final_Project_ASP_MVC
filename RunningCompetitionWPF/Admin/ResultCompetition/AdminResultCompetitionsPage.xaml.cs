using CoreFramework;
using Microsoft.Win32;
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
        public static List<ResultCompetition> infoResultCompet { get; set; }

        public AdminResultCompetitionsPage()
        {
            InitializeComponent();

            var com = ConnectionCommands.GetCommands();
            com.Insert(0, new Command { Name = "Все" });
            comboCommand.ItemsSource = com;
            comboCommand.SelectedIndex = 0;

            var compet = ConnectionCompetitions.GetCompetitions();
            compet.Insert(0, new Competition { Name = "Все" });
            comboCompet.ItemsSource = compet;
            comboCompet.SelectedIndex = 0;

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
            infoResultCompet = ConnectionResults.GetResults().ToList();

            if (checkMonth.IsChecked == true)
                infoResultCompet = infoResultCompet.Where(a => a.Competition.Date.Value.Month == DateTime.Today.Month).ToList();

            if (comboCommand.SelectedIndex > 0)
                infoResultCompet = infoResultCompet.Where(p => p.idCommand == (comboCommand.SelectedItem as Command).idCommand).ToList();

            if (comboCompet.SelectedIndex > 0)
                infoResultCompet = infoResultCompet.Where(p => p.idCompetition == (comboCompet.SelectedItem as Competition).idCompetition).ToList();

            dgResultCompetitions.ItemsSource = infoResultCompet;
        }

        private void comboCommand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateResultCompetitions();
        }

        private void checkMonth_Click(object sender, RoutedEventArgs e)
        {
            UpdateResultCompetitions();
        }

        private void comboCompet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateResultCompetitions();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2013 (*.xls)|*.xls|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != true)
                return;
            ConnectionResults.ReadFile(openFileDialog.FileName);
            dgResultCompetitions.ItemsSource = ConnectionCompetitions.GetCompetitions().ToList();
        }
    }
}
