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
using CoreFramework;

namespace RunningCompetitionWPF
{
    public partial class AddCompetitionsPage : Page
    {
        public Competition CurrentCompetition = new Competition();

        public AddCompetitionsPage(Competition selectedCompetition)
        {
            InitializeComponent();

            if (selectedCompetition != null)
                CurrentCompetition = selectedCompetition;

            DataContext = CurrentCompetition;
            comboCities.ItemsSource = ConnectionUser.GetCities();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCompetition.City != null)
                CurrentCompetition.idCity = CurrentCompetition.City.idCity;

            var competitions = new List<System.ComponentModel.DataAnnotations.ValidationResult>();            
            var context = new ValidationContext(CurrentCompetition);

            if (!Validator.TryValidateObject(CurrentCompetition, context, competitions, true))
                foreach (var error in competitions)
                    MessageBox.Show(error.ErrorMessage);
            else
            {
                if (CurrentCompetition.idCompetition == 0)
                    ConnectionCompetitions.AddCompetition(CurrentCompetition);
                else
                    ConnectionCompetitions.UpdateCompet(CurrentCompetition);
                
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.Navigate(new AdminCompetitionsPage());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}
