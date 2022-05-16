using System;
using System.Collections.Generic;
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

namespace WPFDatagrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Futo> futoList;  // globális lista
        List<string> egyesuletList;
        public MainWindow()
        {
            InitializeComponent();

            futoList = new List<Futo>(); //listába helyezés
            egyesuletList = new List<string>();
            string[] sorok = File.ReadAllLines("Futo.csv", encoding: Encoding.UTF8);
            foreach (string sor in sorok)
            {
                if (sor != "" && !sor.Contains("fid")) //A ReadAllLines miatt kell az első és üres sor kihagyása
                {
                    Futo futo = new Futo(sor);
                    futoList.Add(futo);
                    if (egyesuletList.Contains(futo.Egyesulet) == false ) // listázáshoz
                    {
                        egyesuletList.Add(futo.Egyesulet);
                    }
                }
            }
            dataGrid.ItemsSource = futoList;
            comboBox.ItemsSource = egyesuletList;
            


        }

        private void button_hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_futoNev.Text != "" && textBox_egyesulet.Text != "" )
            {
                int futoid = futoList.Max(f => f.FutoId) + 1; // autoid
                string futoNev = textBox_futoNev.Text;
                string egyesulet = textBox_egyesulet.Text;

                Futo futo = new Futo()
                {
                    FutoId = futoid,
                    FutoNev = futoNev,
                    Egyesulet = egyesulet
                };


                if (egyesuletList.Contains(egyesulet) == false)
                {
                    egyesuletList.Add(egyesulet);
                    comboBox.ItemsSource = egyesuletList;
                    comboBox.Items.Refresh();
                }

                comboBox.SelectedIndex = -1; // alapértelmezet üres egyesület
                futoList.Add(futo);
                dataGrid.ItemsSource = futoList;
                dataGrid.Items.Refresh();
                // DataGrid.SelectedIndex = futoid - 1;

                // fájlba írás // nem szükséges

                StreamWriter sr = new StreamWriter("futo.csv", append: true, encoding: Encoding.UTF8);
                string ujsor = $"\n{futoid};{futoNev};{egyesulet}";
                sr.WriteLine(ujsor);
                sr.Close();


            }
            else
            {
                MessageBox.Show("A mezőket ki kell tölteni!", caption: "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning); //ha üres a textbox
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // szürés
        {
            List<Futo> valasztottEgyesuletList = new List<Futo>();
            string egyesuletNev = comboBox.SelectedItem as string;
            foreach (Futo futo in futoList)
            {
                if (futo.Egyesulet == egyesuletNev)
                {
                    valasztottEgyesuletList.Add(futo);
                }
            }
            dataGrid.ItemsSource = valasztottEgyesuletList;

        }

        private void button_osszes_Click(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = -1;

            dataGrid.ItemsSource = futoList;
            // DataGrid.Items.Refresh();
        }

        private void button_torles_Click(object sender, RoutedEventArgs e)
        {
            
            if (dataGrid.SelectedItems.Count > 0)
            {
                Futo futoKivalasztott = (Futo)comboBox.SelectedItem;
                string elem = dataGrid.SelectedItems.Count == 1 ? "elemet" : "elemeket";
                MessageBoxResult result = MessageBox.Show($"Biztos, hogy törölni szeretnéd a kijelölt {elem}?", caption: "Kérdés", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                    //foreach (var item in dataGrid.SelectedItems)
                    foreach (Futo item in dataGrid.SelectedItems)
                    {
                        futoList.Remove(item as Futo);
                    }
                    dataGrid.Items.Refresh();

            }
            else
            {
                MessageBox.Show("A törléshez egy sort ki kell választani!", caption: "Figyelmeztetés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
