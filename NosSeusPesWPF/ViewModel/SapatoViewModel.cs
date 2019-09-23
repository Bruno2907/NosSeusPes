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
        public void DeletarSapato(int ID)
        {
            Sapato s;
            s = Sapatos.Where(sa => sa.Id == ID).FirstOrDefault();
            Sapatos.Remove(s);
            model.Sapatos.Remove(s);
            model.SaveChanges();
        }
    }
}
