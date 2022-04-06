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
            infoSponsorships = ConnectionSponsorship.GetSponsorship(CurrentUser.spon.idSponsor);
            this.DataContext = this;
        }

        private void btnSendRequest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
