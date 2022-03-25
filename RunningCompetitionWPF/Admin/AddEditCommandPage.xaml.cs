using CoreFramework;
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

namespace RunningCompetitionWPF.Admin
{
    /// <summary>
    /// Логика взаимодействия для AddEditCommandPage.xaml
    /// </summary>
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
            comboImages.ItemsSource = Connection.GetImages();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentCommand.idCommand == 0)
                ConnectionCommands.AddCommand(CurrentCommand);
            else
                ConnectionCommands.UpdateCommand(CurrentCommand);

            try
            {
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
