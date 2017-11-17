using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApi_Prova.Connection
{
    public class MinhaConexao : DbContext
    {
        public MinhaConexao() : base("name=MinhaConexao")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<WebApi_Prova.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<WebApi_Prova.Models.Venda> Vendas { get; set; }

        public System.Data.Entity.DbSet<WebApi_Prova.Models.Produto> Produtoes { get; set; }
    }
}