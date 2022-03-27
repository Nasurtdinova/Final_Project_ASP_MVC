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
    public partial class AddEditSportsmanInCommandPage : Page
    {
        public Sportsman CurrentSportsman = new Sportsman();
        public AddEditSportsmanInCommandPage(Sportsman selectedSportsman)
        {
            InitializeComponent();

            if (selectedSportsman != null)
                CurrentSportsman = selectedSportsman;

            DataContext = CurrentSportsman;
            comboImages.ItemsSource = Connection.GetImages();
            comboTitle.ItemsSource = Connection.GetTitles();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSportsman.idCommand == 0)
                ConnectionSportsmans.AddSportsman(CurrentSportsman);
            else
                ConnectionSportsmans.UpdateSportsman(CurrentSportsman);

            try
            {
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}
