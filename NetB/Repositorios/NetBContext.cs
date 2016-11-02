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
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<Responsavel> Responsavel { get; set; }
        public DbSet<Projetos> Projetos { get; set; }
        public DbSet<Projetos_Has_Usuarios> ProjetosUsuarios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Justificativas> Justificativas { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Usuarios>().ToTable("usuarios");
            modelBuilder.Entity<Departamentos>().ToTable("departamento");
            modelBuilder.Entity<Responsavel>().ToTable("responsavel");
            modelBuilder.Entity<Tarefas>().ToTable("tarefas");
            modelBuilder.Entity<Projetos>().ToTable("projetos");
            modelBuilder.Entity<Projetos_Has_Usuarios>().ToTable("projetos_has_usuarios");
            modelBuilder.Entity<Clientes>().ToTable("clientes");
            modelBuilder.Entity<Log>().ToTable("log");
            modelBuilder.Entity<Justificativas>().ToTable("justificativas");

        }
    }
}
