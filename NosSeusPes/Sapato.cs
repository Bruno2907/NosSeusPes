using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosSeusPes
{
    public class Sapato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Cadarco { get; set; }
        public string Material { get; set; }
        public string Cor { get; set; }
        public decimal Preco { get; set; }
        public byte[] Fotografia { get; set; }

    }
}
