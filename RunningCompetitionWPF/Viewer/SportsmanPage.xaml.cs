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
    public partial class SportsmanPage : Page
    {
        public SportsmanPage()
        {
            InitializeComponent();
            sportsmansList.ItemsSource = ConnectionSportsmans.GetSportsmans();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
