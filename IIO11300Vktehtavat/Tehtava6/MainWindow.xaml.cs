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
using System.Xml;
using System.Xml.Linq;


namespace Tehtava6
{

    public partial class MainWindow : Window
    {
        XElement xe;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGetXML_Click(object sender, RoutedEventArgs e)
        {


                try
                {

                    xe = XElement.Load(GetFileName());
                    if (CBWineList.SelectedIndex == -1)
                    {
                        dgData.DataContext = xe.Elements("wine");
                    }
                   else if (CBWineList.SelectedIndex == 0)
                     {
                    dgData.DataContext = xe.Elements("wine");
                     }
                    else if(CBWineList.SelectedIndex == 1)
                    {
                        dgData.DataContext = from ele in xe.Elements() where ele.Element("maa").Value == "Suomi" select ele.Elements("wine");
                    }
                    else if (CBWineList.SelectedIndex == 2)
                    {
                        dgData.DataContext = from ele in xe.Elements() where ele.Element("maa").Value == "France" select ele.Elements("wine");
                    }
                    else if (CBWineList.SelectedIndex == 3)
                    {
                        dgData.DataContext = from ele in xe.Elements() where ele.Element("maa").Value == "Hungary" select ele.Elements("wine");
                    }
                else if (CBWineList.SelectedIndex == 4)
                {
                    dgData.DataContext = from ele in xe.Elements() where ele.Element("maa").Value == "Chile" select ele.Elements("wine");
                }
                else if (CBWineList.SelectedIndex == 5)
                {
                    dgData.DataContext = from ele in xe.Elements() where ele.Element("maa").Value == "Romanien" select ele.Elements("wine");
                }
                else if (CBWineList.SelectedIndex == 6)
                {
                    dgData.DataContext = from ele in xe.Elements() where ele.Element("maa").Value == "South Africa" select ele.Elements("wine");
                }
                tbMessage.Text = GetFileName();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

        }

        private string GetFileName()
        {
            return Tehtava6.Properties.Settings.Default.XMLtiedosto;
        }

    }
}