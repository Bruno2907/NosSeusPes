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
                if (_estoqueSelecionado != null)
                {
                    NovaVenda[0].PrecoPorItem = _estoqueSelecionado.Modelo.Preco;
                    AtualizarSlider ();
                    PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (""));
                }
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
                AtualizarListaDeEstoque ();
                AtualizarSlider ();
                PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (""));
            }
        }

        public ObservableCollection<Venda> Vendas { get; set; }
        public Venda VendaSelecionada { get; set; }
        // Usando ObservableCollection aqui porque o exercício exigia um DataGrid
        public ObservableCollection<Venda> NovaVenda { get; set; }

        private Model model;

        public event PropertyChangedEventHandler PropertyChanged;

        // Para ter acesso aos seus itens
        public DataGrid DataGridCompra { get; set; }


        public VendasViewModel ()
        {
            model = new Model ();

            Vendas = new ObservableCollection<Venda> ();
            NovaVenda = new ObservableCollection<Venda>
            {
                new Venda ()
                {
                }
            };

            Sapatos = new ObservableCollection<Sapato>();
            AtualizarListaDeSapatos ();

            Estoques = new ObservableCollection<Estoque> ();
            AtualizarListaDeEstoque ();

            Clientes = new ObservableCollection<Cliente> (model.Clientes.ToList ());
            ClienteSelecionado = model.Clientes.FirstOrDefault ();
        }


        // Emprestado do StackOverflow, não sei como só sei que funciona
        // Usado para ter acesso aos itens do DataGrid
        public ContentPresenter GetContentPresenter (int row, int column, DataGrid dataGrid)
        {
            DataGridRow dataGridRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex (row);
            var cellContent = DataGridCompra.Columns[column].GetCellContent (dataGridRow);
            return (ContentPresenter)cellContent;
        }


        // Atualiza a lista de tamanho para cada sapato
        public void AtualizarListaDeEstoque ()
        {
            // Mesmo esquema do cliente
            while (Estoques.Count > 0)
            {
                Estoques.RemoveAt (0);
            }
            foreach (Estoque e in model.Estoques
                .Where (es => es.Modelo.Id == _sapatoSelecionado.Id && es.Quantidade > 0)
                .ToList ())
            {
                Estoques.Add (e);
            }
            // If evitando uma situações de divergência com o banco de dados
            if (Estoques.Where (e => e.Id == _estoqueSelecionado?.Id).Count () == 0)
            {
                _estoqueSelecionado = model.Estoques
                    .Where (es => es.Modelo.Id == _sapatoSelecionado.Id && es.Quantidade > 0)
                    .FirstOrDefault ();
            }
            NovaVenda[0].Modelo = _estoqueSelecionado;
        }



        private void AtualizarListaDeSapatos ()
        {
            while (Sapatos.Count > 0)
            {
                Sapatos.RemoveAt (0);
            }
            foreach (Sapato s in model.Sapatos.ToList ())
            {
                if (model.Estoques.Where (es => es.Modelo.Id == s.Id && es.Quantidade > 0).Count () > 0)
                {
                    Sapatos.Add (s);
                }
            }
            if (Sapatos.Count > 0)
            {
                if (!Sapatos.Contains (_sapatoSelecionado))
                {
                    _sapatoSelecionado = Sapatos[0];
                }
            }
            else
            {
                _sapatoSelecionado = new Sapato ()
                {
                    Id = -1,
                    Marca = "NÃO EXISTEM SAPATOS DISPONIVEIS PARA COMPRA"
                };
            }
        }

        public void AtualizarSlider ()
        {
            if (DataGridCompra != null)
            {
                DataGridRow dataGridRow = (DataGridRow)DataGridCompra.ItemContainerGenerator.ContainerFromIndex (0);
                //
                // SLIDER
                //
                var cellContent = DataGridCompra.Columns[2].GetCellContent (dataGridRow);
                var contentPresenter = (ContentPresenter)cellContent;
                Slider slider = contentPresenter.ContentTemplate.FindName ("SliderQuantidade", cellContent) as Slider;
                slider.Maximum = _estoqueSelecionado.Quantidade;
                //DataGridCompra.Columns[2].MinWidth = slider.Maximum;
                if (NovaVenda[0].QuantidadeDeItens > slider.Maximum)
                {
                    NovaVenda[0].QuantidadeDeItens = (int)slider.Maximum;
                    slider.Value = slider.Maximum;
                }
                //
                // TEXTO QUANTIDADE
                //
                TextBlock textBox = DataGridCompra.Columns[4].GetCellContent (dataGridRow) as TextBlock;
                textBox.Text = _estoqueSelecionado.Modelo.Preco.ToString ();
            }
        }

        public void DeletarRegistroVenda (int ID)
        {
            Venda v;
            v = Vendas.Where (ve => ve.Id == ID).FirstOrDefault ();
            Vendas.Remove (v);
            model.Vendas.Remove (v);
            model.SaveChanges ();
        }

        public void SalvarNovaCompra ()
        {
            Venda v = NovaVenda[0];
            if (v.Modelo != null && v.QuantidadeDeItens > 0)
            {
                v.Cliente = ClienteSelecionado;
                v.DataDaVenda = DateTime.Now;
                Vendas.Add (v);
                model.Vendas.Add (v);
                NovaVenda.RemoveAt (0);
                NovaVenda.Add (new Venda ()
                {
                    Modelo = _estoqueSelecionado,
                    PrecoPorItem = _estoqueSelecionado.Modelo.Preco
                });
                _estoqueSelecionado.Quantidade -= v.QuantidadeDeItens;
                model.SaveChanges ();
                AtualizarListaDeSapatos ();
                AtualizarListaDeEstoque ();
            }
        }
    }
}
