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

namespace NosSeusPesWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow ()
        {
            InitializeComponent ();
            //ButtonClientes_Click (null, null);
            //ButtonVendas_Click (null, null);
            new View.EstoqueWindow().ShowDialog();
        }

        private void ButtonVendas_Click (object sender, RoutedEventArgs e)
        {
            new VendasWindow ().ShowDialog ();
        }

        private void ButtonSapatos_Click (object sender, RoutedEventArgs e)
        {
            new SapatoWindow ().ShowDialog ();
        }

        private void ButtonClientes_Click (object sender, RoutedEventArgs e)
        {
            new ClienteWindow ().ShowDialog (); 
        }

        private void ButtonEstoque_Click (object sender, RoutedEventArgs e)
        {
        }
    }
}
