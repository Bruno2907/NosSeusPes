using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using NosSeusPes;

namespace NosSeusPesWPF.ViewModel
{
    class EstoqueViewModel
    {
        public ObservableCollection<Estoque> Estoques { get; set; }
        public Model model;
        public EstoqueViewModel()
        {
            model = new Model();
            Estoques = new ObservableCollection<Estoque>(model.Estoques.ToList());
            Sapatos = new ObservableCollection<Sapato>(model.Sapatos.ToList());
            EstoqueSelecionado = new Estoque();
        }
        public Estoque EstoqueSelecionado { get; set; }
        public void DeletarEstoque(int ID)
        {
            Estoque e;
            e = Estoques.Where(es => es.Id == ID).FirstOrDefault();
            Estoques.Remove(e);
            model.Estoques.Remove(e);
            model.SaveChanges();
        }

        public void SalvarNovoEstoque()
        {
            Estoque e = EstoqueSelecionado;
            Estoques.Add(e);
            model.Estoques.Add(e);
            EstoqueSelecionado = new Estoque();
            model.SaveChanges();
        }

        public ObservableCollection<Sapato> Sapatos { get; set; }
    }
}
