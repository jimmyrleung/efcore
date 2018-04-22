using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Indicamos o nosso servidor
            optionsBuilder.UseSqlServer("Server=DESKTOP-440J00T;Database=EFCORE_LojaDB;Trusted_Connection=true;");
        }
    }
}