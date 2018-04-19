namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double Preco { get; internal set; }

        public override string ToString()
        {
            // return string.Format("Produto: {0} - Categoria: {1} - Preço: R$ {2}", this.Nome, this.Categoria, this.Preco);

            // Interpolação de string sem format
            return $"Produto: {this.Nome} - Categoria: {this.Categoria} - Preço: R$ {this.Preco}";
        }
    }
}