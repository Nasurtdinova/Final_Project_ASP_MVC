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
using CoreFramework;

namespace RunningCompetitionWPF
{
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.Navigate(new RegistrationPage());
        }

        private void brnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectionUser.IsLogin(txt_login.Text,txt_password.Password) == 1)
            {
                Manager.DoAdmin();
                Manager.MainFrame.NavigationService.Navigate(new ViewerMainPage());
            }
            else if (ConnectionUser.IsLogin(txt_login.Text, txt_password.Password) == 2)
            {
                Manager.DoSponsor();
                Manager.MainFrame.NavigationService.Navigate(new ViewerMainPage());
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }
    }
}
