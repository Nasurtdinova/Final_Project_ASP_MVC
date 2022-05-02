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
    public partial class AdminSportsmanPage : Page
    {
        public static ObservableCollection<Sportsman> infoSportsmans { get; set; }

        public AdminSportsmanPage()
        {
            InitializeComponent();
            infoSportsmans = ConnectionSportsmans.GetSportsmans();
            this.DataContext = this;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var sportsmansForRemoving = lvSportsmans.SelectedItems.Cast<Sportsman>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {sportsmansForRemoving.Count()} элементов", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (var i in sportsmansForRemoving)
                {
                    ConnectionSportsmans.RemoveSportsman(i.ID);
                }

                lvSportsmans.ItemsSource = ConnectionSportsmans.GetSportsmans().ToList();
                MessageBox.Show("Данные удалены");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSportsmansPage(null));
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new AddEditSportsmansPage((sender as Button).DataContext as Sportsman));
        }
    }
}
