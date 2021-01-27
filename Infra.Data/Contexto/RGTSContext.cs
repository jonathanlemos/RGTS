using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Contexto
{
    public class RGTSContext : DbContext
    {
        //public RGTSContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        //{

        //}

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RGTS;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Usuario>()
            //    .HasData(new List<Usuario>(){
            //    new Usuario(1, "teste@teste.com", "123", "primeiro nm", "nm completo", "end", "compl", 1, "cidade nv", "rj", "12345", "M")
            //});

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if(entry.GetType().GetProperty("DataCadastro") != null)
                {
                    if(entry.State == EntityState.Added)
                    {
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if(entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCadastro").IsModified = false;
                    }
                }
            }
            return base.SaveChanges();
        }

    }
}
