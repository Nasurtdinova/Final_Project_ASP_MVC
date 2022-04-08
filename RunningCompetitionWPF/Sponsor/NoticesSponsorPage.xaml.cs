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

namespace RunningCompetitionWPF
{
    public partial class NoticesSponsorPage : Page
    {
        public static List<SponsorCommand> infoNotices { get; set; }
        public NoticesSponsorPage()
        {
            InitializeComponent();
            infoNotices = ConnectionSponsorship.GetSponsorships().Where(a=> a.idSponsor == CurrentUser.spon.idSponsor).ToList();
            this.DataContext = this;
        }
    }
}
