using CoreFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AdminMessages : Page
    {
        public static List<SponsorCommand> infoMessages { get; set; }
        public AdminMessages()
        {
            InitializeComponent();
            infoMessages = ConnectionSponsorship.GetSponsorshipTopical();
            this.DataContext = this;
        }

        private void lvMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ListView).SelectedItem as SponsorCommand;
            MessageBoxResult result = MessageBox.Show($"Вы хотите принять заявку  от {a.Sponsor.Surname} {a.Sponsor.Name} на спонсирование команды {a.Command.Name}?", "Заявка", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    a.idStatus = 3;
                    ConnectionSponsorship.UpdateSponsorship(a);
                    MessageBox.Show("Заявка принята!", "Уведомление");
                    break;
                case MessageBoxResult.No:
                    a.idStatus = 2;
                    ConnectionSponsorship.UpdateSponsorship(a);
                    MessageBox.Show("Заявка отклонена!", "Уведомление");
                    break;
                case MessageBoxResult.Cancel:
                    Manager.MainFrame.Navigate(new AdminMessages());
                    break;
                
            }
            Manager.MainFrame.Navigate(new AdminMessages());
        }
    }
}
