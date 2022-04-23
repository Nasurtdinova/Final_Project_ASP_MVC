using CoreFramework;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
    public partial class AddEditSportsmanInCommandPage : Page
    {
        public Sportsman CurrentSportsman = new Sportsman();
        public int IdCommand { get; set; }
        public AddEditSportsmanInCommandPage(Sportsman selectedSportsman, int idCommand)
        {
            InitializeComponent();
            IdCommand = idCommand;
            if (selectedSportsman != null)
            {
                CurrentSportsman = selectedSportsman;
            }
            //CurrentSportsman.Command = ConnectionCommands.GetCommandsId(IdCommand);

            DataContext = CurrentSportsman;
            comboTitle.ItemsSource = Connection.GetTitles();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var sportsmans = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(CurrentSportsman);
            CurrentSportsman.idCommand = IdCommand;
            if (!Validator.TryValidateObject(CurrentSportsman, context, sportsmans, true))
            {
                foreach (var error in sportsmans)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            else
            {
                if (CurrentSportsman.ID == 0)
                    ConnectionSportsmans.AddSportsman(CurrentSportsman);
                else
                    ConnectionSportsmans.UpdateSportsman(CurrentSportsman);

                try
                {
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.Navigate(new AdminSportsmanCommandPage(IdCommand));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            byte[] imageData;
            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                imageData = File.ReadAllBytes(path);

                var stream = new MemoryStream(imageData);
                stream.Seek(0, SeekOrigin.Begin);
                var image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();

                imgCom.Source = image;
                CurrentSportsman.Image = imageData;
            }
        }
    }
}
