
using NHibernate.Mapping;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TodoFriends.Models;


namespace TodoFriends.Data
{
    public partial class TodoFriensContext : DbContext
    {
        public TodoFriensContext()
            : base("name=TodoFriensContext")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Residencial> Residenciais { get; set; }
        public DbSet<Externa> Externas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Local> Locais { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
        }
    }
}
