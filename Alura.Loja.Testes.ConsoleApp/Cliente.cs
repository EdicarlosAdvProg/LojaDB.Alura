namespace Alura.Loja.Testes.ConsoleApp {
    public class Cliente {
        public Cliente() {
        }

        public int ClienteId { get; set; }
        public string Nome { get; internal set; }
        public Endereco EnderecoEntrega { get; set; }
    }
}