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

namespace BooksORM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> books;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HaeKirjat_Click(object sender, RoutedEventArgs e)
        {
            //Haetaan pari testi kirja-oliota jotta nähdään toimiiko UI
            try
            {
                books = BookShop.GetTestBooks();
                myDataGrid.DataContext = books;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void HaeKirjatSQL_Click(object sender, RoutedEventArgs e)
        {
            //haetaan kirjat tietokannasta ORM=muunnetaan book-olioiksi
            books = BookShop.GetBooks(true);
            myDataGrid.DataContext = books;
        }

        private void Tallenna_Click(object sender, RoutedEventArgs e)
        {
            // valittu Book-olio tallennetaan kantaan
            try
            {
                Book current = (Book)spBook.DataContext;
                BookShop.UpdateBook(current);
                MessageBox.Show(string.Format("Kirja {0} päivitetty kantaan onnistuneesti", current.ToString()));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spBook.DataContext = myDataGrid.SelectedItem;
        }
    }
}
