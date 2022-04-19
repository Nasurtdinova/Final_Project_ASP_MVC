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
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AuthorizationPage());
        }

        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {
            bool isLetter = false;
            bool isDigit = false;
            bool isSymbol = false;
            char[] chars = { '!', '@', '#', '$', '%', '^' };
            foreach (var i in textPassword.Text)
            {
                if (Char.IsLetter(i))
                    isLetter = true;
                if (Char.IsNumber(i))
                    isDigit = true;
                if (chars.Contains(i))
                    isSymbol = true;
            }

            if (Connection.IsCoinsLogin(textLogin.Text))
                MessageBox.Show("Такой логин уже существует");
            else if (!(textPassword.Text.Length >= 6 && isLetter && isDigit && isSymbol))
                MessageBox.Show("Пароль не соответствует требованиям");
            else
            {
                Users user = new Users()
                {
                    Email = textLogin.Text,
                    Password = textPassword.Text,
                     idType = 2
                };
                Connection.AddUser(user);

                Sponsor sponsor = new Sponsor()
                {
                    idUser = Connection.GetUsers().Last().idUser,
                    Surname = textSurname.Text,
                    Name = textName.Text,
                    Phone = textPhone.Text
                };
                Connection.AddSponsor(sponsor);
                MessageBox.Show("Вы зарегистрированы!");
                NavigationService.Navigate(new AuthorizationPage());
            }
        }
    }
}
