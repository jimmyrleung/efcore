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
