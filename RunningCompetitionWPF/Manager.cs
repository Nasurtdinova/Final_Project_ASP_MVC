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

        public static Button Authorization { get; set; }
        public static Button Registration { get; set; }
        public static Button Exit { get; set; }

        public static MenuItem SportsmansAdmin { get; set; }
        public static MenuItem Sportsmans { get; set; }

        public static MenuItem CommandsAdmin { get; set; }
        public static MenuItem Commands { get; set; }

        public static MenuItem CompetitionsAdmin { get; set; }
        public static MenuItem Competitions { get; set; }

        public static MenuItem ResultCompetitionsAdmin { get; set; }
        public static MenuItem ResultCompetitions { get; set; }


        public static void DoAdmin()
        {
            CollapsedAuthReg();
            Exit.Visibility = System.Windows.Visibility.Visible;
            Sportsmans.Visibility = System.Windows.Visibility.Collapsed;
            //Commands.Visibility = System.Windows.Visibility.Collapsed;
            Competitions.Visibility = System.Windows.Visibility.Collapsed;
            ResultCompetitions.Visibility = System.Windows.Visibility.Collapsed;

            SportsmansAdmin.Visibility = System.Windows.Visibility.Visible;
            //CommandsAdmin.Visibility = System.Windows.Visibility.Visible;
            CompetitionsAdmin.Visibility = System.Windows.Visibility.Visible;
            ResultCompetitionsAdmin.Visibility = System.Windows.Visibility.Visible;
        }

        public static void CollapsedAuthReg()
        {            
            Registration.Visibility = System.Windows.Visibility.Collapsed;
            Authorization.Visibility = System.Windows.Visibility.Collapsed;
        }

        public static void VisibleAuthReg()
        {
            Registration.Visibility = System.Windows.Visibility.Visible;
            Authorization.Visibility = System.Windows.Visibility.Visible;
        }

    }
}
