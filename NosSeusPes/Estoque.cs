using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosSeusPes
{
    public class Estoque
    {
        public int Id { get; set; }
        public Sapato Modelo { get; set; }
        public int Tamanho { get; set; }
        public int Quantidade { get; set; }
    }
}
