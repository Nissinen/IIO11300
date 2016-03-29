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

namespace WinLotto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnDraw(object sender, RoutedEventArgs e)
        {
            try
            {
                WinLotto.BLLotto lot = new WinLotto.BLLotto();
                lot.Rivit = Convert.ToInt32(textDraw.Text);
                /*    Int32 luku = 0;
                    string jono = "";
                    Random r = new Random();
                    for (int i = 0; i < lot.Rivit; i++)
                    {
                        for(int j = 0; j < 7; j++)
                        {
                            luku = r.Next(1, 39);
                            jono = jono + " " + luku.ToString();
                        }
                        jono = jono + Environment.NewLine;
                        textTulosta.Text = jono.ToString();
                    }*/
                if (comboBox.SelectedIndex == 0)  { textTulosta.Text = lot.TulostaSuomiRivit(); }

                if (comboBox.SelectedIndex == 1) { textTulosta.Text = lot.TulostaVikingRivit(); }
               
                if (comboBox.SelectedIndex == 2) { textTulosta.Text = lot.TulostaEuroRivit(); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            textTulosta.Text = "";
        }
    }
}
