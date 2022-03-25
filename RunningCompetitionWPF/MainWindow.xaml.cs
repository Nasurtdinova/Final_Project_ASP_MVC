using RunningCompetitionWPF.Admin;
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
            
            Manager.MainFrame = frame_auto_reg;
            Manager.MainMenu = menu;

            Manager.SportsmansAdmin = sportsman;
            Manager.Sportsmans = sportsman;

            Manager.CommandsAdmin = commandAdmin;
            Manager.Commands = command;

            Manager.CompetitionsAdmin = competitionAdmin;
            Manager.Competitions = competition;

            Manager.ResultCompetitionsAdmin = resultCompetitionAdmin;
            Manager.ResultCompetitions = resultCompetition;

            Manager.Authorization = login;
            Manager.Registration = registr;
            Manager.Exit = exit;
           
            frame_auto_reg.Navigate(new ViewerMainPage());
        }

        private void sportsman_click(object sender, RoutedEventArgs e)
        {
            Manager.VisibleAuthReg();
            Manager.MainFrame.NavigationService.Navigate(new SportsmanPage());
        }

        private void command_click(object sender, RoutedEventArgs e)
        {
            Manager.VisibleAuthReg();
            Manager.MainFrame.NavigationService.Navigate(new CommandsPage());
        }

        private void competition_click(object sender, RoutedEventArgs e)
        {
            Manager.VisibleAuthReg();
            Manager.MainFrame.Navigate(new CompetitionsPage());
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {           
            Manager.MainFrame.NavigationService.Navigate(new AuthorizationPage());
            Manager.DoViewer();
            Manager.CollapsedAuthReg();
        }

        private void resultCompetition_Click(object sender, RoutedEventArgs e)
        {
            Manager.VisibleAuthReg();
            Manager.MainFrame.Navigate(new ResultCompetitionsPage());
        }

        private void competitionAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.CollapsedAuthReg();
            Manager.MainFrame.Navigate(new AdminCompetitionsPage());
           
        }

        private void registr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void resultCompetitionAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.CollapsedAuthReg();
            Manager.MainFrame.Navigate(new AdminResultCompetitionsPage());
        }

        private void commandAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.CollapsedAuthReg();
            Manager.MainFrame.Navigate(new AdminCommandPage());
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Manager.CollapsedAuthReg();
            Manager.Exit.Visibility = Visibility.Collapsed;
            Manager.MainFrame.NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
