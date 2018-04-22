using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public Produto()
        {
            Promocoes = new List<PromocaoProduto>();
        }

        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string UnidadeMedida { get; internal set; }
        public Categoria Categoria { get; internal set; }
        public int CategoriaId { get; set; }
        public IList<PromocaoProduto> Promocoes { get; set; }

        public override string ToString()
        {
            // return string.Format("Produto: {0} - Categoria: {1} - Preço: R$ {2}", this.Nome, this.Categoria, this.Preco);

            // Interpolação de string sem format
            return $"Produto: {this.Nome} - Categoria: {this.Categoria.Nome} - Preço: R$ {this.PrecoUnitario}";
        }
    }
}