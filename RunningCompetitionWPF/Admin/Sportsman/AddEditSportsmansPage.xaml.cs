﻿using CoreFramework;
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

namespace RunningCompetitionWPF
{
    public partial class AddEditSportsmansPage : Page
    {
        public Sportsman CurrentSportsman = new Sportsman();
        public AddEditSportsmansPage(Sportsman selectedSportsman)
        {
            InitializeComponent();
            if (selectedSportsman != null)
                CurrentSportsman = selectedSportsman;

            DataContext = CurrentSportsman;
            comboImages.ItemsSource = Connection.GetImages();
            comboTitle.ItemsSource = Connection.GetTitles();
            comboCommand.ItemsSource = ConnectionCommands.GetCommands();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.NavigationService.GoBack();
        }
    }
}