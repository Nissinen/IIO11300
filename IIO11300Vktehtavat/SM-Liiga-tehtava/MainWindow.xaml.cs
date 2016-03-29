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
using System.Windows.Forms;
using System.IO;

namespace SM_liiga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filu;
        string extension;
        List<Pelaaja> pelaajat;
        Pelaaja apuri = new Pelaaja();
        public MainWindow()
        {
            InitializeComponent();
            Init();


        }
        private void Init()
        {
            //omat ikkunaan liittyvät alustukset
            pelaajat = new List<Pelaaja>();
            comboBox.SelectedIndex = 0;

        }

        private void btnLuo_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(EtunimiTXT.Text) && !String.IsNullOrEmpty(SukunimiTXT.Text) && !String.IsNullOrEmpty(SiirtohintaTXT.Text))
            {
                try
                {
                    Pelaaja p = new Pelaaja(EtunimiTXT.Text, SukunimiTXT.Text, SiirtohintaTXT.Text, comboBox.Text);

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
                                    statusBar.Text = "Pelaaja luotiin onnistuneesti";
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {

                        pelaajat.Add(p);
                        statusBar.Text = "Pelaaja luotiin onnistuneesti";
                    }
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

            ApplyChanges();
        }// end of Luo
         
        private void btnLopetus_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }// end of Lopetus

        private void btnTalleta_Click(object sender, RoutedEventArgs e)
        {
            int valittu = listBox.SelectedIndex;
            pelaajat[valittu].Etunimi = EtunimiTXT.Text;
            pelaajat[valittu].Sukunimi = SukunimiTXT.Text;
            pelaajat[valittu].Siirtohinta = SiirtohintaTXT.Text;
            pelaajat[valittu].Joukkue = comboBox.Text;

            ApplyChanges();
        } // end of Talleta

        private void ApplyChanges()
        {
            //päivitetään UI vastaamaan kokoelman tietoja
            listBox.ItemsSource = null;
            listBox.ItemsSource = pelaajat;
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
                    EtunimiTXT.Text = pelaajat[apu].Etunimi;
                    SukunimiTXT.Text = pelaajat[apu].Sukunimi;
                    SiirtohintaTXT.Text = pelaajat[apu].Siirtohinta;
                    comboBox.Text = pelaajat[apu].Joukkue;
                    statusBar.Text = "Pelaajan tiedot tuotiin onnistuneesti";
                }
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }


        }

        private void btnPoista_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int apu = listBox.SelectedIndex;

                apuri = pelaajat[apu];
                if (apu == -1)
                {

                }
                else
                {
                    pelaajat.Remove(apuri);
                    statusBar.Text = "Pelaajan tiedot poistettiin onnistuneesti";
                    ApplyChanges();
                }

            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnKirjoita_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File | *.txt |XML File | *.xml";

            try
            {
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filu = sfd.FileName;
                    extension = System.IO.Path.GetExtension(filu);
                  //  string extension = Path.GetExtension(saveDialog.FileName);

                }
                System.Windows.MessageBox.Show(filu);
                //    sfd.ShowDialog();
                if (extension == ".txt")
                {
                    Pelaaja.SaveDataToFile(pelaajat, filu);
                    System.Windows.MessageBox.Show("Tiedot tallennettu onnistuneesti tiedostoon " + filu);
                }
                else if (extension == ".xml")
                {
                    SM_Liiga_tehtava.Serialisointi.SerialisoiXml(filu, pelaajat);
                }
                else
                {
                    System.Windows.MessageBox.Show("Väärä tiedosto muoto!");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Lue_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt|XML Files (*.xml)|*.xml";
            try
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filu = ofd.FileName;
                    extension = System.IO.Path.GetExtension(filu);
                }
                if (extension == ".txt")
                {
                    System.Windows.MessageBox.Show(extension);
                    pelaajat = null;
                    pelaajat = Pelaaja.ReadDataFromFile(filu);
                    ApplyChanges();
                    System.Windows.MessageBox.Show("Tiedot luettu onnistuneesti tiedostosta ");
                }
                else if (extension == ".xml")
                {
                    pelaajat = null;
                   pelaajat = SM_Liiga_tehtava.Serialisointi.DeSerialisoiXml(filu);
                    System.Windows.MessageBox.Show("Deserialisointi ok");
                    ApplyChanges();
                }
                else{
                    System.Windows.MessageBox.Show("Väärä tiedosto muoto!");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
