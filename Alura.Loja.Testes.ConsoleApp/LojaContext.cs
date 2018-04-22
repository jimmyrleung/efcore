using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<PromocaoProduto> PromocoesProdutos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeia uma FK composta
            modelBuilder.Entity<PromocaoProduto>().HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            // Mapeia a entidade "Endereco" para tabela "Enderecos"
            modelBuilder
            .Entity<Endereco>()
            .ToTable("Enderecos");

            // Cria uma propriedade ClienteId
            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            // Define a propriedade ClienteId como PK
            // Como nossa classe endereço tem uma referência a cliente, será
            // utilizado o Id do cliente
            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Indicamos o nosso servidor
            optionsBuilder.UseSqlServer("Server=DESKTOP-440J00T;Database=EFCORE_LojaDB;Trusted_Connection=true;");
        }
    }
}