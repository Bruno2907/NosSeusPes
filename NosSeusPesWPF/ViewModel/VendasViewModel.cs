using NosSeusPes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Estoque EstoqueSelecionado { get; set; }

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
