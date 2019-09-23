namespace NosSeusPes
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model : DbContext
    {
        public Model () : base ("name=Model")
        {
        }


        public virtual DbSet<Cliente> Clientes{ get; set; }
        public virtual DbSet<Estoque> Estoques{ get; set; }
        public virtual DbSet<PessoaFisica> PessoasFisicas{ get; set; }
        public virtual DbSet<PessoaJuridica> PessoasJuridicas{ get; set; }
        public virtual DbSet<Sapato> Sapatos{ get; set; }
        public virtual DbSet<Sapato> Vendas{ get; set; }
    }
}