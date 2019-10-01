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

namespace NosSeusPesWPF.View
{
    /// <summary>
    /// Lógica interna para EstoqueWindow.xaml
    /// </summary>
    public partial class EstoqueWindow : Window
    {
        ViewModel.EstoqueViewModel EstoqueViewModel { get; set; }
        public EstoqueWindow()
        {
            InitializeComponent();

            EstoqueViewModel = new ViewModel.EstoqueViewModel();

            DataContext = EstoqueViewModel;

        }

        private void ButtonAdicionar_Click(object sender, RoutedEventArgs e)
        {
            EstoqueViewModel.SalvarNovoEstoque();
            Close();
        }

        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
