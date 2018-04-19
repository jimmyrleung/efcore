using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        /* Aula 3 - ChangeTracker e estados */
        static void Main(string[] args)
        {
            using (var context = new LojaContext())
            {
                // Logger
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                // Busca os produtos
                IList<Produto> produtos = context.Produtos.ToList();

                // Exibe o estado dos produtos
                exibeEntriesComState(context.ChangeTracker.Entries().ToList());

                // Altera uma propriedade de um produto
                var p1 = produtos.First();
                p1.Nome = "Cassino Royale alterado sem updater";

                // Exibe o estado dos produtos
                exibeEntriesComState(context.ChangeTracker.Entries().ToList());

                // Desabilitar o autodetect por questões de performance
                //context.ChangeTracker.AutoDetectChangesEnabled = false;

                // Só pelo fato do produto estar "Modified" o SaveChanges fará um 
                // update implícito
                context.SaveChanges();

                // Pega a lista atualizada
                produtos = context.Produtos.ToList();

                exibeEntriesComState(context.ChangeTracker.Entries().ToList());

                var p2 = new Produto() { Nome = "Adicionado e removido antes do SaveChanges", Categoria = "Outros", Preco = 999.99 };

                // Adicionamos e removemos sem dar um SaveChanges
                context.Produtos.Add(p2);
                context.Produtos.Remove(p2);

                // Entidade deve estar Detached
                var detachedEntry = context.Entry(p2);
                Console.WriteLine(detachedEntry.Entity.ToString() + " - " + detachedEntry.State);


                System.Threading.Thread.Sleep(10000);
            }
        }

        public static void exibeEntriesComState(IList<EntityEntry> entries)
        {
            foreach(var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }

        /* Aula 1 e 2 - CRUD */
        //static void Main(string[] args)
        //{
        //    GravarUsandoAdoNet();
        //    GravarUsandoEntity();
        //    RecuperarUsandoEntity();
        //    ExcluirUsandoEntity();
        //    RecuperarUsandoEntity();
        //    AlterarUsandoEntity();
        //    System.Threading.Thread.Sleep(10000);
        //}

        private static void ExcluirUsandoEntity()
        {
            using (var repo = new ProdutoDAOEF())
            {
                IList<Produto> produtos = repo.Listar();

                foreach (var p in produtos)
                {
                    repo.Remover(p);
                }
            }
        }

        private static void AlterarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Cassino Royalr";
            p.Categoria = "Filme";
            p.Preco = 17.99;

            using (var contexto = new ProdutoDAOEF())
            {
                var idProdutoCriado = contexto.AdicionarRetornandoId(p);
                var produtoCriado = contexto.ObterPorId(idProdutoCriado);
                Console.WriteLine("Nome errado: " + produtoCriado.Nome);

                produtoCriado.Nome = "Cassino Royale";
                contexto.Atualizar(produtoCriado);

                var produtoCorrigido = contexto.ObterPorId(idProdutoCriado);
                Console.WriteLine("Nome corrigido: " + produtoCorrigido.Nome);
            }

        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Percy Jackson: O Ladrão de Raios";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new ProdutoDAOEF())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }

        private static void RecuperarUsandoEntity()
        {
            using (var repo = new ProdutoDAOEF())
            {
                IList<Produto> produtos = repo.Listar();
                if(produtos.Count > 0)
                {
                    foreach (var p in produtos)
                    {
                        Console.WriteLine(String.Format("Livro: {0} - R$ {1}", p.Nome, p.Preco));
                    }
                }
                else
                {
                    Console.WriteLine("Não existem livros cadastrados.");
                }
            }
        }
    }
}
