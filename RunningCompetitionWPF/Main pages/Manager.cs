﻿using CoreFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RunningCompetitionWPF
{
    public class Manager
    {
        public static Frame MainFrame { get; set; }
        public static Menu MainMenu { get; set; }

        public static ListViewItem Authorization { get; set; }
        public static ListViewItem Registration { get; set; }
        public static ListViewItem Exit { get; set; }

        public static Button SportsmansAdmin { get; set; }
        public static Button Sportsmans { get; set; }

        public static Button CommandsAdmin { get; set; }
        public static Button Commands { get; set; }

        public static Button CompetitionsAdmin { get; set; }
        public static Button Competitions { get; set; }

        public static Button ResultCompetitionsAdmin { get; set; }
        public static Button ResultCompetitions { get; set; }

        public static ListViewItem MySponsorshipsSponsor { get; set; }
        public static ListViewItem MessagesAdmin { get; set; }
        public static ListViewItem NoticesSponsor { get; set; }

        public static void DoAdmin()
        {
            VisibleCollapsedAuthReg();
            MessagesAdmin.Visibility = System.Windows.Visibility.Visible;
            Sportsmans.Visibility = System.Windows.Visibility.Collapsed;
            Commands.Visibility = System.Windows.Visibility.Collapsed;
            Competitions.Visibility = System.Windows.Visibility.Collapsed;
            ResultCompetitions.Visibility = System.Windows.Visibility.Collapsed;

            SportsmansAdmin.Visibility = System.Windows.Visibility.Visible;
            CommandsAdmin.Visibility = System.Windows.Visibility.Visible;
            CompetitionsAdmin.Visibility = System.Windows.Visibility.Visible;
            NoticesSponsor.Visibility = System.Windows.Visibility.Collapsed;
            ResultCompetitionsAdmin.Visibility = System.Windows.Visibility.Visible;
            MySponsorshipsSponsor.Visibility = System.Windows.Visibility.Collapsed;
        }

        public static void DoViewer()
        {
            VisibleCollapsedAuthReg();

            Sportsmans.Visibility = System.Windows.Visibility.Visible;
            Commands.Visibility = System.Windows.Visibility.Visible;
            Competitions.Visibility = System.Windows.Visibility.Visible;
            ResultCompetitions.Visibility = System.Windows.Visibility.Visible;

            SportsmansAdmin.Visibility = System.Windows.Visibility.Collapsed;
            CommandsAdmin.Visibility = System.Windows.Visibility.Collapsed;
            CompetitionsAdmin.Visibility = System.Windows.Visibility.Collapsed;
            ResultCompetitionsAdmin.Visibility = System.Windows.Visibility.Collapsed;
            MessagesAdmin.Visibility = System.Windows.Visibility.Collapsed;
            NoticesSponsor.Visibility = System.Windows.Visibility.Collapsed;
            MySponsorshipsSponsor.Visibility = System.Windows.Visibility.Collapsed;
        }

        public static void DoSponsor()
        {
            VisibleCollapsedAuthReg();
            
            NoticesSponsor.Visibility = System.Windows.Visibility.Visible;
            MySponsorshipsSponsor.Visibility = System.Windows.Visibility.Visible;
            Sportsmans.Visibility = System.Windows.Visibility.Visible;
            Commands.Visibility = System.Windows.Visibility.Visible;
            Competitions.Visibility = System.Windows.Visibility.Visible;
            ResultCompetitions.Visibility = System.Windows.Visibility.Visible;

            SportsmansAdmin.Visibility = System.Windows.Visibility.Collapsed;
            CommandsAdmin.Visibility = System.Windows.Visibility.Collapsed;
            CompetitionsAdmin.Visibility = System.Windows.Visibility.Collapsed;
            ResultCompetitionsAdmin.Visibility = System.Windows.Visibility.Collapsed;
        }

        public static void VisibleCollapsedAuthReg()
        {
            if (CurrentUser.user != null)
            {
                Registration.Visibility = System.Windows.Visibility.Collapsed;
                Authorization.Visibility = System.Windows.Visibility.Collapsed;
                Exit.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                Registration.Visibility = System.Windows.Visibility.Visible;
                Authorization.Visibility = System.Windows.Visibility.Visible;
                Exit.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}