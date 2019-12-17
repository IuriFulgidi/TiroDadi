using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace TreDadi
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random tiro = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_tira_Click(object sender, RoutedEventArgs e)
        {
            //variabili
            int faccia1 = 0;
            int faccia2 = 0;

            //primo tiro
            Task lancio1 = Task.Factory.StartNew(() =>
            {
                faccia1 = Tiro();
            });

            //secondo tiro
            Task lancio2 = Task.Factory.StartNew(() =>
            {
                faccia2 = Tiro();
            });

            //attesa
            Task.WaitAll(lancio1, lancio2);
            img_dado2.Source = new BitmapImage(new Uri($"C:/Users/iurif/Source/Repos/TiroDadi/TiroDadi/TreDadi/dado_{faccia2}.jpg"));
            img_dado1.Source = new BitmapImage(new Uri($"C:/Users/iurif/Source/Repos/TiroDadi/TiroDadi/TreDadi/dado_{faccia1}.jpg"));

            //calcolo somma
            Task somma = Task.Factory.StartNew(() =>
            {
                int s= faccia1 + faccia2;
                Dispatcher.Invoke(() => { lbl_somma.Content = s; }) ;
            });
        }

        private int Tiro()
        {
            return tiro.Next(1, 7); 
        }
    }
}
