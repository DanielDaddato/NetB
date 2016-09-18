using MySql.Data.Entity;
using NetB.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetB.Repositorios
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class NetBContext : DbContext
    {
        //public NetBContext()
        //: base("NetBContext")
        //{
        //    {                
        //        this.Configuration.LazyLoadingEnabled = false;
        //    }
        //}

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Permissoes> Permissoes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Usuarios>().ToTable("usuarios");
            modelBuilder.Entity<Departamentos>().ToTable("departamento");
            modelBuilder.Entity<Permissoes>().ToTable("permissoes");

        }
    }
}
