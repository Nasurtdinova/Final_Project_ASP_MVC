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
    public partial class AdminResulCompetitionPage : Page
    {
        public AdminResulCompetitionPage(Competition compet)
        {
            InitializeComponent();
            nameCompetition.Text = compet.Name;
            dgResultCompetitions.ItemsSource = ConnectionResults.GetResutCompet(compet.idCompetition);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}
