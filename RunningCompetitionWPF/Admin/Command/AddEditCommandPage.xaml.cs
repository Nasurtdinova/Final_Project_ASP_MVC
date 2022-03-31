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

namespace RunningCompetitionWPF.Admin
{
    public partial class AddEditCommandPage : Page
    {
        public Command CurrentCommand = new Command();
        public AddEditCommandPage(Command selectedCommand)
        {
            InitializeComponent();
            if (selectedCommand != null)
                CurrentCommand = selectedCommand;

            DataContext = CurrentCommand;
            comboCities.ItemsSource = Connection.GetCities();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(CurrentCommand);
            if (!Validator.TryValidateObject(CurrentCommand, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
            else
            {
                if (CurrentCommand.idCommand == 0)
                    ConnectionCommands.AddCommand(CurrentCommand);
                else
                    ConnectionCommands.UpdateCommand(CurrentCommand);

                try
                {
                    MessageBox.Show("Информация сохранена");
                    Manager.MainFrame.Navigate(new AdminCommandPage());
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
                CurrentCommand.Image = imageData;                
            }            
        }
    }
}
