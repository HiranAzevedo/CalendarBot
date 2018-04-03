using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Negocio.Models;
using Negocio.Interface;

namespace Banco.Context
{
    public class BancoContext : DbContext, IContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BancoContext() : base("name=BandoContext")
        {
        }

        public DbSet<Carro> Carroes { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
    }
}
