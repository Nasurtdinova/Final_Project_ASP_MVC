using CoreFramework;
using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
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
    public partial class AdminCompetitionsPage : Page
    {
        public static List<Competition> infoCompet { get; set; }

        public AdminCompetitionsPage()
        {
            InitializeComponent();

            var city = ConnectionUser.GetCities();
            city.Insert(0, new City { Name = "Все" });
            comboCity.ItemsSource = city;
            comboCity.SelectedIndex = 0;

            dgCompetitions.ItemsSource = ConnectionCompetitions.GetCompetitions().ToList();
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCompetitionsPage((sender as Button).DataContext as Competition));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddCompetitionsPage(null));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var competsForRemoving = dgCompetitions.SelectedItems.Cast<Competition>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {competsForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var i in competsForRemoving)
                    ConnectionCompetitions.RemoveCompetition(i.idCompetition);
                dgCompetitions.ItemsSource = ConnectionCompetitions.GetCompetitions().ToList();
                MessageBox.Show("Данные удалены");
            }
        }

        private void btnViewResult_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminResulCompetitionPage((sender as Button).DataContext as Competition));
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2013 (*.xls)|*.xls|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != true)
                return;
            ConnectionCompetitions.ReadFile(openFileDialog.FileName);
            dgCompetitions.ItemsSource = ConnectionCompetitions.GetCompetitions().ToList();
        }
    }
}

