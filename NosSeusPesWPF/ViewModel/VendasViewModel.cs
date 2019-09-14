using NosSeusPes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosSeusPesWPF.ViewModel
{
    public class VendasViewModel
    {
        public ObservableCollection<Venda> Vendas { get; set; }
        public Venda VendaSelecionada;

        private Model model;

        public VendasViewModel ()
        {
            model = new Model ();
            Vendas = new ObservableCollection<Venda> (
                model.Vendas
                .Include("Cliente")
                .Include("Modelo")
                .ToList());
            VendaSelecionada = 
                model.Vendas
                .Include ("Cliente")
                .Include ("Modelo")
                .FirstOrDefault ();
        }
    }
}
