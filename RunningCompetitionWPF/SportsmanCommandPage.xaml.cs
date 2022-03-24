using CoreFramework;
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

namespace RunningCompetitionWPF
{
    public partial class SportsmanCommandPage : Page
    {
        public static ObservableCollection<Sportsman> infoSportsmansCommand { get; set; }
        public SportsmanCommandPage(int id)
        {
            InitializeComponent();
            infoSportsmansCommand = ConnectionCommands.GetSporCom(id);
            this.DataContext = this;
        }
    }
}
