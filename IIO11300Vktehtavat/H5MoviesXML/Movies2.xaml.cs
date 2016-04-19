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
using System.Windows.Shapes;
using System.Xml;

namespace H5MoviesXML
{
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window
    {
        public Movies2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Tallennetaan muuttunut tieto xml-tiesdostoon
            try
            {
                string filu = xdpMovies.Source.LocalPath;
                xdpMovies.Document.Save(filu);
                MessageBox.Show("Tallennus onnistui");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            //Lisätään XmlDocumenttiin uusi elementti
            //huom textboxit ja lisbox bindattu dataan
            if(lbMovies.SelectedIndex > -1)
            {
                lbMovies.SelectedIndex = -1;
            }
            else{
                //lisätään uusi node
                string filu = xdpMovies.Source.LocalPath;
                //viittaus xmldokumenttiin ja sen juurielementtiin
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                //luodaan uusi node
                XmlNode newMovie = doc.CreateElement("Movie");
                //lisätään nodella tarvittavat neljä attribuuttia
                XmlAttribute attr = doc.CreateAttribute("Name");
                attr.Value = txtName.Text;
                newMovie.Attributes.Append(attr);
                XmlAttribute attr2 = doc.CreateAttribute("Director");
                attr2.Value = txtDirector.Text;
                newMovie.Attributes.Append(attr2);
                XmlAttribute attr3 = doc.CreateAttribute("Country");
                attr3.Value = txtCountry.Text;
                newMovie.Attributes.Append(attr3);
                XmlAttribute attr4 = doc.CreateAttribute("Checked");
                attr4.Value = chkChecked.IsChecked.ToString();
                newMovie.Attributes.Append(attr4);
                //lisää noodin juurielementtiin
                root.AppendChild(newMovie);
                //tallennetaan filuun
                xdpMovies.Document.Save(filu);

            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //Poistetaaan XmlDocumentista elementti
            try
            {
                string filu = xdpMovies.Source.LocalPath;
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                XmlNode poistettava = null;
                //haetaan XPathilla poistettava node
                var item = doc.SelectSingleNode(string.Format("/Movies/Movie[@Name='{0}']", txtName.Text));
                if ((item != null) && (MessageBox.Show(
                  "Poistetaanko elokuva " + txtName.Text, "Esan ElokuvaGalleria",
                  MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                {
                    poistettava = item;
                }
                if (poistettava != null)
                {
                    //poistetaan noodi juuresta
                    root.RemoveChild(poistettava);
                    xdpMovies.Document.Save(filu);
                    //listboxin osoitin
                    lbMovies.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
