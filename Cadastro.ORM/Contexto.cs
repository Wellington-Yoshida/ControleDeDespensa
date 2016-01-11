using Cadastro.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro.ORM
{
    public class Contexto : DbContext
    {
        public Contexto()
        : base("DbTrainee2015")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }
        
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Estado> Estados { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
