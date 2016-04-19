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

namespace viiniTesti
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
                kaupunki = item["Country"].ToString();
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
                string tietokanta = viiniTesti.Properties.Settings.Default.conffi + kayttaja.Text + "; password = " + salasana.Text + ";";
                using (SqlConnection conn = new SqlConnection(tietokanta))
                {
                    dt = new DataTable();
                    string sql = "SELECT * FROM wine";
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
            dv.RowFilter = string.Format("Country LIKE '{0}'", cbCities.SelectedValue);
            int lukema = lbCustomers.Items.Count;
            MessageBox.Show(Convert.ToString(lukema -1) + " viiniä " + Convert.ToString(cbCities.SelectedValue));
        }
    }
}
