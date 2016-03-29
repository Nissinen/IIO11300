using MySql.Data.MySqlClient;
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

namespace Tehtava10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string constring = Tehtava10.Properties.Settings.Default.Tietokanta;
        private List<Pelaaja> pelaajat;
        public MainWindow()
        {
            InitializeComponent();
            haePelaajat();
            this.textJoukkue.Items.Add("Blues");
            this.textJoukkue.Items.Add("HIFK");
            this.textJoukkue.Items.Add("HPK");
            this.textJoukkue.Items.Add("Ilves");
            this.textJoukkue.Items.Add("JYP");
            this.textJoukkue.Items.Add("KalPa");
            this.textJoukkue.Items.Add("KooKoo");
            this.textJoukkue.Items.Add("Kärpät");
            this.textJoukkue.Items.Add("Lukko");
            this.textJoukkue.Items.Add("Pelicans");
            this.textJoukkue.Items.Add("SaiPa");
            this.textJoukkue.Items.Add("Sport");
            this.textJoukkue.Items.Add("Tappara");
            this.textJoukkue.Items.Add("TPS");
            this.textJoukkue.Items.Add("Ässät");
        }


        private void HaeKirjatSQL_Click(object sender, RoutedEventArgs e)
        {
            //haetaan kirjat tietokannasta ORM=muunnetaan book-olioiksi
            pelaajat = PelaajaLista.GetPelaajat(true);
            listBox.DataContext = pelaajat;
            listBox.ItemsSource = pelaajat;
        }

        private void haePelaajat()
        {
            //haetaan kirjat tietokannasta ORM=muunnetaan book-olioiksi
            pelaajat = PelaajaLista.GetPelaajat(true);
            listBox.DataContext = pelaajat;
            listBox.ItemsSource = pelaajat;
        }

        private void Tallenna_Click(object sender, RoutedEventArgs e)
        {
            // valittu Book-olio tallennetaan kantaan
            int valittu = listBox.SelectedIndex;
            pelaajat[valittu].Etunimi = textEtunimi.Text;
            pelaajat[valittu].Sukunimi = textSukunimi.Text;
            pelaajat[valittu].Siirtohinta = Convert.ToInt32(textSiirtohinta.Text);
            pelaajat[valittu].Joukkue = textJoukkue.Text;

            ApplyChanges();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int apu = listBox.SelectedIndex;

                if (apu == -1)
                {

                }
                else {
                    textEtunimi.Text = pelaajat[apu].Etunimi;
                    textSukunimi.Text = pelaajat[apu].Sukunimi;
                    textJoukkue.Text = pelaajat[apu].Joukkue;
                    textSiirtohinta.Text = Convert.ToString(pelaajat[apu].Siirtohinta);
                  //  textTuote.Text = pelaajat[apu].ToString();
                    //comboBox.Text = pelaajat[apu].Joukkue;
                    //statusBar.Text = "Pelaajan tiedot tuotiin onnistuneesti";
                }
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void ApplyChanges()
        {
            //päivitetään UI vastaamaan kokoelman tietoja
            listBox.ItemsSource = null;
            listBox.ItemsSource = pelaajat;
        }

        private void LuoUusiPelaaja_Click(object sender, RoutedEventArgs e)
        {
            int index = pelaajat.Count() +1;
            MessageBox.Show(Convert.ToString(index));
            if (!String.IsNullOrEmpty(textEtunimi.Text) && !String.IsNullOrEmpty(textSukunimi.Text) && !String.IsNullOrEmpty(textSiirtohinta.Text))
            {
                try
                {
                    Pelaaja p = new Pelaaja(index, textEtunimi.Text, textSukunimi.Text, textJoukkue.Text, Convert.ToInt32(textSiirtohinta.Text));

                    if (pelaajat.Count >= 1)
                    {
                        for (int i = 0; i < pelaajat.Count; i++)
                        {

                            string muuttuja = Convert.ToString(pelaajat[i]);
                            //     MessageBox.Show(Convert.ToString(pelaajat.Count));
                            //    MessageBox.Show(muuttuja);
                            if (muuttuja == Convert.ToString(p))
                            {
                                System.Windows.MessageBox.Show("Kyseinen pelaaja on jo olemassa");
                                break;
                                //  pelaajat.Add(p);
                            }
                            else {
                                if (i == pelaajat.Count - 1)
                                {
                                    pelaajat.Add(p);
                                    using (MySqlConnection conDataBase = new MySqlConnection(constring))
                                    {
                                        try
                                        {
                                            conDataBase.Open();
                                            string query = @"INSERT INTO pelaajat(Etunimi,Sukunimi,Seura,arvo) values('" + p.Etunimi + "','" + p.Sukunimi + "','" + p.Joukkue + "','" + p.Siirtohinta + "');";
                                            MySqlCommand cmd = new MySqlCommand(query, conDataBase);
                                            MySqlDataReader myReader = cmd.ExecuteReader();
                                            MessageBox.Show("Inserted to Database");
                                            conDataBase.Close();
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }
                                        statusBar.Text = "Pelaaja luotiin onnistuneesti";
                                        break;
                                    }
                                }
                            }

                        }
                    }
                    else
                    {

                        pelaajat.Add(p);
                        statusBar.Text = "Pelaaja luotiin onnistuneesti";
                    }
                    ApplyChanges();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);

                }
            }
            else
            {
                System.Windows.MessageBox.Show("Virheellinen syöte");
            }
        }

        private void PoistaPelaaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int apu = listBox.SelectedIndex;
                Pelaaja apuri = new Pelaaja();
                apuri = pelaajat[apu];
                if (apu == -1)
                {

                }
                else
                {
                    pelaajat.Remove(apuri);
                    using (MySqlConnection conDataBase = new MySqlConnection(constring))
                    {
                        try
                        {
                            conDataBase.Open();
                            string query = "DELETE FROM pelaajat WHERE Id='" + apuri.Id + "';";
                            MySqlCommand cmd = new MySqlCommand(query, conDataBase);
                            MySqlDataReader myReader = cmd.ExecuteReader();
                            MessageBox.Show("Pelaaja poistettu");
                            conDataBase.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    statusBar.Text = "Pelaajan tiedot poistettiin onnistuneesti";
                    ApplyChanges();
                }

            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void TallennaTietokantaan_Click(object sender, RoutedEventArgs e)
        {

            using (MySqlConnection conDataBase = new MySqlConnection(constring))
            {
                try
                {
                    foreach (Pelaaja pelaaja in listBox.Items)
                    {
                        conDataBase.Open();
                        string query = @"UPDATE pelaajat SET Etunimi='" + pelaaja.Etunimi + "', Sukunimi='" + pelaaja.Sukunimi + "', Seura='" + pelaaja.Joukkue + "', arvo='" + pelaaja.Siirtohinta + "' WHERE Id ='" + pelaaja.Id + "'";
                        MySqlCommand cmd = new MySqlCommand(query, conDataBase);
                        MySqlDataReader myReader = cmd.ExecuteReader();
                        conDataBase.Close();
                    }
                    MessageBox.Show("Data Updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}