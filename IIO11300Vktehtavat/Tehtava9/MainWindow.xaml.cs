using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Tehtava9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataView dv;
        DataTable dt;
        List<string> cities;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            //haetaan viiniasiakkaat palvelimelta ja näytetään ne listboxissa
            try
            {
                GetData();
                //VE1 dataview filtteroitte tai sorttaatte
                dv = dt.DefaultView;
                //datan sitominen UI-kontrolliin, kelpaa DataTable,DataView, datareader
                lbCustomers.DataContext = dv;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vaihdetaan stackpanelin datacontext viittaamaan valittuunn asiakkaaseen
            spCustomer.DataContext = lbCustomers.SelectedItem;
            selectedCustomer.DataContext = lbCustomers.SelectedItem;
            indexNumber.Text = Convert.ToString(lbCustomers.SelectedIndex + ".");
        }

        #region METHODS
        private void GetData()
        {
            //luodaan yhteys tietokantaan connetionstringin avulla
            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9.Properties.Settings.Default.Tietokanta))
                {
                    dt = new DataTable();
                    string sql = "SELECT * FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    // pistetään dataadapter hakemaan tiedot muistiin=DataTableen
                    da.Fill(dt);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            spCustomer.Visibility = Visibility.Visible;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string lastname = selectedLastName.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(Tehtava9.Properties.Settings.Default.Tietokanta))
                {
                    conn.Open();


                    string sql = string.Format("DELETE FROM customer WHERE lastname='{0}'", lastname);
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    using (SqlCommand command = new SqlCommand(
                    sql, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            btnGetData_Click(new object(), new RoutedEventArgs());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Haluatko varmasti luoda uuden käyttäjän?", "TARKISTAJA", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                spCustomer.Visibility = Visibility.Collapsed;
                string firstname = etunimi.Text;
                string lastname = sukunimi.Text;
                string address = osoite.Text;
                string city = kaupunki.Text;

                try
                {
                    using (SqlConnection conn = new SqlConnection(Tehtava9.Properties.Settings.Default.Tietokanta))
                    {
                        conn.Open();
                        
                        
                            string sql = string.Format("INSERT INTO customer (firstname, lastname, address, city) VALUES ('{0}','{1}','{2}','{3}')", firstname, lastname, address, city);
                            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                            using (SqlCommand command = new SqlCommand(
                            sql, conn))
                            {
                                command.ExecuteNonQuery();
                            }
                        conn.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                btnGetData_Click(new object(), new RoutedEventArgs());
            }

        }
    }
}
