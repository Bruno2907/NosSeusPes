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
using System.Windows.Shapes;

namespace NosSeusPesWPF
{
    /// <summary>
    /// Lógica interna para VendasWindow.xaml
    /// </summary>
    public partial class VendasWindow : Window
    {
        ViewModel.VendasViewModel VendasViewModel { get; set; }

        public VendasWindow ()
        {
            InitializeComponent ();
            VendasViewModel = new ViewModel.VendasViewModel ()
            {
                DataGridCompra = DataGridCompra
            };
            DataContext = VendasViewModel;
        }

        private void Slider_ValueChanged (object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VendasViewModel.NovaVenda[0].QuantidadeDeItens = (int)e.NewValue;
        }

        private void TextBoxQuantidadeDeItens_TextChanged (object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (VendasViewModel.NovaVenda[0].Modelo != null)
            {
                if (int.TryParse (textBox.Text, out int result))
                {
                    if (result > VendasViewModel.NovaVenda[0].Modelo.Quantidade)
                    {
                        textBox.Text = VendasViewModel.NovaVenda[0].Modelo.Quantidade.ToString ();
                    }
                }
            }
            else
            {
                textBox.Text = "0";
            }
        }

        private void ButtonSalvarNovaCompra_Click (object sender, RoutedEventArgs e)
        {
            VendasViewModel.SalvarNovaCompra ();
        }

        private void ButtonExcluir_Click (object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            VendasViewModel.DeletarRegistroVenda (id);
        }
    }
}
