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

namespace Wpf_Datagrid2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Teglalap lista létrehozása
        List<Teglalap> teglalapList = new List<Teglalap>();

        //StreamReader létrehozása
        StreamReader streamReader = new StreamReader("teglalap.txt");

        public MainWindow()
        {
            InitializeComponent();

            //Első (fölösleges) sor beolvasása
            streamReader.ReadLine();

            //Fájlból kiolvasás
            while (!streamReader.EndOfStream)
            {
                teglalapList.Add(new Teglalap(streamReader.ReadLine()));
            }

            streamReader.Close();

            //Datagrid feltöltésa listából
            DataGrid1.ItemsSource = teglalapList;
        }

        //Új adat datagrid-hez hozzáadása
        private void Hozzaad_Click(object sender, RoutedEventArgs e)
        {
            if(input1.Text != "" && input2.Text != "")
            {
                if(input1.Text != input2.Text)
                {
                    if(teglalapList.Where(x => x.A == double.Parse(input1.Text) && x.B == double.Parse(input2.Text)).Count() == 0){
                        teglalapList.Add(new Teglalap(double.Parse(input1.Text), double.Parse(input2.Text)));
                        DataGrid1.Items.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Van már pont ilyet te foscsimbók!");
                    }
                }
                else
                {
                    MessageBox.Show("Nem lehetnek egyenlőek.");
                }
            }
            else
            {
                MessageBox.Show("Nem lehet üres. Egyébként meg ABNYÁD!");
            }
        }

        private void TorlesButton_Click(object sender, RoutedEventArgs e)
        {
            //DataGrid1.Items.Remove(DataGrid1.SelectedItem); - listából kell törölni és frissíteni a datagridet
            
            if(DataGrid1.SelectedIndex != -1)
            {
                teglalapList.Remove(DataGrid1.SelectedItem as Teglalap);
                DataGrid1.Items.Refresh();
            }
        }

        private void ButtonKiirat_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("asd.txt");
            foreach (var item in teglalapList)
            {
                streamWriter.WriteLine(item.A + "\t" + item.B);
            }

            streamWriter.Close();

            MessageBox.Show("asd.txt létrehozva és a csicska adataid beleírva.");
        }
    }
}
