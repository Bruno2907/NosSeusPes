using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosSeusPes
{
    public class Sapato
    {
        public int ID;

        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Cadarco { get; set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public byte[] Fotografia { get; set; }
        public int QuantidadedeItens { get; set; }
        public object Sapato { get; set; }
        public DateTime DatadeInsercaonoEstoque { get; set; }
        public object NovoItem { get; set; }
        public string Quantidadede { get; set; }
        public string Quantidade { get; set; }

        public static implicit operator Sapato(Estoque v)
        {
            throw new NotImplementedException();
        }

        public static implicit operator string(Sapato v)
        {
            throw new NotImplementedException();
        }
    }
}
