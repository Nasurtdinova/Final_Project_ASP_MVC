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
    public partial class ResultCompetitionsPage : Page
    {
        public static ObservableCollection<ResultCompetition> infoResultCompet { get; set; }
        public ResultCompetitionsPage()
        {
            InitializeComponent();
            infoResultCompet = ConnectionResults.GetResults();
            this.DataContext = this;
        }
    }
}
