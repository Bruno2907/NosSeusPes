using NosSeusPes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace NosSeusPesWPF.ViewModel
{
    public class SapatoViewModel
    {
        public ObservableCollection<Sapato> Sapatos { get; set; }
        public Model model;
        public Sapato SapatoParaExcluir { get; set; }

        public SapatoViewModel()
        {
            model = new Model();
            Sapatos = new ObservableCollection<Sapato>(model.Sapatos.ToList());
            SapatoSelecionado = new Sapato();
        }
        public Sapato SapatoSelecionado { get; set; }
        public void DeletarSapato(int ID)
        {
            Sapato s;
            s = Sapatos.Where(sa => sa.Id == ID).FirstOrDefault();
            Sapatos.Remove(s);
            model.Sapatos.Remove(s);
            model.SaveChanges();
        }

        public void SalvarNovoSapato()
        {
            Sapato s = SapatoSelecionado;
            Sapatos.Add(s);
            model.Sapatos.Add(s);
            SapatoSelecionado = new Sapato();
            model.SaveChanges();
        }

        public void DeletarSapatoSelecionado()
        {
            if (SapatoParaExcluir != null)
            {
                foreach (Estoque estoque in model.Estoques.Where(e => e.Modelo.Id == SapatoParaExcluir.Id).ToList())
                {
                    model.Estoques.Remove(model.Estoques.Where(e => e.Id == estoque.Id).FirstOrDefault());
                }
                foreach (Venda venda in model.Vendas.Where(v => v.Modelo.Modelo.Id == SapatoParaExcluir.Id).ToList())
                {
                    model.Vendas.Remove(model.Vendas.Where(v => v.Id == venda.Id).FirstOrDefault());
                }
                model.Sapatos.Remove(SapatoParaExcluir);
                Sapatos.Remove(SapatoParaExcluir);
                model.SaveChanges();
               // SapatoSelecionado = model.Sapatos.FirstOrDefault();
            }
        }
    }


}

