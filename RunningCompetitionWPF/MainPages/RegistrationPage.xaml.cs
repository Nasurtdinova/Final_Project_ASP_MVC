using CoreFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
           

            Users user = new Users()
            {
                Email = textLogin.Text,
                Password = textPassword.Text,
                idType = 2
            };

            Sponsor sponsor = new Sponsor()
            {
                idUser = Connection.GetUsers().Last().idUser,
                Surname = textSurname.Text,
                Name = textName.Text,
                Phone = textPhone.Text
            };

            var valid = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var contextUser = new ValidationContext(user);
            var contextSponsor = new ValidationContext(sponsor);
            if (!Validator.TryValidateObject(user, contextUser, valid, true) || !Validator.TryValidateObject(sponsor, contextSponsor, valid, true))
            {
                foreach (var error in valid)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            else
            {
                if (Connection.IsCoinsLogin(textLogin.Text))
                    MessageBox.Show("Такой логин уже существует");
                else if (!(textPassword.Text.Length >= 6 && Connection.IsCorrectPassword(textPassword.Text)))
                    MessageBox.Show("Пароль не соответствует требованиям");
                else
                {                  
                    Connection.AddUser(user);
                    Connection.AddSponsor(sponsor);
                    MessageBox.Show("Вы зарегистрированы!");
                    NavigationService.Navigate(new AuthorizationPage());
                }
            }
        }
    }
}
