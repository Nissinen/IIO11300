using System;
using System.Data; // for general ADO-classes
using System.Data.SqlClient; // for SQL Serve specific classes
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

namespace ViiniAsiakkaat
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

        private void IniMyStuff()
        {
            cities = new List<string>();
            //VE1 kaupungin nimet kovakoodattu
            /*  cities.Add("Jyväskylä");
              cities.Add("Helsinki");
              cities.Add("New York");*/
            //VE2 käydään loopittamalla DataTAble läpi
              string kaupunki = "";
            foreach (DataRow item in dt.Rows)
            {
                kaupunki = item["City"].ToString();
                //lisätään kukin kaupunki vain kerran listaan
                if (!cities.Contains(kaupunki))
                {
                    cities.Add(kaupunki);
                }
            }
            //VE3 LINQ:lla voi tehdä kyselyn tyypitettyyn DataTableen, huom ei kaikille DataTableille
            //joten ei toimi tässä
          //  var result = (from c in dt select c.City).Distinct();
            //databindaus
            cbCities.ItemsSource = cities;
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
                // huom DataTablen sarake (column) on casesensitiivinen
                lbCustomers.DisplayMemberPath = "Lastname";
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
        }

        #region METHODS
        private void GetData()
        {
            //luodaan yhteys tietokantaan connetionstringin avulla
            try
            {
                using (SqlConnection conn = new SqlConnection(ViiniAsiakkaat.Properties.Settings.Default.Tietokanta))
                {
                   dt = new DataTable();
                    string sql = "SELECT * FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    // pistetään dataadapter hakemaan tiedot muistiin=DataTableen
                    da.Fill(dt);
                    conn.Close();
                    IniMyStuff();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Asetetaan dataview:llä filtteri
            dv.RowFilter = string.Format("City LIKE '{0}'", cbCities.SelectedValue);
        }
    }
}
