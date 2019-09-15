using NosSeusPes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NosSeusPesWPF.ViewModel
{
    public class VendasViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cliente> Clientes { get; set; }
        private Cliente _clienteSelecionado;
        public Cliente ClienteSelecionado
        {
            get
            {
                return _clienteSelecionado;
            }
            set
            {
                _clienteSelecionado = value;
                // Eu não estava conseguindo fazer a tela atualizar usando o new e nem com o INotifyPropertyChange
                // Momento gambiarra yay
                while (Vendas.Count > 0)
                {
                    Vendas.RemoveAt (0);
                }
                foreach (Venda venda in model.Vendas
                    .Include ("Cliente")
                    .Include ("Modelo")
                    .Where (v => v.Cliente.Id == _clienteSelecionado.Id)
                    .ToList ())
                {
                    Vendas.Add (venda);
                }
                VendaSelecionada =
                    model.Vendas
                    .Include ("Cliente")
                    .Include ("Modelo")
                    .Where(v => v.Cliente.Id == _clienteSelecionado.Id)
                    .FirstOrDefault ();
            }
        }

        public ObservableCollection<Estoque> Estoques { get; set; }
        private Estoque _estoqueSelecionado { get; set; }
        public Estoque EstoqueSelecionado
        {
            get
            {
                return _estoqueSelecionado;
            }
            set
            {
                _estoqueSelecionado = value;
                NovaVenda[0].Modelo = _estoqueSelecionado;
                DataGridRow row = (DataGridRow)DataGridCompra.ItemContainerGenerator.ContainerFromIndex (0);
                var cellContent = DataGridCompra.Columns[2].GetCellContent (row);
                var cellContentPresenter = (ContentPresenter)cellContent;
                DataTemplate editingTemplate = cellContentPresenter.ContentTemplate;
                Slider slider = editingTemplate.FindName ("SliderQuantidade", cellContentPresenter) as Slider;
                slider.Maximum = _estoqueSelecionado.Quantidade;
                if (NovaVenda[0].QuantidadeDeItens > slider.Maximum)
                {
                    NovaVenda[0].QuantidadeDeItens = (int)slider.Maximum;
                    slider.Value = slider.Maximum;
                }
                var BindedModel = cellContentPresenter.Content;
                PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (""));
            }
        }

        public ObservableCollection<Sapato> Sapatos { get; set; }
        private Sapato _sapatoSelecionado;
        public Sapato SapatoSelecionado
        {
            get
            {
                return _sapatoSelecionado;
            }
            set
            {
                _sapatoSelecionado = value;
                // Mesmo esquema do cliente
                while (Estoques.Count > 0)
                {
                    Estoques.RemoveAt (0);
                }
                foreach (Estoque e in model.Estoques
                    .Where (es => es.Modelo.Id == _sapatoSelecionado.Id)
                    .ToList ())
                {
                    Estoques.Add (e);
                }
                NovaVenda[0].Modelo = model.Estoques
                    .Where (es => es.Modelo.Id == _sapatoSelecionado.Id)
                    .FirstOrDefault ();
                PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (""));
            }
        }

        public ObservableCollection<Venda> Vendas { get; set; }
        public Venda VendaSelecionada { get; set; }
        public ObservableCollection<Venda> NovaVenda { get; set; }

        private Model model;
        public DataGrid DataGridCompra { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public VendasViewModel ()
        {
            model = new Model ();
            Vendas = new ObservableCollection<Venda> ();
            NovaVenda = new ObservableCollection<Venda>
            {
                new Venda ()
            };

            Clientes = new ObservableCollection<Cliente> (model.Clientes.ToList ());
            ClienteSelecionado = model.Clientes.FirstOrDefault ();

            Estoques = new ObservableCollection<Estoque> ();

            Sapatos = new ObservableCollection<Sapato> (model.Sapatos.ToList ());
            SapatoSelecionado = model.Sapatos.FirstOrDefault ();
        }
    }
}
