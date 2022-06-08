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
        char betuKorbeOldal;

        int akty;

        public MainWindow()
        {
            InitializeComponent();
            FeluletGeneralasa();
            SakktablaGeneralasa();
        }

        private void SakktablaGeneralasa()
        {
            tablaMezoi = new Rectangle[10, 10];
            char betuKorbeOldal = 'A';
            char betuKorbeSzel = 'A';


            for (int i = 1; i < 9; i++)
            {
                
                Label betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Right;
                betu.VerticalAlignment = VerticalAlignment.Top;
                betu.Content = betuKorbeOldal++;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, 9);
                Grid.SetColumn(betu, i);

                betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Left;
                betu.VerticalAlignment = VerticalAlignment.Center;
                betu.Content = betuKorbeSzel++;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, i);
                Grid.SetColumn(betu, 9);
            


                //szamok
                betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Right;
                betu.VerticalAlignment = VerticalAlignment.Center;
                betu.Content = 9 - i;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, 0);
                Grid.SetColumn(betu, i);

                betu = new Label();
                betu.HorizontalAlignment = HorizontalAlignment.Left;
                betu.VerticalAlignment = VerticalAlignment.Top;
                betu.Content = 9 - i;
                tabla.Children.Add(betu);
                Grid.SetRow(betu, i);
                Grid.SetColumn(betu, 0);
            }
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
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
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
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
                   ImageBrush kiralyMinta = new ImageBrush();
                    kiralyMinta.ImageSource = new BitmapImage(new Uri(@"C:\Users\User\Documents\GitHub\Sakklepesek_MihalyReka\Sakklepesek\Sakklepesek\Képek\kiraly.png", UriKind.Relative));
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx, akty].Fill = kiralyMinta;
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
                    for (int i = 1; i < 9; i++)
                    {

                        ImageBrush futoMinta = new ImageBrush();
                        futoMinta.ImageSource = new BitmapImage(new Uri(@"C:\Users\User\Documents\GitHub\Sakklepesek_MihalyReka\Sakklepesek\Sakklepesek\Képek\futo.png", UriKind.Relative));
                        tablaMezoi[aktx, akty].Fill = futoMinta;
                        /*
                             tablaMezoi[aktx+i,akty+i].Fill = Brushes.Red;
                             tablaMezoi[aktx + i, akty - i].Fill = Brushes.Red;
                             tablaMezoi[aktx -i, akty + i].Fill = Brushes.Red;
                             tablaMezoi[aktx - i, akty - i].Fill = Brushes.Red;*/                       

                    }
            }
            else if (sakkFigurak == 2)//Bástya
            {
                for (int i = 1; i < 9; i++)
                {
                    ImageBrush bastyaMinta = new ImageBrush();
                    bastyaMinta.ImageSource = new BitmapImage(new Uri(@"C:\Users\User\Documents\GitHub\Sakklepesek_MihalyReka\Sakklepesek\Sakklepesek\Képek\bastya.jpg", UriKind.Relative));
                    
                    tablaMezoi[aktx, i].Fill = Brushes.Red;
                    tablaMezoi[i, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx, akty].Fill = bastyaMinta;
                }
            }
            else if (sakkFigurak == 3)//Huszár
            {
                for (int i = 1; i < 9; i++)
                {
                    ImageBrush huszarMinta = new ImageBrush();
                    huszarMinta.ImageSource = new BitmapImage(new Uri(@"C:\Users\User\Documents\GitHub\Sakklepesek_MihalyReka\Sakklepesek\Sakklepesek\Képek\huszar.png", UriKind.Relative));
                    
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx + 2, akty + 1].Fill = Brushes.Red;
                    tablaMezoi[aktx + 2, akty - 1].Fill = Brushes.Red;
                    tablaMezoi[aktx - 2, akty + 1].Fill = Brushes.Red;
                    tablaMezoi[aktx - 2, akty - 1].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty + 2].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty - 2].Fill = Brushes.Red;
                    tablaMezoi[aktx + 1, akty + 2].Fill = Brushes.Red;
                    tablaMezoi[aktx + 1, akty - 2].Fill = Brushes.Red;
                    tablaMezoi[aktx, akty].Fill = huszarMinta;
                }
            }
            else if (sakkFigurak == 4)//Sötét gyalog
            {
                ImageBrush gyalogSMinta = new ImageBrush();
                gyalogSMinta.ImageSource = new BitmapImage(new Uri(@"C:\Users\User\Documents\GitHub\Sakklepesek_MihalyReka\Sakklepesek\Sakklepesek\Képek\sGyalog.png", UriKind.Relative));
                tablaMezoi[aktx, akty].Fill = gyalogSMinta;
                if (aktx == 7)
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx - 2, akty].Fill = Brushes.Red;
                }
                else if (aktx == 1)
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                }
                else
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx - 1, akty].Fill = Brushes.Red;
                }
                tablaMezoi[aktx, akty].Fill = gyalogSMinta;
            }
            else if (sakkFigurak == 5)//Világos gyalog
            {
                ImageBrush gyalogVMinta = new ImageBrush();
                gyalogVMinta.ImageSource = new BitmapImage(new Uri(@"C:\Users\User\Documents\GitHub\Sakklepesek_MihalyReka\Sakklepesek\Sakklepesek\Képek\vGyalog.png", UriKind.Relative));
                
                if (aktx==2)
                {
                    tablaMezoi[aktx, akty ].Fill = Brushes.Red;
                    tablaMezoi[aktx+1 , akty ].Fill = Brushes.Red;
                    tablaMezoi[aktx +2, akty].Fill = Brushes.Red;
                }
                else if(aktx == 8)
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                }
                else
                {
                    tablaMezoi[aktx, akty].Fill = Brushes.Red;
                    tablaMezoi[aktx+1, akty ].Fill = Brushes.Red;
                }
                tablaMezoi[aktx, akty].Fill = gyalogVMinta;


            }
            else if (sakkFigurak == 6)//Királynő
            {                         
                    for (int i = 1; i < 9; i++)
                    {
                    
                    
                        ImageBrush kiralynoMinta = new ImageBrush();
                        kiralynoMinta.ImageSource = new BitmapImage(new Uri(@"C:\Users\User\Documents\GitHub\Sakklepesek_MihalyReka\Sakklepesek\Sakklepesek\Képek\kiralyno.png", UriKind.Relative));
                       
                        tablaMezoi[aktx, i].Fill = Brushes.Red;
                        tablaMezoi[i, akty].Fill = Brushes.Red;
                        /*
                        tablaMezoi[aktx+i, akty+i].Fill = Brushes.Red;
                        tablaMezoi[aktx + i, akty - i].Fill = Brushes.Red;
                        tablaMezoi[aktx -i, akty + i].Fill = Brushes.Red;
                        tablaMezoi[aktx - i, akty - i].Fill = Brushes.Red;*/                       
                        tablaMezoi[aktx, akty].Fill = kiralynoMinta;
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
            aktualisHely.Content ="A1";
            aktualisHely.VerticalAlignment = VerticalAlignment.Bottom;
            


        }
    }
}
