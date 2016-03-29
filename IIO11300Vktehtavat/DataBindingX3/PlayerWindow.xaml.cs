using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace DataBindingX3
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        ObservableCollection<HockeyPlayer> pelaajat;
        int laskuri;
        public PlayerWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            laskuri = 0;
            pelaajat = Get3TestPlayers();
            dgPlayers.ItemsSource = pelaajat;
            SetData();
        }
        private void SetData()
        {
            myGrid.DataContext = pelaajat[laskuri];
        }
        private ObservableCollection<HockeyPlayer> Get3TestPlayers()
        {
            ObservableCollection<HockeyPlayer> temp = new ObservableCollection<HockeyPlayer>();
            temp.Add(new HockeyPlayer("Teemu Selänne", "8"));
            temp.Add(new HockeyPlayer("Jake Immonen", "28"));
            temp.Add(new HockeyPlayer("Tuomo Ruutu", "38"));

            return temp;
        }

        private void dgPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((dgPlayers.SelectedIndex >= 0) & (dgPlayers.SelectedIndex < pelaajat.Count)){
                laskuri = dgPlayers.SelectedIndex;
                SetData();
            }
        }
    }
}
