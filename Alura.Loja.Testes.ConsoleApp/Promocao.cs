using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public Promocao()
        {
            Produtos = new List<PromocaoProduto>();
        }

        public int Id { get; set; }
        public string descricao { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        
        // Produtos da promoção
        public IList<PromocaoProduto> Produtos { get; set; }

        public void IncluirProduto(Produto p)
        {
            this.Produtos.Add(new PromocaoProduto() { Produto = p });
        }
    }
}
