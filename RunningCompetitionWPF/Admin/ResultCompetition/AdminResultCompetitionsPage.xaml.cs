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
using Excel = Microsoft.Office.Interop.Excel;

namespace RunningCompetitionWPF
{
    public partial class AdminResultCompetitionsPage : Page
    {
        public AdminResultCompetitionsPage()
        {
            InitializeComponent();
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
                try
                {
                    foreach (var i in competsForRemoving)
                    {
                        ConnectionResults.RemoveResult(Convert.ToInt32(i.idCommand), Convert.ToInt32(i.idCompetition));
                    }

                    dgResultCompetitions.ItemsSource = ConnectionResults.GetResults();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            ConnectionResults.ExportExcel();
        }
    }
}
