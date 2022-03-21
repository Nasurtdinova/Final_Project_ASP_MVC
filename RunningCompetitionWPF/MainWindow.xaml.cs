using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frame_auto_reg.Navigate(new ViewerMainPage());
            Manager.MainFrame = frame_auto_reg;
        }

        private void sportsman_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new SportsmanPage());
        }

        private void command_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new CommandsPage());
        }

        private void competition_click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CompetitionsPage());
        }

        private void registrSponsor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void registrCommand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new AuthorizationPage());
            registr.Visibility = Visibility.Hidden;
            login.Visibility = Visibility.Hidden;
        }
    }
}
