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
        
        Rectangle[,] tablaMezoi;
        
        public MainWindow()
        {
            InitializeComponent();
            FeluletGeneralasa();
            SakktablaGeneralasa();
        }

        private void SakktablaGeneralasa()
        {
            tablaMezoi = new Rectangle[10, 10];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tablaMezoi[i, j] = new Rectangle();
                    tablaMezoi[i, j].Stroke = Brushes.Black;
                    tablaMezoi[i, j].Fill = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;
                    tablaMezoi[i, j].MouseUp += Katt;
                   
                    tabla.Children.Add(tablaMezoi[i, j]);
                    Grid.SetRow(tablaMezoi[i, j], i);
                    Grid.SetColumn(tablaMezoi[i, j], j);

                }
            }
        }
        private void Katt(object sender, MouseButtonEventArgs e)
        {
            Rectangle aktualis = sender as Rectangle;
            
            int aktx = 0;
            int akty = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablaMezoi[i, j].Equals(aktualis))
                    {
                        aktx = i;
                        akty = j;

                    }
                    tablaMezoi[i, j].Fill = (i + j) % 2 == 0 ? Brushes.White : Brushes.Black;
                }
            }

            int sakkFigurak = babuk.SelectedIndex;
            if (sakkFigurak == 0)//Király
            {
                tablaMezoi[aktx, akty].Fill = ;
                tablaMezoi[aktx, akty].Fill = Brushes.Red;
                tablaMezoi[aktx - 1, akty].Fill = Brushes.Red;
                tablaMezoi[aktx - 1, akty - 1].Fill = Brushes.Red;
                tablaMezoi[aktx - 1, akty + 1].Fill = Brushes.Red;
                tablaMezoi[aktx, akty - 1].Fill = Brushes.Red;
                tablaMezoi[aktx, akty + 1].Fill = Brushes.Red;
                tablaMezoi[aktx + 1, akty].Fill = Brushes.Red;
                tablaMezoi[aktx + 1, akty - 1].Fill = Brushes.Red;
                tablaMezoi[aktx + 1, akty + 1].Fill = Brushes.Red;

            }
            else if (sakkFigurak == 1)//Futo
            {
              
                for (int i = 0; i < 8; i++)
                {
                    //tablaMezoi[, ].Fill = Brushes.Red;
                  
                }
                
            }
            else if (sakkFigurak == 2)//Bástya
            {
                for (int i = 0; i < 8; i++)
                {
                    tablaMezoi[aktx, i].Fill = Brushes.Red;
                    tablaMezoi[i, akty].Fill = Brushes.Red;
                }
            }
            else if (sakkFigurak == 3)//Huszár
            {
                for (int i = 0; i < 8; i++)
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx + 2, akty + 1].Fill = Brushes.Red;
                    tablaMezoi[aktx + 2, akty - 1].Fill = Brushes.Red;
                    tablaMezoi[aktx - 2, akty + 1].Fill = Brushes.Red;
                    tablaMezoi[aktx - 2, akty - 1].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty + 2].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty - 2].Fill = Brushes.Red;
                    tablaMezoi[aktx + 1, akty + 2].Fill = Brushes.Red;
                    tablaMezoi[aktx + 1, akty - 2].Fill = Brushes.Red;
                }
            }
            else if (sakkFigurak == 4)//Sötét gyalog
            {
                if (aktx == 6)
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx - 2, akty].Fill = Brushes.Red;
                }
                else if (aktx == 0)
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                }
                else
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty].Fill = Brushes.Red;
                }
            }
            else if (sakkFigurak == 5)//Világos gyalog
            {
                if (aktx==1)
                {
                    tablaMezoi[aktx, akty ].Fill = Brushes.Red;
                    tablaMezoi[aktx+1 , akty ].Fill = Brushes.Red;
                    tablaMezoi[aktx +2, akty].Fill = Brushes.Red;
                }
                else if(aktx == 7)
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                }
                else
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx+1, akty ].Fill = Brushes.Red;
                }
                
                
            }
            else if (sakkFigurak == 6)//Királynő
            {
                for (int i = 0; i < 8; i++)
                {
                        tablaMezoi[aktx, i].Fill = Brushes.Red;
                        tablaMezoi[i, akty].Fill = Brushes.Red;
                
                }
            }



        }
        private void FeluletGeneralasa()
        {
            
            babuk.Items.Add("Király");
            babuk.Items.Add("Futo");
            babuk.Items.Add("Bástya");
            babuk.Items.Add("Huszár");
            babuk.Items.Add("Sötét gyalog");
            babuk.Items.Add("Világos gyalog");
            babuk.Items.Add("Királynő");
            for (int i = 0; i < 10; i++)
            {
                tabla.RowDefinitions.Add(new RowDefinition());
                tabla.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
            Label aktualisHely = new Label();
            ablak.Children.Add(aktualisHely);
            aktualisHely.Content = "A1";
            aktualisHely.VerticalAlignment = VerticalAlignment.Bottom;
            


        }
    }
}
