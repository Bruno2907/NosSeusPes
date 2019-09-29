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
    /// Lógica interna para ClienteWindow.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {
        public ViewModel.ClienteViewModel ClienteViewModel { get; set; }

        public ClienteWindow()
        {
            InitializeComponent();
            ClienteViewModel = new ViewModel.ClienteViewModel ();
            DataContext = ClienteViewModel;
            //DataNascimento.SetValue (TextBlock.TextProperty, "TESTE TESTE TESTE");
        }

        private void ButtonCadastrarNovoCliente_Click (object sender, RoutedEventArgs e)
        {
            ClienteViewModel.CadastrarNovoCliente ();
        }

        private void ButtonDeletarCliente_Click (object sender, RoutedEventArgs e)
        {
            ClienteViewModel.DeletarClienteSelecionado ();
        }
    }
}
