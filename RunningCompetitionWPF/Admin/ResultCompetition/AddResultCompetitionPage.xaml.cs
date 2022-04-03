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
    public partial class AddResultCompetitionPage : Page
    {
        public int IdCompet { get; set; }
        public int IdCommand { get; set; }
        public AddResultCompetitionPage()
        {
            InitializeComponent();
            comboCommands.ItemsSource = ConnectionCommands.GetCommands();
            comboCompets.ItemsSource = ConnectionCompetitions.GetCompetitions();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ResultCompetition res = new ResultCompetition()
            { 
                Command = ConnectionCommands.GetCommandsId(IdCommand),
                Competition = ConnectionCompetitions.GetCompetId(IdCompet),
                Rank = Convert.ToInt32(textRank.Text)
            };
            if (ConnectionResults.isRankTrue(Convert.ToInt32(textRank.Text), IdCompet))
            {
                if (ConnectionResults.isComCompetTrue(IdCommand, IdCompet))
                {                 
                    try
                    {
                        ConnectionResults.AddResult(res);
                        MessageBox.Show("Информация сохранена");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show($"Такие данные уже существуют");
                }
            }
            else
            {
                MessageBox.Show($"В соревновании {res.Competition.Name} такое место уже заняли");
            }
            Manager.MainFrame.NavigationService.Navigate(new AdminResultCompetitionsPage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }

        private void comboCommands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Command;
            IdCommand = a.idCommand;
        }

        private void comboCompets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Competition;
            IdCompet = a.idCompetition;
        }
    }
}
