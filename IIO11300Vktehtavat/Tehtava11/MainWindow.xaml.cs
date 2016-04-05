using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using System.Collections.ObjectModel; // for observablecollection
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Tehtava11;

namespace Tehtava11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SMLiigaEntities1 ctx;
        ObservableCollection<Pelaajat> localPelaajat;
        ICollectionView view; //DataGridin filtteröintiä varten


        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
       //     haePelaajat();
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

        private void IniMyStuff()
        {
            //luodaan konteksti = datasisältö
            ctx = new SMLiigaEntities1();
            //lataan kirjatiedot paikalliseksi
            ctx.Pelaajats.Load();
            localPelaajat = ctx.Pelaajats.Local;
            //täytetään comboboxi kirjalijoitten maitten nimillä
            //huom Lambda tyylin LINQ kysely
           // cbCountries.DataContext = localBooks.Select(n => n.country).Distinct();
            //luodaan view
            view = CollectionViewSource.GetDefaultView(localPelaajat);
        }


        private void HaePelaajat_Click(object sender, RoutedEventArgs e)
        {
            //haetaan kirjat tietokannasta ORM=muunnetaan book-olioiksi
         //   pelaajat = PelaajaLista.GetPelaajat(true);
            listBox.DataContext = localPelaajat;
          //  listBox.ItemsSource = localPelaajat;
            listBox.DisplayMemberPath = "Kokonimi";
        }


        private void Tallenna_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                statusBar.Text = ex.Message;
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

                spTiedot.DataContext = listBox.SelectedItem;
        }

        private void LuoUusiPelaaja_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi kirja-olio ensin kontekstiin ja sitten tietokantaan
            Pelaajat newPelaaja;
            try
            {
                if (btnUusi.Content.ToString() == "LuoUusiPelaaja")
                {
                    //luodaan uusi Book-olio
                    newPelaaja = new Pelaajat();
                    newPelaaja.etunimi = "Anna Pelaajan nimi";
                    spBook.DataContext = newPelaaja;
                    btnUusi.Content = "Tallenna kantaan";
                }
                else
                {
                    //lisätään uusi kirja ensin kontekstiiin ja sieltä kantaan
                    newPelaaja = (Pelaajat)spTiedot.DataContext;
                    ctx.Pelaajats.Add(newPelaaja);
                    ctx.SaveChanges();
                    btnUusi.Content = "LuoUusiPelaaja";
                    statusBar.Text = "Pelaaja " + newPelaaja.Kokonimi + " lisätty kantaan...";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex));
            }
        }

        private void PoistaPelaaja_Click(object sender, RoutedEventArgs e)
        {
            //poistetaan valittu kirja-olio kontekstiksi ja sitten kannasta
            Pelaajat current = (Pelaajat)spTiedot.DataContext;
            var retval = MessageBox.Show("Haluatko varmasti poistaa pelaajan ",
              "PelaajaLista", MessageBoxButton.YesNo);
            if (retval == MessageBoxResult.Yes)
            {
                ctx.Pelaajats.Remove(current);
                ctx.SaveChanges();
            }
        }
    }
}
