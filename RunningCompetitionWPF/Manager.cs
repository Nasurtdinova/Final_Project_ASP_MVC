using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RunningCompetitionWPF
{
    class Manager
    {
        public static Frame MainFrame { get; set; }
        public static Menu MainMenu { get; set; }

        public static MenuItem CompetitionsAdmin { get; set; }
        public static MenuItem Competitions { get; set; }

        public static MenuItem ResultCompetitionsAdmin { get; set; }
        public static MenuItem ResultCompetitions { get; set; }
    }
}
