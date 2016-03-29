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

namespace Tehtava3C
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"c:\Ohjelmat\TEST\";

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                listBox.Items.Clear();
                path.Text = fbd.SelectedPath;
                string[] files = Directory.GetFiles(fbd.SelectedPath, "*.txt");

                //string ex = System.IO.Path.GetExtension(fbd.SelectedPath);


                foreach (string file in files)
                {

                        listBox.Items.Add(System.IO.Path.GetFileName(file));
                    
                }
            }


        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            string text = "";
            string fileLocation = path.Text;
            string fileText = "";

            SaveFileDialog save = new SaveFileDialog();

            foreach (var item in listBox.SelectedItems)
            {
                fileLocation = path.Text + "\\" + item.ToString();
                try {
                    fileText = System.IO.File.ReadAllText(fileLocation);
                }
                catch(Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
                text = text + fileText;
           }

            save.InitialDirectory = @"c:\Ohjelmat\TEST\";
            try
            {
                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter write = new StreamWriter(File.Create(save.FileName));
                    textBox.Text = save.InitialDirectory + System.IO.Path.GetFileName(save.FileName);
                    write.Write(text);
                    write.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
