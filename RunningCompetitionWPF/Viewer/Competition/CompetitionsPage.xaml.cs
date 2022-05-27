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
using CoreFramework;

namespace RunningCompetitionWPF
{
   
    public partial class CompetitionsPage : Page
    {
        public static List<Competition> infoCompet { get; set; }
        public CompetitionsPage()
        {
            InitializeComponent();

            var city = ConnectionUser.GetCities();
            city.Insert(0, new City { Name = "Все" });
            comboCity.ItemsSource = city;
            comboCity.SelectedIndex = 0;

            dgCompetitions.ItemsSource =  ConnectionCompetitions.GetCompetitions().ToList();
        }

        private void btnViewResult_Click(object sender, RoutedEventArgs e)
        {
            var a = (sender as Button).DataContext as Competition;
            if (a != null && a.Date > DateTime.Now)
            {
                MessageBox.Show("Соревнование еще не прошло!");
            }
            else
            {
                Manager.MainFrame.Navigate(new ResulCompetitionPage(a));
            }
        }

        private void UpdateCompetitions()
        {
            infoCompet = ConnectionCompetitions.GetCompetitions().ToList();

            if (checkMonth.IsChecked == true)
                infoCompet = infoCompet.Where(a => a.Date.Month == DateTime.Today.Month).ToList();

            if (comboCity.SelectedIndex > 0)
                infoCompet = infoCompet.Where(p => p.idCity == (comboCity.SelectedItem as City).idCity).ToList();

            infoCompet = infoCompet.Where(p => p.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            dgCompetitions.ItemsSource = infoCompet;
        }

        private void comboCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCompetitions();
        }

        private void checkMonth_Click(object sender, RoutedEventArgs e)
        {
            UpdateCompetitions();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCompetitions();
        }
    }
}
