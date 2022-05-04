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
    public partial class MySponsorshipsPage : Page
    {
        public static List<SponsorCommand> infoSponsorships { get; set; }
        public MySponsorshipsPage()
        {
            InitializeComponent();
            infoSponsorships = ConnectionSponsorship.GetSponsorshipAccepted();
            this.DataContext = this;
        }

        private void btnSendRequest_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new SendRequestPage());
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            var a = dgSponsorships.SelectedItem as SponsorCommand;
            if (a != null)
            {
                MessageBoxResult result = MessageBox.Show($"Вы точно хотите завершить спонсирование команды {a.Command.Name}?", "Заявка", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ConnectionSponsorship.EndSponsorship(a.id);
                        MessageBox.Show($"Вы завершили спонсирование команды {a.Command.Name}!", "Уведомление"); ;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                Manager.MainFrame.Navigate(new MySponsorshipsPage());
            }
            else
                MessageBox.Show("Вы ничего не выбрали!");
        }
    }
}
