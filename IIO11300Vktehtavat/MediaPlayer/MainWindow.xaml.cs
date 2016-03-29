using Microsoft.Win32;
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

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           // LoadMediaFile();
        }

        private void LoadMediaFile()
        {
            try
            {
                // Ladataan käyttäjän anatama mediatiedostosta
                //  string filu = @"D:\CoffeeMaker.mp4";
                string filu = txtFileName.Text;
                // tutkitaan onko tiedosto olemassa
                if (System.IO.File.Exists(filu))
                {
                    mediaElement.Source = new Uri(filu);
                    mediaElement.Play();
                }
                else
                {
                    MessageBox.Show("Tiedostoa " + filu + " ei löydy.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPause(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void btnStop(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            ChangeButtonsState();
        }

        private void btnPlay(object sender, RoutedEventArgs e)
        {
            LoadMediaFile();
            mediaElement.Play();
            //muutetaan nappuloitten tilaa
            ChangeButtonsState();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            // avataan vakio Open-dialogi jotta käyttäjä voi valita yhden tiedoston.
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "d:\\H8593";
            dlg.Filter = "Rock files (*.mp3)|*.mp3|Media files(*.wmv)|*.wmv|All files(*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if(result == true)
            {
                txtFileName.Text = dlg.FileName;
            }
        }
        private void ChangeButtonsState()
        {
            pause.IsEnabled = !pause.IsEnabled; // pause
            stop.IsEnabled = !stop.IsEnabled; // stop
            play.IsEnabled = !play.IsEnabled; //play
        }
    }

}

