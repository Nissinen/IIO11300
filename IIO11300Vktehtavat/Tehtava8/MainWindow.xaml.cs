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

namespace Tehtava8
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
        private void GetData()
        {
            try
            {
                using (SqlConnection conn =
                  new SqlConnection(Tehtava8.Properties.Settings.Default.Tietokanta))
                {
                    //yhteys
                    //dataadapter
                  //  string sql = "SELECT lastname, firstname, address, city FROM vCustomers Where lastname = 'Yolopainen'";
                    string sql = "SELECT lastname FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("Lasnaolot");
                    da.Fill(dt);
                    //sidotaan datatable UI-kontrolliin
                    myGrid.DataContext = dt;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetData2(string sukunimi)
        {
            try
            {
                using (SqlConnection conn =
                  new SqlConnection(Tehtava8.Properties.Settings.Default.Tietokanta))
                {
                    //yhteys
                    //dataadapter
                    string snimi = "'"+sukunimi+"'";
                      string sql = "SELECT lastname, firstname, address, city FROM vCustomers Where lastname = " + snimi;
                 //   MessageBox.Show(sql);
                   // string sql = "SELECT lastname FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("Lasnaolot");
                    da.Fill(dt);
                    //sidotaan datatable UI-kontrolliin
                    tempDG2.DataContext = dt;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Hae_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void myGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((myGrid.SelectedIndex >= 0) & (myGrid.SelectedIndex < myGrid.Items.Count - 2))
            {
    

                DataRowView dataRow = (DataRowView)myGrid.SelectedItem;

                int index = myGrid.CurrentCell.Column.DisplayIndex;

                string cellValue = dataRow.Row.ItemArray[index].ToString();
                
                GetData2(cellValue);
              //  MessageBox.Show(cellValue);

                string t = tempDG2.ToString();
                
                DataRowView dataRow2 = (DataRowView)tempDG2.Items[0];
                string suku = dataRow2.Row.ItemArray[0].ToString();
                sukunimiBox.Text = suku;
                string etu = dataRow2.Row.ItemArray[1].ToString();
                etunimiBox.Text = etu;
                string osote = dataRow2.Row.ItemArray[2].ToString();
                osoiteBox.Text = osote;
                string city = dataRow2.Row.ItemArray[3].ToString();
                cityBox.Text = city;
                //     MessageBox.Show(cellValue2);
            }
        }
    }
}
