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
using System.Collections;
using System.Collections.ObjectModel; // for observablecollection
using System.ComponentModel;
using System.Data.Entity;

namespace BookShopEF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
    {
        BookShopEntities ctx;
        ObservableCollection<Book> localBooks;
        ICollectionView view; //DataGridin filtteröintiä varten
        bool IsBooks; //onko gridissä kirjat vai asiakkaat
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            //luodaan konteksti = datasisältö
            ctx = new BookShopEntities();
            //lataan kirjatiedot paikalliseksi
            ctx.Books.Load();
            localBooks = ctx.Books.Local;
            //täytetään comboboxi kirjalijoitten maitten nimillä
            //huom Lambda tyylin LINQ kysely
            cbCountries.DataContext = localBooks.Select(n => n.country).Distinct();
            //luodaan view
            view = CollectionViewSource.GetDefaultView(localBooks);
        }
        private void btnNayta_Click(object sender, RoutedEventArgs e)
        {
            //haetaan EDM navigaatio-ominaisuuksien avulla valitun asiakkaan tilaukset ja sen kirjat
            string msg = "";
            Customer current = (Customer)spCustomer.DataContext;
            msg += string.Format("Asiakkaan {0} tilaukset \n", current.lastname);
            foreach (var tilaus in current.Orders)
            {
                msg += string.Format("Tilaus {0} sisältää {1} tilausriviä:\n",
                  tilaus.odate, tilaus.Orderitems.Count);
                //loopitetaan tilauksen tilausrivit
                foreach (var tilausrivi in tilaus.Orderitems)
                {
                    msg += string.Format("- kirja {0}\n", tilausrivi.Book.name);
                }
            }
            MessageBox.Show(msg);
        }

        private void btnTallenna_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                tbMessage.Text = ex.Message;
            }
        }

        private void btnHaeKirjat_Click(object sender, RoutedEventArgs e)
        {
            //haetaan kirjat DataGridiin
            //Vaihtoehto 1
            //dgBooks.DataContext = ctx.Books.ToList();
            dgBooks.DataContext = localBooks;
            //Vaihtoehto 2 käytetään paikallista muuttujaa
            IsBooks = true;
            //mahdollinen filtteröinti pois
            cbCountries.SelectedIndex = -1;
        }

        private void btnHaeAsiakkaat_Click(object sender, RoutedEventArgs e)
        {
            //haetaan asiakkaat
            dgBooks.DataContext = ctx.Customers.ToList();
            IsBooks = false;
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //näytetään valitun entiteetin tiedot stackpanelissa
            if (IsBooks)
                spBook.DataContext = dgBooks.SelectedItem;
            else
                spCustomer.DataContext = dgBooks.SelectedItem;
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //asetetaan filtteri päälle = kutsutaan ns predikaattifunktiota
            view.Filter = MyCountryFilter;
        }
        private bool MyCountryFilter(object item)
        {
            if (cbCountries.SelectedIndex == -1)
                return true;
            else
                return (item as Book).country.Contains(cbCountries.SelectedItem.ToString());
        }

        private void btnUusi_Click(object sender, RoutedEventArgs e)
        {
            //luodaan uusi kirja-olio ensin kontekstiin ja sitten tietokantaan
            Book newBook;
            if (btnUusi.Content.ToString() == "Uusi")
            {
                //luodaan uusi Book-olio
                newBook = new Book();
                newBook.name = "Anna kirjan nimi";
                spBook.DataContext = newBook;
                btnUusi.Content = "Tallenna kantaan";
            }
            else
            {
                //lisätään uusi kirja ensin kontekstiiin ja sieltä kantaan
                newBook = (Book)spBook.DataContext;
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                btnUusi.Content = "Uusi";
                tbMessage.Text = "Kirja " + newBook.DisplayName + " lisätty kantaan...";
            }
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            //poistetaan valittu kirja-olio kontekstiksi ja sitten kannasta
            Book current = (Book)spBook.DataContext;
            var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan " + current.DisplayName,
              "Wanhat kirjat kysyy", MessageBoxButton.YesNo);
            if (retval == MessageBoxResult.Yes)
            {
                ctx.Books.Remove(current);
                ctx.SaveChanges();
            }
        }
    }
}