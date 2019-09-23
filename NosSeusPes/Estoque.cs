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
        public Sapato Nome { get; set; }
        public int Tamanho { get; set; }
        public int Quantidade { get; set; }
        public object Nome { get; set; }

        public static implicit operator string(Estoque v)
        {
            throw new NotImplementedException();
        }
    }
}
