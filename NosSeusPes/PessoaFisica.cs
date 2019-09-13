using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NosSeusPes
{
    public class PessoaFisica : Cliente
    {
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
