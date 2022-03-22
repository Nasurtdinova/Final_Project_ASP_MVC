using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class CommandsPage : Page
    {
        public static ObservableCollection<Command> infoCommands { get; set; }
        public CommandsPage()
        {
            InitializeComponent();
            infoCommands = ConnectionCommands.GetCommands();
            this.DataContext = this;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
