/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016, Modified 13.1.2016
* Authors:Olli Nissinen, Esa Salmikangas
*/using System;
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

namespace Tehtava1
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

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {
                Int32 val1 = Convert.ToInt32(txtHeight.Text);
                Int32 val2 = Convert.ToInt32(txtWidht.Text);
                Int32 karmi = Convert.ToInt32(txtSide.Text);
                Int32 PA = val1 * val2;
                Int32 piiri = val1 * 2 + val2 * 2;
                Int32 val5 = ((val1 + karmi) * (val2 + karmi) - PA);
                txtResoult.Text = PA.ToString();
                txtResoult2.Text = val5.ToString();
                txtResoult3.Text = piiri.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
            System.Environment.Exit(1);
        }

        private void btnCalculateArea_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JAMK.IT.IIO11300.Ikkuna ikk = new JAMK.IT.IIO11300.Ikkuna();
                ikk.Korkeus = double.Parse(txtHeight.Text);
                ikk.Leveys = double.Parse(txtWidht.Text);
                //tulosta käyttäjälle
                // vaihtroehto metodilla
                // MessageBox.Show(ikk.LaskePintaAla().ToString());
                //Vaihtroehto property
                MessageBox.Show(ikk.PintaAla.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class BusinessLogicWindow
    {
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
    public static double CalculatePerimeter(double widht, double height)
        {
            throw new System.NotImplementedException();
        }
    }
}
