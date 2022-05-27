using CoreFramework;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
    public partial class ProfileSponsorPage : Page
    {
        public ProfileSponsorPage()
        {
            InitializeComponent();
            if (CurrentUser.spon.Photo == null)
                sponsorPhoto.Source = new BitmapImage(new Uri("C:/Users/nasur/Source/Repos/Final_Project_ASP_MVC_Clone/RunningCompetitionWPF/Icons/PhotoProfile.png"));
            else
            {
                var stream = new MemoryStream(CurrentUser.spon.Photo);
                stream.Seek(0, SeekOrigin.Begin);
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                sponsorPhoto.Source = image;
            }
            DataContext = CurrentUser.spon;
        }

        private void btnEditProfile_Click(object sender, RoutedEventArgs e)
        {
            Sponsor spon = new Sponsor()
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Phone = tbPhone.Text,
                Photo = CurrentUser.spon.Photo
            };
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(spon);

            if (!Validator.TryValidateObject(spon, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            else
            {
                ConnectionUser.UpdateSponsor(spon);
                MessageBox.Show("Информация сохранена");
            }
        }

        private void btnEditPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                sponsorPhoto.Source = new BitmapImage(new Uri(path));
                CurrentUser.spon.Photo = File.ReadAllBytes(path);
            }
        }
    }
}
