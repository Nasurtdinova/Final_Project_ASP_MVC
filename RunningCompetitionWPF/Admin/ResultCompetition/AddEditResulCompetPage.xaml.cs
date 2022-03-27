using CoreFramework;
using System;
using System.Collections.Generic;
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
    public partial class AddEditResulCompetPage : Page
    {
        public ResultCompetition CurrentResult = new ResultCompetition();
        public AddEditResulCompetPage(ResultCompetition selectedResult)
        {
            InitializeComponent();

            if (selectedResult != null)
                CurrentResult = selectedResult;

            DataContext = CurrentResult;
            comboCommands.ItemsSource = ConnectionCommands.GetCommands();
            comboCompets.ItemsSource = ConnectionCompetitions.GetCompetitions();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (CurrentResult.Rank == null)
                errors.AppendLine("Укажите место");
            if (CurrentResult.Command == null)
                errors.AppendLine("Выберите город");

            if (CurrentResult.Competition == null)
                errors.AppendLine("Выберите город");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (CurrentResult.idCompetition == 0)
                ConnectionResults.AddResult(CurrentResult);
            else
                ConnectionResults.UpdateResult(CurrentResult);

            try
            {
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            Manager.MainFrame.NavigationService.Navigate(new AdminResultCompetitionsPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}
