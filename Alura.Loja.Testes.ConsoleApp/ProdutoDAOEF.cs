using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class ProdutoDAOEF : IProdutoDAO, IDisposable
    {
        private LojaContext contexto;

        public ProdutoDAOEF()
        {
            // Cria uma nova instância de LojaContext
            this.contexto = new LojaContext();
        }

        public void Adicionar(Produto p)
        {
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
        }

        public int AdicionarRetornandoId(Produto p)
        {
            contexto.Produtos.Add(p);
            contexto.SaveChanges();
            return p.Id;
        }

        public void Atualizar(Produto p)
        {
            contexto.Produtos.Update(p);
            contexto.SaveChanges();
        }

        public IList<Produto> Listar()
        {
            return contexto.Produtos.ToList();
        }

        public Produto ObterPorId(int id)
        {
            return contexto.Produtos.Find(id);
        }

        public void Remover(Produto p)
        {
            contexto.Produtos.Remove(p);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}
