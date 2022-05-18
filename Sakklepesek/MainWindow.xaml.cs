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

namespace Sakklepesek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Grid tabla;
        Rectangle[,] tablaMezoi;
        public MainWindow()
        {
            InitializeComponent();
            FeluletGeneralasa();
            //SakktablaGeneralasa();
        }

        /*private void SakktablaGeneralasa()
        {

        }*/

        private void FeluletGeneralasa()
        { 
        
        babuk.Items.Add("Király");
            babuk.Items.Add("Futo");
            babuk.Items.Add("Bástya");
            babuk.Items.Add("Huszár");
            babuk.Items.Add("Sötét gyalog");
            babuk.Items.Add("Világos gyalog");
            babuk.Items.Add("Királynő");
            tabla = new Grid(); 
            tabla.HorizontalAlignment = HorizontalAlignment.Center;
            tabla.VerticalAlignment = VerticalAlignment.Center;
            Label aktualisHely = new Label();
            ablak.Children.Add(tabla);
            ablak.Children.Add(aktualisHely);
            aktualisHely.Content = "A1";
            aktualisHely.VerticalAlignment = VerticalAlignment.Bottom;
            


        }
    }
}
