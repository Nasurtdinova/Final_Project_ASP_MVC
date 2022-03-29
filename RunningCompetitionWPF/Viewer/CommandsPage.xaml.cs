using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoreFramework;
using System.Net;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace RunningCompetitionWPF
{
    public partial class CommandsPage : Page
    {
        public static ObservableCollection<Command> infoCommands { get; set; }
        public static System.Drawing.Image img { get; set; }
        public CommandsPage()
        {
            InitializeComponent();
            infoCommands = ConnectionCommands.GetCommands();
            this.DataContext = this;
        }

        //public static System.Drawing.Image byteArrayToImage(byte[] byteArray)
        //{
        //    MemoryStream ms = new System.IO.MemoryStream(byteArray);
        //    System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        //    return returnImage;
        //}

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void lvCommands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (sender as ListView).SelectedItem as Command;
            Manager.MainFrame.NavigationService.Navigate(new SportsmanCommandPage(a.idCommand));
        }
    }
}
