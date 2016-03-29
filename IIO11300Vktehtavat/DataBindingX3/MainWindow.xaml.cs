using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBindingX3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HockeyLeague smliiga;
        List<HockeyTeam> joukkueet;
        int clicked = 0;
        public MainWindow()
        {
            InitializeComponent();
            FillMyCombobox();
            smliiga = new HockeyLeague();
            joukkueet = smliiga.GetTeams();
        }

        private void FillMyCombobox()
        {
            cbCourses2.Items.Add("IIO12110 Ohjelmitotuotanto");
            cbCourses2.Items.Add("Helppoa ruotsia");
            cbCourses2.Items.Add("ASD");
        }
        private void btnSetUser_Click(object sender, RoutedEventArgs e)
        {
            //luetaan app.configista username-asetus
            txtUsername.Text = "Hello: " + DataBindingX3.Properties.Settings.Default.UserName;
        }

        private void btnBind_Click(object sender, RoutedEventArgs e)
        {
            myGrid.DataContext = joukkueet;
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            clicked++;
            myGrid.DataContext = joukkueet[clicked];
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            clicked--;
            myGrid.DataContext = joukkueet[clicked];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow win = new PlayerWindow();
            win.ShowDialog();
        }
    }
}
