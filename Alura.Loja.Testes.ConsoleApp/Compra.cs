namespace Alura.Loja.Testes.ConsoleApp {
    public class Compra {
        
        public int Id { get; set; }
        public int Quantidade { get; internal set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }
        public Compra() {
        }
        public Compra(Produto produto, int quantidade) {
            Quantidade = quantidade;
            Produto = produto;

            Preco = Quantidade * Produto.PrecoUnitario;
        }

        public override string ToString() {
            return $"Compra de {Quantidade} quantidades de {Produto.Nome}";
        }

        //public void CalculaPreco() {
        //    Preco = Quantidade * Produto.PrecoUnitario;
        //}
    }
}