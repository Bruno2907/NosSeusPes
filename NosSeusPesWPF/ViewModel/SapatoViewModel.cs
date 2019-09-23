using NosSeusPes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace NosSeusPesWPF.ViewModel
{
    public class SapatoViewModel
    {
        public ObservableCollection<Sapato> Sapatos { get; set; }
        public ObservableCollection<Sapato> NovoSapato { get; set; }
        public object SapatoSelecionado { get; set; }

        public Model model;
        private Estoque _itemSelecionado;
        private readonly Sapato _sapatoSelecionado;

        public Sapato ItemSelecionado { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public DataGrid DataGridCompra { get; set; }
        public ObservableCollection<Estoque> Estoques { get; set; }
        private Estoque __ItemSelecionado { get; set; }
        public Estoque ItemSelecioSelecionado
        {
            get
            {
                return _itemSelecionado;
            }
            set
            {
                _itemSelecionado = value;
                NovoSapato[0].Modelo = _itemSelecionado;
                if (_estoqueSelecionado != null)
                {
                    NovoSapato[0] = _estoqueSelecionado;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
                }
            }
        }
        public ObservableCollection<Cliente> Clientes { get; set; }
        public Cliente ClienteSelecionado { get; set; }
        public string _ItemSelecionado { get;  set; }
        public Estoque _estoqueSelecionado { get; set; }

        public SapatoViewModel()
        {

            model = new Model();

           Sapatos = new ObservableCollection<Sapato>();
            {
                new Sapato()
                {
                };
            };

            Sapatos = new ObservableCollection<Sapato>();
            AtualizarListaDeSapatos();

            Estoques = new ObservableCollection<Estoque>();
            AtualizarListaDeEstoqueSapato();

            Clientes = new ObservableCollection<Cliente>(model.Clientes.ToList());
            ClienteSelecionado = model.Clientes.FirstOrDefault();
        }

        public void DeletarSapato(int ID)
        {
            Sapato s;
            s = Sapatos.Where(sa => sa.ID == ID).FirstOrDefault();
            Sapatos.Remove(s);
            model.Sapatos.Remove(s);
            model.SaveChanges();
        }



        public void SalvarNovoSapato()
        {
            Sapato s = NovoSapato[0];
            if(s.Nome != null && s.QuantidadedeItens > 0)
            {
                s.Sapato = SapatoSelecionado;
                s.DatadeInsercaonoEstoque = DateTime.Now;
                Sapatos.Add(s);
                NovoSapato.RemoveAt(0);
                NovoSapato.Add(new Sapato()
                {
                    Nome = _ItemSelecionado,
                    NovoItem = _ItemSelecionado
                });
                _ItemSelecionado = s.Quantidade;
                model.SaveChanges();
                AtualizarListaDeSapatos();
                AtualizarListaDeEstoqueSapato();
            }
        }

        private void AtualizarListaDeEstoqueSapato()
        {
            while (Estoques.Count > 0)
            {
                Estoques.RemoveAt(0);
            }
            foreach (Estoque e in model.Estoques
                .Where(es => es.Id == _sapatoSelecionado.ID && es.Quantidade > 0)
                .ToList())
            {
                Estoques.Add(e);
            }
            if (Estoques.Where(e => e.Id == _estoqueSelecionado?.Id).Count() == 0)
            {
                _estoqueSelecionado = model.Estoques
                    .Where(es => es.Id == _sapatoSelecionado.ID && es.Quantidade > 0)
                    .FirstOrDefault();
            }
            NovoSapato[0].Nome = _estoqueSelecionado;
        }



        private void AtualizarListaDeSapatos()
        {
            while (Sapatos.Count > 0)
            {
                Sapatos.RemoveAt(0);
            }
            foreach (Sapato s in model.Sapatos.ToList())
            {
                if (model.Estoques.Where(es => es.Id == s.ID && es.Quantidade > 0).Count() > 0)
                {
                    Sapatos.Add(s);
                }
            }
            if (Sapatos.Count > 0)
            {
                if (!Sapatos.Contains(_sapatoSelecionado))
                {
                    _ItemSelecionado = Sapatos[0];
                }
            }
            else
            {
                _ItemSelecionado = new Sapato()
                {
                    ID = -1,
                    Nome = "NÃO FORAM ADICIONADOS CALÇADOS(SAPATOS) AO ESTOQUE"
                };
            }
        }
    }
}
