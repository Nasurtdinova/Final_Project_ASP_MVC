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
    public partial class SendRequestPage : Page
    {
        public int IdCommand { get; set; }
        public SendRequestPage()
        {
            InitializeComponent();
            comboCommands.ItemsSource = ConnectionCommands.GetCommands();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectionSponsorship.IsAddTrue(CurrentUser.spon.idSponsor, IdCommand))
            {
                SponsorCommand sponCom = new SponsorCommand()
                {
                    Command = ConnectionCommands.GetCommandsId(IdCommand),
                    Amount = Convert.ToInt32(textAmount.Text),
                    DateBegin = DateBegin.SelectedDate,
                    DateEnd = DateEnd.SelectedDate,
                    MutualBenefit = textBenefit.Text
                };
                try
                {
                    ConnectionSponsorship.AddSponsorship(sponCom);
                    MessageBox.Show($"Вы отправили запрос на спонсирование команды {sponCom.Command.Name}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                Manager.MainFrame.NavigationService.Navigate(new MySponsorshipsPage());
            }
            else
                MessageBox.Show("Вы спонсируете эту команду");
          
        }

        private void comboCommands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ComboBox).SelectedItem as Command;
            IdCommand = a.idCommand;
        }
    }
}
