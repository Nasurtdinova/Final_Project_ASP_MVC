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

        }

        private void brnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Connection.IsLogin(txt_login.Text,txt_password.Password) == 1)
            {

             }
            else if (Connection.IsLogin(txt_login.Text, txt_password.Password) == 2)
            {

            }
            else if (Connection.IsLogin(txt_login.Text, txt_password.Password) == 3)
            {

            }
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }
    }
}
