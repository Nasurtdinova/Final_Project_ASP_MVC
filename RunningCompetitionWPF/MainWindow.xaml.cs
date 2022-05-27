using CoreFramework;
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
using System.Windows.Threading;

namespace RunningCompetitionWPF
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;

        double panelWidth;
        bool hidden;

        public MainWindow()
        {
            InitializeComponent();
            
            Manager.MainFrame = frame_auto_reg;

            Manager.SportsmansAdmin = sportsmanAdmin;
            Manager.Sportsmans = sportsman;

            Manager.CommandsAdmin = commandAdmin;
            Manager.Commands = command;

            Manager.CompetitionsAdmin = competitionAdmin;
            Manager.Competitions = competition;

            Manager.ResultCompetitionsAdmin = resultCompetitionAdmin;
            Manager.ResultCompetitions = resultCompetition;

            Manager.MySponsorshipsSponsor = mySponsorshipsSponsor;
            Manager.MessagesAdmin = messagesAdmin;
            Manager.NoticesSponsor = noticesSponsor;

            Manager.Authorization = login;
            Manager.Exit = exit;

            Manager.RoleNameLabel = lbRoleName;
            Manager.EditProfile = editProfile;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 2);
            timer.Tick += Timer_Tick;

            panelWidth = sidePanel.Width;
            frame_auto_reg.Navigate(new ViewerMainPage());
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                mainIcon.Visibility = Visibility.Visible;                
                sidePanel.Width += 1;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                    lbRoleName.Visibility = Visibility.Visible;
                    lbWelcome.Visibility = Visibility.Visible;
                    frame_auto_reg.Margin = new Thickness(210, 50, 0, 0);
                    panelHeader.Margin = new Thickness(210, 0, 0, 0);
                }
            }
            else
            {
                mainIcon.Visibility = Visibility.Hidden;                
                sidePanel.Width -= 1;
                if (sidePanel.Width <= 45)
                {
                    timer.Stop();
                    hidden = true;
                    lbRoleName.Visibility = Visibility.Collapsed;
                    lbWelcome.Visibility = Visibility.Collapsed;
                    frame_auto_reg.Margin = new Thickness(40, 50, 0, 0);
                    panelHeader.Margin = new Thickness(40, 0, 0, 0);
                }
            }
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

        private void login_Click(object sender, RoutedEventArgs e)
        {           
            Manager.MainFrame.NavigationService.Navigate(new AuthorizationPage());
        }

        private void resultCompetition_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ResultCompetitionsPage());
        }

        private void competitionAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminCompetitionsPage());
        }

        private void resultCompetitionAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminResultCompetitionsPage());
        }

        private void commandAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminCommandPage());
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {           
            CurrentUser.user = null;
            Manager.DoViewer();
            Manager.MainFrame.NavigationService.Navigate(new AuthorizationPage());
        }

        private void sportsmanAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminSportsmanPage());
        }

        private void mainPage_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ViewerMainPage());
        }

        private void mySponsorshipsSponsor_Click(object sender, RoutedEventArgs e)
        {             
            Manager.MainFrame.Navigate(new MySponsorshipsPage());
        }

        private void messagesAdmin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AdminMessages());
        }

        private void noticesSponsor_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new NoticesSponsorPage());
        }

        private void panelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();           
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            ConnectionResults.ExportExcel();
        }

        private void sponsorship_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ViewerSponsorshipsPage());
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProfileSponsorPage());
        }
    }
}
