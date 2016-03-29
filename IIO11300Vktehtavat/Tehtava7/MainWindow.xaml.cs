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

namespace Tehtava7
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
        //salasanan tarkistus
        private void passwordCheck()
        {
            string salasana = Convert.ToString(pwSalasana.Password);
            string pwLength = Convert.ToString(pwSalasana.Password.Length);
            txtMerkit.Text ="Merkkejä: " + pwLength;
            txtPienetKirjaimet.Text ="Pieniä kirjaimia: " + checkLowerCase(salasana);
            txtIsotKirjaimet.Text = "Isoja kirjaimia: " + checkUpperCase(salasana);
            txtNumerot.Text = "Numeroita: " + checkNumbers(salasana);
            txtErikoismerkit.Text = "Erikoismerkkejä: " + checkMarks(salasana);
            if (pwSalasana.Password.Length > 15 && checkLowerCase(salasana) > 0 && checkUpperCase(salasana) > 0 && checkNumbers(salasana) > 0 && checkMarks(salasana) > 0)
            {
                txtVahvuus.Background = Brushes.Green;
                txtVahvuus.Text = "Erinomainen Salasana";
            }
            else if (pwSalasana.Password.Length > 10 && checkLowerCase(salasana) > 0 && checkUpperCase(salasana) > 0 && checkNumbers(salasana) > 0 ||
                pwSalasana.Password.Length > 10 && checkLowerCase(salasana) > 0 && checkUpperCase(salasana) > 0 && checkMarks(salasana) > 0 ||
                pwSalasana.Password.Length > 10 && checkLowerCase(salasana) > 0 && checkNumbers(salasana) > 0 && checkMarks(salasana) > 0 ||
                pwSalasana.Password.Length > 10 && checkUpperCase(salasana) > 0 && checkNumbers(salasana) > 0 && checkMarks(salasana) > 0)
            {
                txtVahvuus.Background = Brushes.LightGreen;
                txtVahvuus.Text = "Hyvä Salasana";
            }
            else if (pwSalasana.Password.Length > 5 && checkLowerCase(salasana) > 0 && checkUpperCase(salasana) > 0 ||
                pwSalasana.Password.Length > 5 && checkLowerCase(salasana) > 0 && checkNumbers(salasana) > 0 ||
                pwSalasana.Password.Length > 5 && checkUpperCase(salasana) > 0 && checkNumbers(salasana) > 0)
            {
                txtVahvuus.Background = Brushes.Yellow;
                txtVahvuus.Text = "Kohtalainen Salasana";
            }

           else if(pwSalasana.Password.Length > 0)
            {
                txtVahvuus.Background = Brushes.Orange;
                txtVahvuus.Text = "Heikko Salasana";
            }
            else if(pwSalasana.Password.Length < 1)
            {
                txtVahvuus.Background = Brushes.Gray;
                txtVahvuus.Text = "Anna Salasana";
            }

        }
        //Pienten kirjainten tsekkaus
        private int checkLowerCase(string salasana)
        {
            int laskuri = 0;
            for (int i = 0; i < salasana.Length; i++)
            {
                if (char.IsLower(salasana[i]))
                {
                    laskuri++;
                }
            }
            return laskuri;
        }
        // Isojen kirjainten tsekkaus
        private int checkUpperCase(string salasana)
        {
            int laskuri = 0;
            for (int i = 0; i < salasana.Length; i++)
            {
                if (char.IsUpper(salasana[i]))
                {
                    laskuri++;
                }
            }

            return laskuri;
        }
        // Numeroiden Tsekkaus
        private int checkNumbers(string salasana)
        {
            int laskuri = 0;
            for (int i = 0; i < salasana.Length; i++)
            {
                if (char.IsNumber(salasana[i]))
                {
                    laskuri++;
                }
            }
            return laskuri;
        }
        //Merkkien tsekkaus
        private int checkMarks(string salasana)
        {
            int laskuri = 0;
            for (int i = 0; i < salasana.Length; i++)
            {
                if (char.IsPunctuation(salasana[i]))
                {
                    laskuri++;
                }
            }
            return laskuri;
        }
        //päivitys
        private void pwSalasana_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordCheck();

        }
    }
}
