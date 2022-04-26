using CoreFramework;
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
    public partial class SendRequestPage : Page
    {
        public SponsorCommand CurrentSponsorships = new SponsorCommand();
        public SendRequestPage()
        {
            InitializeComponent();
            DataContext = CurrentSponsorships;
            comboCommands.ItemsSource = ConnectionCommands.GetCommands();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentSponsorships.Command != null)
                CurrentSponsorships.idCom = CurrentSponsorships.Command.idCommand;
            var sponsorCommand = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(CurrentSponsorships);
            if (!Validator.TryValidateObject(CurrentSponsorships, context, sponsorCommand, true))
            {
                foreach (var error in sponsorCommand)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            else
            {
                if (ConnectionSponsorship.IsAddTrue(CurrentUser.spon.idSponsor, Convert.ToInt32(CurrentSponsorships.idCom)))
                {
                    try
                    {
                        ConnectionSponsorship.AddSponsorship(CurrentSponsorships);
                        MessageBox.Show($"Вы отправили запрос на спонсирование команды {CurrentSponsorships.Command.Name}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    Manager.MainFrame.NavigationService.Navigate(new MySponsorshipsPage());
                }
                else
                    MessageBox.Show("Вы спонсируете эту команду!");
            }
          
        }
    }
}
