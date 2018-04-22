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
        static void Main(string[] args)
        {
            using (var db = new LojaContext())
            {
                db.SaveChanges();
            }
        }

        // Aula 7 - Relacionamento 1 para 1
        //static void Main(string[] args)
        //{
        //    Cliente c = new Cliente()
        //    {
        //        Nome = "Fulano",
        //        EnderecoDeEntrega = new Endereco()
        //        {
        //            Cidade = "São Paulo",
        //            Bairro = "Paraíso",
        //            Logradouro = "Rua Estela",
        //            Numero = 515,
        //            Complemento = "Bloco G, 1º Andar"
        //        }
        //    };
        //    using (var db = new LojaContext())
        //    {
        //        db.Clientes.Add(c);
        //        db.SaveChanges();
        //    }
        //}

        // Aula 6 - Relacionamento N para N
        //static void Main(string[] args)
        //{
        //    Categoria c = new Categoria() { Nome = "Alimentos" };
        //    Produto p1 = new Produto() { Categoria = c, Nome = "Maçã", PrecoUnitario = 0.79, UnidadeMedida = "Unidade" };
        //    Produto p2 = new Produto() { Categoria = c, Nome = "Banana", PrecoUnitario = 0.39, UnidadeMedida = "Unidade" };
        //    Produto p3 = new Produto() { Categoria = c, Nome = "Manga", PrecoUnitario = 0.59, UnidadeMedida = "Unidade" };
        //    Promocao promocaoFrutas = new Promocao() { descricao = "Promoção de frutas", dataInicio = DateTime.Now, dataFim = DateTime.Now.AddDays(7) };
        //    promocaoFrutas.IncluirProduto(p1);
        //    promocaoFrutas.IncluirProduto(p2);
        //    promocaoFrutas.IncluirProduto(p3);

        //    using (var db = new LojaContext())
        //    {
        //        db.Promocoes.Add(promocaoFrutas);
        //        db.SaveChanges();
        //    }
        //}

        // Aula 5 - Relacionamento 1 para N
        //static void Main(string[] args)
        //{
        //    Categoria c = new Categoria() { Nome = "Filmes" };
        //    Produto p = new Produto() { Categoria = c, Nome = "007 - Cassino Royale", PrecoUnitario = 19.99, UnidadeMedida = "Unidade" };
        //    using (var db = new LojaContext())
        //    {
        //        db.Produtos.Add(p);
        //        db.SaveChanges();
        //    }
        //}

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
            //p.Categoria = "Filme";
            p.PrecoUnitario = 17.99;

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
            //p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var contexto = new ProdutoDAOEF())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            //p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

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
                        Console.WriteLine(String.Format("Livro: {0} - R$ {1}", p.Nome, p.PrecoUnitario));
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
