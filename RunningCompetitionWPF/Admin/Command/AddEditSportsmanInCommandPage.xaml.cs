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
        public int IdCommand { get; set; }
        public AddEditSportsmanInCommandPage(Sportsman selectedSportsman, int idCommand)
        {
            InitializeComponent();
            IdCommand = idCommand;
            if (selectedSportsman != null)
            {
                CurrentSportsman = selectedSportsman;
            }
            CurrentSportsman.idCommand = IdCommand;

            DataContext = CurrentSportsman;
            comboImages.ItemsSource = Connection.GetImages();
            comboTitle.ItemsSource = Connection.GetTitles();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSportsman.ID == 0)
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
            Manager.MainFrame.Navigate(new AdminSportsmanCommandPage(IdCommand));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}
