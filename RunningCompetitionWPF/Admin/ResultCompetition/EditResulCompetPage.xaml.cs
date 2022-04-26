﻿using CoreFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public partial class EditResulCompetPage : Page
    {
        public ResultCompetition CurrentResult = new ResultCompetition();

        public EditResulCompetPage(ResultCompetition selectedResult)
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
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (CurrentResult.Command != null)
                CurrentResult.idCommand = CurrentResult.Command.idCommand;
            if (CurrentResult.Competition != null)
                CurrentResult.idCompetition = CurrentResult.Competition.idCompetition;

            var context = new ValidationContext(CurrentResult);
            if (!Validator.TryValidateObject(CurrentResult, context, results, true))
                foreach (var error in results)
                    MessageBox.Show(error.ErrorMessage);
            else
            {
                if (ConnectionResults.IsRankTrue(Convert.ToInt32(CurrentResult.Rank), CurrentResult.Competition.idCompetition))
                {
                    if (ConnectionResults.IsComCompetTrue(CurrentResult.Command.idCommand, CurrentResult.Competition.idCompetition))
                    {
                        try
                        {
                            ConnectionResults.UpdateResult(CurrentResult);
                            MessageBox.Show("Информация сохранена");
                            Manager.MainFrame.NavigationService.Navigate(new AdminResultCompetitionsPage());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    else
                        MessageBox.Show("Такие данные уже существуют");
                }
                else
                    MessageBox.Show($"В соревновании {CurrentResult.Competition.Name} такое место уже заняли");
            }           
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}
