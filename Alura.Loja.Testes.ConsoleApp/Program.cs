using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GravarUsandoAdoNet();
            GravarUsandoEntity();
            RecuperarUsandoEntity();
            ExcluirUsandoEntity();
            RecuperarUsandoEntity();
            AlterarUsandoEntity();
            System.Threading.Thread.Sleep(10000);
        }

        private static void ExcluirUsandoEntity()
        {
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
                foreach (var p in produtos)
                {
                    repo.Produtos.Remove(p);
                }
                repo.SaveChanges();
            }
        }

        private static void AlterarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Cassino Royalr";
            p.Categoria = "Filme";
            p.Preco = 17.99;

            // Adicionando produto
            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }

            using (var contexto = new LojaContext())
            {
                p.Nome = "Cassino Royale";
                contexto.Produtos.Update(p);
                contexto.SaveChanges();
            }

            using (var contexto = new LojaContext())
            {
                var produto = contexto.Produtos.Find(p.Id);
                Console.WriteLine("Nome corrigido: " + p.Nome);
                contexto.SaveChanges();
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Percy Jackson: O Ladrão de Raios";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
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
            using (var repo = new LojaContext())
            {
                IList<Produto> produtos = repo.Produtos.ToList();
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
