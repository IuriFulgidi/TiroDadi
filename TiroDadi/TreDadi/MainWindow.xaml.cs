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
            //primo tiro
            int faccia1= tiro.Next(1, 7); ;
            img_dado1.Source = new BitmapImage(new Uri($"C:/Users/studenti/source/repos/TiroDadi/TiroDadi/TreDadi/dado_{faccia1}.jpg"));

            //secondo tiro
            int faccia2 = tiro.Next(1, 7); ;
            img_dado2.Source = new BitmapImage(new Uri($"C:/Users/studenti/source/repos/TiroDadi/TiroDadi/TreDadi/dado_{faccia2}.jpg"));

            //calcolo somma
            lbl_somma.Content = faccia1 + faccia2;
        }
    }
}
