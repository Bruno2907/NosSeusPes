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
    public class ClienteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                Vendas = new ObservableCollection<Venda> (model.Vendas.Where (v => v.Cliente.Id == _clienteSelecionado.Id).ToList ());
                PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (""));
            }
        }

        public string[] ClienteTipo { get; set; }
        private string _clienteTipoSelecionado;
        public string ClienteTipoSelecionado
        {
            get
            {
                return _clienteTipoSelecionado;
            }
            set
            {
                _clienteTipoSelecionado = value;
                PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (""));
            }
        }

        public ObservableCollection<Venda> Vendas { get; set; }

        private Model model;


        public ClienteViewModel ()
        {
            model = new Model ();
            Clientes = new ObservableCollection<Cliente> (model.Clientes.ToList ());
            ClienteSelecionado = model.Clientes.FirstOrDefault ();

            ClienteTipo = new string[] { "Pessoa Física", "Pessoa Jurídica" };
            //_clienteTipoSelecionado = "";
            _clienteTipoSelecionado = ClienteTipo[0];

            Vendas = new ObservableCollection<Venda> ();
        }


        public bool VisibilityCadastroPessoaFisica
        {
            get
            {
                return _clienteTipoSelecionado.Equals (ClienteTipo[0]);
            }
        }


        public bool VisibilityCadastroPessoaJuridica
        {
            get
            {
                return _clienteTipoSelecionado.Equals (ClienteTipo[1]);
            }
        }


        public bool VisibilityPessoaFisica
        {
            get
            {
                return ClienteSelecionado is PessoaFisica;
            }
        }


        public bool VisibilityPessoaJuridica
        {
            get
            {
                return ClienteSelecionado is PessoaJuridica;
            }
        }
    }
}
