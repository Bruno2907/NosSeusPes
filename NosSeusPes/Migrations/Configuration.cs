namespace NosSeusPes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NosSeusPes.Model>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed (NosSeusPes.Model context)
        {
            //context.Database.Delete ();
            PessoaFisica pessoaFisica = new PessoaFisica
            {
                Nome = "Bruno Hoffmann de Mattos",
                DataDeNascimento = new DateTime (1996, 07, 29)
            };
            PessoaFisica pessoaFisica02 = new PessoaFisica
            {
                Nome = "Isabela Hoffmann de Mattos",
                DataDeNascimento = new DateTime (2011, 10, 03)
            };
            context.PessoasFisicas.AddOrUpdate (pessoaFisica);
            context.PessoasFisicas.AddOrUpdate (pessoaFisica02);


            Sapato sapato = new Sapato
            {
                Nome = "Crocs",
                Cadarco = false,
                Material = "Plastico",
                Cor = "Branco",
                Preco = 50M
            };
            Sapato sapato02 = new Sapato
            {
                Nome = "Nike Super Pro Plus Limited Gold Edition",
                Cadarco = true,
                Material = "Literally GOLD",
                Cor = "Yellow",
                Preco = 999999.99M
            };
            context.Sapatos.AddOrUpdate (sapato);
            context.Sapatos.AddOrUpdate (sapato02);


            Estoque estoqueS1T38 = new Estoque
            {
                Nome = sapato,
                Tamanho = 38,
                Quantidade = 380
            };
            Estoque estoqueS1T40 = new Estoque
            {
                Nome = sapato,
                Tamanho = 40,
                Quantidade = 400
            };
            Estoque estoqueS1T42 = new Estoque
            {
                Nome = sapato,
                Tamanho = 42,
                Quantidade = 419
            };
            Estoque estoqueS2T100 = new Estoque
            {
                Nome = sapato02,
                Tamanho = 100,
                Quantidade = 1
            };
            context.Estoques.AddOrUpdate (estoqueS1T38);
            context.Estoques.AddOrUpdate (estoqueS1T40);
            context.Estoques.AddOrUpdate (estoqueS1T42);
            context.Estoques.AddOrUpdate (estoqueS2T100);


            Sapato venda = new Sapato
            {
                QuantidadeDeItens = 99,
                Modelo = estoqueS1T42,
                PrecoPorItem = estoqueS1T42.Nome.Preco,
                Cliente = pessoaFisica,
                DataDaVenda = DateTime.Now
            };
            Sapato venda02 = new Sapato
            {
                QuantidadeDeItens = 1,
                Modelo = estoqueS2T100,
                PrecoPorItem = estoqueS2T100.Nome.Preco - 0.01M,
                Cliente = pessoaFisica02,
                DataDaVenda = DateTime.Now
            };
            context.Vendas.AddOrUpdate (venda);
            context.Vendas.AddOrUpdate (venda02);


            context.SaveChanges ();
        }
    }
}
