using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosSeusPes
{
    public class Venda
    {
        public int Id { get; set; }
        public int QuantidadeDeItens { get; set; }
        public Estoque Modelo { get; set; }
        public decimal PrecoPorItem { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataDaVenda { get; set; }
    }
}
