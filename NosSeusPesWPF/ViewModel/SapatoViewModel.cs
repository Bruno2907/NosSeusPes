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
            model.Sapatos.Remove(SapatoSelecionado);
            Sapatos.Remove(SapatoSelecionado);
            model.SaveChanges();
            SapatoSelecionado = model.Sapatos.FirstOrDefault();
        }
    }


}

