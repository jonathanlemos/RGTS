﻿//using Infr.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Contexto
{
    public class RGTSContext : DbContext
    {
        //public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Perfil> Perfil { get; set; }
        //public DbSet<Permissao> Permissao { get; set; }
        //public DbSet<Sexo> Sexo { get; set; }
        //public DbSet<Cidade> Cidade { get; set; }
        //public DbSet<Estado> Estado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sql local
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RGTS;Trusted_Connection=True;"); rgtsdb
            
            //aws sqlserver
            string serverrgts = "rgtsdb.ch0sy8hf0okh.us-east-2.rds.amazonaws.com";
            optionsBuilder.UseSqlServer(@"Server="+ serverrgts+ ",1433; Database=rgtsdb; User Id=admin; Password=qW7Su3aQ;");

            //configuração via comandos ps ou pm
            //Scaffold-DbContext "Server=rgtsdb.ch0sy8hf0okh.us-east-2.rds.amazonaws.com,1433;Database=rgtsdb; User Id=admin; Password=qW7Su3aQ;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
            //dotnet ef dbcontext scaffold "Server=rgtsdb.ch0sy8hf0okh.us-east-2.rds.amazonaws.com,1433;Database=rgtsdb; User Id=admin; Password=qW7Su3aQ;" Microsoft.EntityFrameworkCore.SqlServer -o Model
            //dotnet ef dbcontext scaffold "Server=rgtsdb.ch0sy8hf0okh.us-east-2.rds.amazonaws.com,1433;Database=rgtsdb; User Id=admin; Password=qW7Su3aQ;" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "RGTSDbContext" -d
            //dotnet ef dbcontext scaffold "Server=rgtsdb.ch0sy8hf0okh.us-east-2.rds.amazonaws.com,1433;Database=rgtsdb; User Id=admin; Password=qW7Su3aQ;" Microsoft.EntityFrameworkCore.SqlServer -d
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
