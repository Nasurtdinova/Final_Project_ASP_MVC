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
            comboCities.ItemsSource = Connection.GetCities();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(CurrentCompetition.Name))
                errors.AppendLine("Укажите название соревнования");
            if (CurrentCompetition.City == null)
                errors.AppendLine("Выберите город");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (CurrentCompetition.idCompetition == 0)
                ConnectionCompetitions.AddCompetition(CurrentCompetition);
            else
                ConnectionCompetitions.UpdateCompet(CurrentCompetition);

            try
            {
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
