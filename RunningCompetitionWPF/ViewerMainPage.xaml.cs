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
    /// <summary>
    /// Логика взаимодействия для ViewerMainPage.xaml
    /// </summary>
    public partial class ViewerMainPage : Page
    {
        public ViewerMainPage()
        {
            InitializeComponent();
        }

        private void sportsman_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportsmanPage());
        }

        private void command_click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new page_command());
        }

        private void competition_click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new page_competition());
        }

        private void registrSponsor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void registrCommand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
