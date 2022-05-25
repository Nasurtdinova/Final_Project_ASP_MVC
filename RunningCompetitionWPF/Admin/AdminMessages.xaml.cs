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
        public AdminMessages()
        {
            InitializeComponent();
            lvMessages.ItemsSource = ConnectionSponsorship.GetSponsorshipTopical();
        }

        private void lvMessages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sponCom = (sender as ListView).SelectedItem as SponsorCommand;
            if (sponCom != null)
            {
                MessageBoxResult result = MessageBox.Show($"Вы хотите принять заявку  от {sponCom.Sponsor.Surname} {sponCom.Sponsor.Name} на спонсирование команды {sponCom.Command.Name}, в период времени с {sponCom.DateBegin.Date.ToString("dd.MM.yyyy")} до {sponCom.DateEnd.Date.ToString("dd.MM.yyyy")}?{Environment.NewLine}Взаимовыгода: {sponCom.MutualBenefit}", "Заявка", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        sponCom.idStatus = 3;
                        ConnectionSponsorship.UpdateSponsorship(sponCom);
                        MessageBox.Show("Заявка принята!", "Уведомление");
                        break;
                    case MessageBoxResult.No:
                        sponCom.idStatus = 2;
                        ConnectionSponsorship.UpdateSponsorship(sponCom);
                        MessageBox.Show("Заявка отклонена!", "Уведомление");
                        break;
                    case MessageBoxResult.Cancel:
                        Manager.MainFrame.Navigate(new AdminMessages());
                        break;
                }
                Manager.MainFrame.Navigate(new AdminMessages());
            }
            else
                MessageBox.Show("Вы ничего не выбрали!");
        }
    }
}
