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
    /// Lógica interna para SapatoWindow.xaml
    /// </summary>
    public partial class SapatoWindow : Window
    {
        public ViewModel.SapatoViewModel SapatoViewModel{ get; set; }
        public SapatoWindow()
        {
            InitializeComponent();

            SapatoViewModel = new ViewModel.SapatoViewModel();

            DataContext = SapatoViewModel;

        }

        private void SALVAR_Click(object sender, RoutedEventArgs e)
        {
            SapatoViewModel.SalvarNovoSapato();
        }

        private void CANCELAR_Click(object sender, RoutedEventArgs e)
        {
            int Id = (int)((Button)sender).CommandParameter;
            SapatoViewModel.DeletarSapato(Id);
        }
    }
}
