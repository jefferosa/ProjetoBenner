using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web;
using ProjetoBenner.Models;

namespace ProjetoBenner.DAO
{
    public class SalaoContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        //public DbSet<ControleFinanceiro> controleFinanceiro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjetoDB;Trusted_Connection=true;");
        }
    }
}