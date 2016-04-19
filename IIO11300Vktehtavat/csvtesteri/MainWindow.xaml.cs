using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;

namespace csvtesteri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataView dv = new DataView();
        DataTable dt = new DataTable();
        public MainWindow()
        {
            InitializeComponent();
            Ini();
        }

        public void Ini()
        {
            string[] rawtext = System.IO.File.ReadAllLines(@"C:\Users\Olli\Desktop\asiakkaat.csv");
            string[] datacol = null;
            int x = 0;
            foreach (string line in rawtext)
            {
                datacol = line.Split(';');
                if (x == 0)
                {
                    for (int i = 0; i <= datacol.Count() - 1; i++)
                    {
                        dt.Columns.Add(datacol[i]);
                    }

                    x++;
                }
                else
                {
                    dt.Rows.Add(datacol);
                }
            }
            dv = dt.DefaultView;
           myDataGrid.DataContext = dv;
        }

        private void Save_click(object sender, RoutedEventArgs e)
        {
            //Lisätään XmlDocumenttiin uusi elementti
            //huom textboxit ja lisbox bindattu dataan
            XmlDocument doc = new XmlDocument();
            string filu = Tiedosto.Text;
      //      if (!File.Exists(filu))
       //     {
                //Populate with data here if necessary, then save to make sure it exists

                XmlNode rootNode = doc.CreateElement("users");
                doc.AppendChild(rootNode);

                string[] rawtext = System.IO.File.ReadAllLines(@"C:\Users\Olli\Desktop\asiakkaat.csv");

            XElement cust = new XElement("Root",
     from str in rawtext
     let fields = str.Split(';')
     select new XElement("Customer",
         new XElement("Nimi", fields[0]),
         new XElement("Yhteyshenkilö", fields[1]),
         new XElement("Katuosoite", fields[2]),
         new XElement("Postinumero", fields[3]),
         new XElement("Postitoimipaikka", fields[4]),
         new XElement("Myynti", fields[5])
));
            Console.WriteLine(cust);
            doc.Save(filu);
            File.WriteAllText(@"C:\Users\Olli\Desktop\asiakkaat.xml", Convert.ToString(cust));

        }
    }
}
