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
                faccia1= tiro.Next(1, 7); ;
            });

            //secondo tiro
            Task lancio2 = Task.Factory.StartNew(() =>
            {
                faccia2 = tiro.Next(1, 7); 
            });

            //attesa
            Task.WaitAll(lancio1, lancio2);
            img_dado1.Source = new BitmapImage(new Uri($"C:/Users/studenti/source/repos/TiroDadi/TiroDadi/TreDadi/dado_{faccia1}.jpg"));
            img_dado2.Source = new BitmapImage(new Uri($"C:/Users/studenti/source/repos/TiroDadi/TiroDadi/TreDadi/dado_{faccia2}.jpg"));

            //calcolo somma
            lbl_somma.Content = faccia1 + faccia2;
        }
    }
}
