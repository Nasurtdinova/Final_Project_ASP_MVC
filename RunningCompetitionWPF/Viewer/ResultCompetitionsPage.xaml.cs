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

namespace RunningCompetitionWPF
{
    public partial class ResultCompetitionsPage : Page
    {
        public static List<ResultCompetition> infoResultCompet { get; set; }
        public ResultCompetitionsPage()
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

        private void comboCompet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateResultCompetitions();
        }

        private void checkMonth_Click(object sender, RoutedEventArgs e)
        {
            UpdateResultCompetitions();
        }
    }
}
