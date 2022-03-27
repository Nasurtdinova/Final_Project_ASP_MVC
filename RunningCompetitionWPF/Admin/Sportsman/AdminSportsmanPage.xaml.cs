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
    public partial class AdminSportsmanPage : Page
    {
        public static ObservableCollection<Sportsman> infoSportsmans { get; set; }
        public AdminSportsmanPage()
        {
            InitializeComponent();
            infoSportsmans = ConnectionSportsmans.GetSportsmans();
            this.DataContext = this;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
